using DAL;
using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuyMyHouseAgenet.Service
{
    public interface IHouseService
    {
        Task insertOrUpdateAsync(House house);
        Task DeleteEntityAsync(string partitionKey, string rowKey);
        IEnumerable<House> GetEntitiesByPartitionKey(string partitionKey);
        IEnumerable<House> GetEntitiesByRowKey(string rowKey);
        //IEnumerable<House> GetEntitiesByMinAndMaxPrice(double min, double max);
        House GetEntityByPartitionKeyAndRowKey(string partitionKey, string rowKey);
    }
}