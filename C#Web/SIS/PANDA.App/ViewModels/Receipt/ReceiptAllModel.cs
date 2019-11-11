using System;

namespace PANDA.App.ViewModels.Receipt
{
    public class ReceiptAllModel
    {
        public string Id { get; set; }
        public decimal Fee { get; set; }

        public DateTime IssuedOn { get; set; }
        public string Recipient { get; set; }
    }
}