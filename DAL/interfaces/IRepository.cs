using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepository<T> where T : TableEntity, new()
    {
        Task InsertOrUpdate(T entity);
        Task DeleteEntityAsync(string partitionKey, string rowKey);
        IEnumerable<T> GetEntitiesByPartitionKey(string partitionKey);
        IEnumerable<T> GetEntitiesByRowKey(string rowKey);
        T GetEntityByPartitionKeyAndRowKey(string partitionKey, string rowKey);
        //IEnumerable<T> GetEntitiesByFilterRange(T minPrice, T maxPrice);
        Task<T> RetrieveRecord(CloudTable table, string partitionKey, string rowKey);
    }
}
