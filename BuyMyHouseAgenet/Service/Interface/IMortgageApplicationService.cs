using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMyHouseAgenet.Service
{
   public interface IMortgageApplicationService
   {
        void PrepareOffer(out SendGridClient client, out SendGridMessage msg);
    }
}
