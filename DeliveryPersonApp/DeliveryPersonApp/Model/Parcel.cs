using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryPersonApp.Model
{
    public class Parcel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(40)]
        public string Name { get; set; }
        public string Number { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public double Weight { get; set; }
        public string Size { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
    }
}
