using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace Domain
{
    public enum Status
    {
        forSale,
        Sold
    }
    public class House : TableEntity
    {
        public string Id { get; set; }
        public string City { get; set; }
        public double Price { get; set; }
        public int NbrRooms { get; set; }

        public Status status { get; set; }
        public House()
        {

        }
        public House(string city, double price, int nbrroms)
        {
            City = city;
            Price = price;
            NbrRooms = nbrroms;
            status = Status.forSale;

            PartitionKey = Id;
            RowKey = Id + City;
        }
        public override string ToString()
        {
            return $"This House is located in : {City}, with {NbrRooms} rooms " +
                $"and Costs only {Price.ToString()} $";
        }
    }
}
