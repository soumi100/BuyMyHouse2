using DAL;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMyHouseAgenet.Service
{
    public class ApplicantService : IApplicantService
    {
        public IApplicantRepo applicantrepo { get; set; }

        public ApplicantService(IApplicantRepo applicantService)
        {
            this.applicantrepo = applicantService;
        }

        public Task insertOrUpdateAsync(Applicant applicant)
        {
           return applicantrepo.InsertOrUpdate(applicant);
        }

        public Task DeleteEntityAsync(string partitionKey, string rowKey)
        {
            return applicantrepo.DeleteEntityAsync(partitionKey, rowKey);
        }

        public IEnumerable<Applicant> GetEntitiesByPartitionKey(string partitionKey)
        {
            return applicantrepo.GetEntitiesByPartitionKey(partitionKey);
        }

        public IEnumerable<Applicant> GetEntitiesByRowKey(string rowKey)
        {
            return applicantrepo.GetEntitiesByRowKey(rowKey);
        }

        public Applicant GetEntityByPartitionKeyAndRowKey(string partitionKey, string rowKey)
        {
            return applicantrepo.GetEntityByPartitionKeyAndRowKey(partitionKey, rowKey);
        }
    }
}
