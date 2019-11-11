using System.Linq;
using PANDA.App.BindingModels.Package;
using PANDA.App.ViewModels.Package;
using PANDA.Data.Models.Enums;
using PANDA.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;


namespace PANDA.App.Controllers
{
    public class PackagesController:Controller
    {
        private readonly IUserService userService;
        private readonly IPackageService packageService;
        public PackagesController(IUserService userService,IPackageService packageService)
        {
            this.packageService = packageService;
            this.userService = userService;
        }
        [Authorize]
        public IActionResult Create()
        {
            var usernames = userService.GetAllUsernames();
            return View(usernames);
        }
        [Authorize]
        [HttpPost(ActionName = "Create")]
        public IActionResult CreateConfirm(PackageInputBindingModel packageModel)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("/Packages/Create");
            }
            packageService.Create(packageModel.Weight,packageModel.Description,packageModel.ShippingAddress,packageModel.RecipientName);

           return Redirect("/Packages/Pending");
        }

        [Authorize]
        public IActionResult Pending()
        {
            var packages = packageService.GetAllByStatus(PackageStatus.Pending).Select(x=>new PackageAllViewModel
            {
                Id = x.Id.ToString(),
                Description = x.Description,
                ShippingAddress = x.ShippingAddress,
                Weight = x.Weight,
                RecipientName = x.Recipient.Username
            }).ToList();
            return View(packages);
        }

        [Authorize]
        public IActionResult Delivered()
        {
            var packages = packageService.GetAllByStatus(PackageStatus.Delivered).Select(x => new PackageAllViewModel
            {
                Id = x.Id.ToString(),
                Description = x.Description,
                ShippingAddress = x.ShippingAddress,
                Weight = x.Weight,
                RecipientName = x.Recipient.Username
            }).ToList();
            return View(packages);
        }
        [Authorize]
        public IActionResult Deliver(string id)
        {
            packageService.Deliver(id);
            return Redirect("/Packages/Delivered");
        }
    }
}