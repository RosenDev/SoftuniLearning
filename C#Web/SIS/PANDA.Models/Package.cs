using System;
using System.Collections.Generic;
using PANDA.Models.Enums;

namespace PANDA.Models
{
    public class Package
    {
        public Package()
        {
            Receipts=new HashSet<Receipt>();
        }
        public string Id { get; set; }

        public string Description { get; set; }

        public double Weight { get; set; }

        public string ShippingAddress { get; set; }

        public PackageStatus PackageStatus { get; set; }

        public DateTime EstimatedDeliveryDate { get; set; }

        public string RecipientId { get; set; }
        public User Recipient { get; set; }

        public ICollection<Receipt> Receipts { get; set; }


    }
}