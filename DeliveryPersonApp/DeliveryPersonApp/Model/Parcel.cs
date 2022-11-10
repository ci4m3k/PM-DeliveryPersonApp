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

        [MaxLength(20)]
        public string Number { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
