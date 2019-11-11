using System.Linq;
using PANDA.App.ViewModels.Receipt;
using PANDA.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Mapping;
using SIS.MvcFramework.Result;


namespace PANDA.App.Controllers
{
    public class ReceiptsController : Controller
    {
        private readonly IReceiptService receiptService;

        public ReceiptsController(IReceiptService receiptService)
        {
            this.receiptService = receiptService;
        }
        [Authorize]
        public IActionResult Index(string userId)
        {
            var receipts = receiptService.GetAllReceipts(userId);
            
            return View(receipts.Select(x=>new ReceiptAllModel
            {
                Fee = x.Fee,
                Id = x.Id,
                IssuedOn = x.IssuedOn,
                Recipient = x.Recipient.Username
            }).ToList());
        }

    }
}