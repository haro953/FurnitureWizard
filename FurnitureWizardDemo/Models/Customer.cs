using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FurnitureWizardDemo.Models
{
    public class Customer
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Company { get; set; }

        public string Street { get; set; }

        public string Suite { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int Zip { get; set; }

        public int Phone { get; set; }

        public int WorkPhone { get; set; }

        public int CellPhone { get; set; }

        public int FaxNumber { get; set; }

        public int OtherNumber { get; set; }

        public int DateOfBirth { get; set; }

        public string PrimaryEmail { get; set; }

    }

    public class CustomerDBContext : DbContext
    {
        public DbSet<Customer>Customer { get; set; }
    }

}