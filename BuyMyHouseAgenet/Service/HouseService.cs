using DAL;
using Domain;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace BuyMyHouseAgenet.Service
{
    public class HouseService : IHouseService
    {
        public IHouseRepo houseRepo { get; set; }

        public HouseService(IHouseRepo repository)
        {
            houseRepo = repository;
        }

        public async Task insertOrUpdateAsync(House house)
        {
            await houseRepo.InsertOrUpdate(house);
        }

        public async Task DeleteEntityAsync(string partitionKey, string rowKey)
        {
            await houseRepo.DeleteEntityAsync(partitionKey, rowKey);
        }

        public IEnumerable<House> GetEntitiesByPartitionKey(string partitionKey)
        {
            return houseRepo.GetEntitiesByPartitionKey(partitionKey);
        }

        public IEnumerable<House> GetEntitiesByRowKey(string rowKey)
        {
            return houseRepo.GetEntitiesByRowKey(rowKey);
        }

        public House GetEntityByPartitionKeyAndRowKey(string partitionKey, string rowKey)
        {
            return  houseRepo.GetEntityByPartitionKeyAndRowKey(partitionKey,rowKey);
        }
    }
}
