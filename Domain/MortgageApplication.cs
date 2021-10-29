using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MortgageApplication
    {
        public Guid Id { get; set; }
        public House HouseInfo { get; set; }
        public Applicant ApplicantInfo { get; set; }
        public double AmountToBeBorrowed { get; set; }
        public MortgageApplication()
        {
            Id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return $"{ApplicantInfo.ToString()} {HouseInfo.ToString()} " +
                $"and this would be the amount to be borrowed {AmountToBeBorrowed.ToString()} $";
               
        }
    }
}
