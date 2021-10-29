using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using BuyMyHouseAgenet.Service;
using Domain;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace BuyMyHouseAgenet
{
    public  class ApplicantHttpTrigger
    {
        private readonly IApplicantService applicantService;

        public ApplicantHttpTrigger(IApplicantService applicant)
        {
            this.applicantService = applicant;
        }

        [Function("AddAplicant")]
        public async Task<HttpResponseData> AddAplicantAsync([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            Applicant applicant = new Applicant("soumia","bouhouri","myInfo");
            await applicantService.insertOrUpdateAsync(applicant);
            return req.CreateResponse(HttpStatusCode.Created);
        }
    }
}
