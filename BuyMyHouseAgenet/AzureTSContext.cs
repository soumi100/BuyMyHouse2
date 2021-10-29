using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMyHouseAgenet
{
    public static class AzureTSContext
    {
        public static CloudTableClient GetCloudTableClient()
        {
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(Environment.GetEnvironmentVariable("StorageConnectionString"));
            return cloudStorageAccount.CreateCloudTableClient();
        }
    }
}
