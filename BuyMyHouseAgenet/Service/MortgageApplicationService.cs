using Domain;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMyHouseAgenet.Service
{
    public class MortgageApplicationService : IMortgageApplicationService
    {
        public void PrepareOffer(out SendGridClient client, out SendGridMessage msg)
        {

            var apiKey = "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";
            client = new SendGridClient(apiKey);
            var To = new EmailAddress("soumiaullrich@gmail.com", "soumia");
            var From = new EmailAddress("soumiaullrich@gmail.com", "soumia");
            var subject = $"New House Offer #{Guid.NewGuid()}";
            var mortgageApplication = new MortgageApplication
            {
                HouseInfo = new House("Rijswijk", 50000, 5),
                ApplicantInfo = new Applicant("soumia", "soumia info",""),
                AmountToBeBorrowed = 26441
            };

            var plainTextContent = mortgageApplication.ApplicantInfo.ToString() + "" + mortgageApplication.HouseInfo.ToString();
            var HtmlContent = $"<p> {mortgageApplication.ApplicantInfo.ToString()} <br>" +
                $" {mortgageApplication.HouseInfo.ToString()} </p> <br> Kind Regards <br> BuyMyHouseStateAgent";
            msg = MailHelper.CreateSingleEmail(From, To, subject, plainTextContent, HtmlContent);
           // applicationService.PrepareOffer( out client, out msg);
        }


    }
}
