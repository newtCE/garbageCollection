using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollection.Models
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State{ get; set; }
        public string Zip { get; set; }
        public double Balance { get; set; }
        public string SuspendStart { get; set; }
        public string SuspendEnd { get; set; }

    }
}