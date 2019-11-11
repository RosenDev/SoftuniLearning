using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PANDA.Data.Models.Enums;

namespace PANDA.Data.Models
{
    public class Package
    {
        public Package()
        {
            Receipts=new HashSet<Receipt>();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(5)]
        public string Description { get; set; }


        public double Weight { get; set; }


        public string ShippingAddress { get; set; }

        public PackageStatus PackageStatus { get; set; }

        public DateTime EstimatedDeliveryDate { get; set; }

        [Required]
        public string RecipientId { get; set; }
        public User Recipient { get; set; }

        public ICollection<Receipt> Receipts { get; set; }


    }
}