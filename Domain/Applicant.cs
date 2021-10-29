using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace Domain
{
    public class Applicant : TableEntity
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Income { get; set; }

        public string Info { get; set; }

        public Applicant()
        {

        }
        public Applicant(string fname, string lname, string info)
        {
            FirstName = fname; 
            LastName = lname;
            Info = info;
            Income = 3500;

            PartitionKey = Id;
            RowKey = FirstName + LastName;
        }
        public override string ToString()
        {
            return $"Dear {LastName} Based on your income {Income.ToString()} we have the following options : ";
        }
    }
}
