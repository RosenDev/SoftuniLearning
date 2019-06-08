using System;
using PANDA.Models.Enums;

namespace PANDA.Models
{
    public class Package
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public double Weight { get; set; }

        public string ShippingAddress { get; set; }

        public Status Status { get; set; }

        public DateTime EstimatedDeliveryDate { get; set; }

        public Guid RecipientId { get; set; }
        public User Recipient { get; set; }

    }
}