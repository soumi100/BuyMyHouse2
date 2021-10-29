using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMyHouseAgenet.Service
{
    public interface IApplicantService
    {
        Task insertOrUpdateAsync(Applicant applicant);
        Task DeleteEntityAsync(string partitionKey, string rowKey);
        IEnumerable<Applicant> GetEntitiesByPartitionKey(string partitionKey);
        IEnumerable<Applicant> GetEntitiesByRowKey(string rowKey);
        Applicant GetEntityByPartitionKeyAndRowKey(string partitionKey, string rowKey);
    }
}
