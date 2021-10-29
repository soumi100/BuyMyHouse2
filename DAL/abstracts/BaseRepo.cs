using Domain;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public abstract class BaseRepo <T> :IRepository<T> where T : TableEntity, new()
    {
        internal CloudTable table;
        public BaseRepo()
        {
            table = AzureTSContext.GetCloudTableClient().GetTableReference(typeof(T).Name);
            table.CreateIfNotExistsAsync();
        }
        public async Task DeleteEntityAsync(string partitionKey, string rowKey)
        {
            T FoundEntity = await RetrieveRecord(table, partitionKey, rowKey + partitionKey);
            if (FoundEntity is not null)
            {
                TableOperation tableOperation = TableOperation.Delete(FoundEntity);
                var result = await table.ExecuteAsync(tableOperation);
            }
        }

        public IEnumerable<T> GetEntitiesByPartitionKey(string partitionKey)
        {
            List<T> ListEntities = new List<T>();
            TableQuery<T> query = new TableQuery<T>()
                   .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey));

            foreach (T t in table.ExecuteQuerySegmentedAsync(query, null).Result)
            {
                ListEntities.Add(t);
            }
            return ListEntities;
        }

        public IEnumerable<T> GetEntitiesByRowKey(string rowKey)
        {
            List<T> ListEntities = new List<T>();

            TableQuery<T> query = new TableQuery<T>()
                   .Where(TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, rowKey));

            foreach (T t in table.ExecuteQuerySegmentedAsync(query, null).Result)
            {
                ListEntities.Add(t);
            }
            return ListEntities;
        }

        public T GetEntityByPartitionKeyAndRowKey(string partitionKey, string rowKey)
        {
            T myEntity = new T();

            TableQuery<T> query = new TableQuery<T>()
                   .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey))
                   .Where(TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, rowKey));

            var result = table.ExecuteQuerySegmentedAsync(query, null).Result;
            return myEntity = result.FirstOrDefault() ;
        }

        public async Task InsertOrUpdate(T entity)
        {

            try
            {
                entity.PartitionKey = typeof(T).Name;
                //pluralise the partition key.
                if (entity.PartitionKey.Substring(entity.PartitionKey.Length - 1, 1).ToLower() == "y")
                    entity.PartitionKey = entity.PartitionKey.Substring(0, entity.PartitionKey.Length - 1) + "ies";

                if (entity.PartitionKey.Substring(entity.PartitionKey.Length - 1, 1).ToLower() != "s")
                    entity.PartitionKey = entity.PartitionKey + "s";
                TableOperation tableOperation = TableOperation.InsertOrReplace(entity);
                TableResult result = await table.ExecuteAsync(tableOperation);
            }
            catch (Exception e)
            {

                throw new Exception("Exception:" + e.Message);
            }
        }
        //public IEnumerable<T> GetEntitiesByFilterRange(T minPrice, T maxPrice)
        //{
        //    List<T> ListEntities = new List<T>();

        //    TableQuery<T> query = new TableQuery<T>()
        //           .Where(TableQuery.GenerateFilterCondition("Price", QueryComparisons.GreaterThanOrEqual, minPrice.ToString()))
        //           .Where(TableQuery.GenerateFilterCondition("Price", QueryComparisons.LessThanOrEqual, maxPrice.ToString()));

        //    foreach (T t in table.ExecuteQuerySegmentedAsync(query, null).Result)
        //    {
        //        ListEntities.Add(t);
        //    }
        //    return ListEntities;
        //}
        public async Task<T> RetrieveRecord(CloudTable table, string partitionKey, string rowKey)
        {
            TableOperation tableOperation = TableOperation.Retrieve<House>(partitionKey, rowKey);
            TableResult tableResult = await table.ExecuteAsync(tableOperation);
            return tableResult.Result as T;
        }
    }
}
