using System;

namespace PANDA.Models
{
    public class Receipt
    {
        public Guid Id { get; set; }

        public decimal Fee { get; set; }

        public DateTime IssuedOn { get; set; }

        public Guid RecipientId { get; set; }
        public User Recipient { get; set; }

        public Guid PackageId { get; set; }
        public Package Package { get; set; }


    }
}