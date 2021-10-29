using System;
using System.Threading.Tasks;
using BuyMyHouseAgenet.Service;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace BuyMyHouseAgenet.Controller
{
    public  class SendOfferHttpTrigger
    {
        private readonly MortgageApplicationService mortgageApplication;

        public SendOfferHttpTrigger(MortgageApplicationService mortgageApplication)
        {
            this.mortgageApplication = mortgageApplication;
        }

        // 0 30 9 * * *  / at 9:30 AM every day 
        [Function("SendOfferHttpTrigger")]
        public async Task SendOfferAsync([TimerTrigger("5,8,10 * * * * *")] FunctionContext context)
        {
            /// send email
            SendGridClient client;
            SendGridMessage msg;
            mortgageApplication.PrepareOffer(out client, out msg);
            var result = await client.SendEmailAsync(msg);

        }
    }
}
