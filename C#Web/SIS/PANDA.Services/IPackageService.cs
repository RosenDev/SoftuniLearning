using System.Collections.Generic;
using PANDA.Data.Models;
using PANDA.Data.Models.Enums;

namespace PANDA.Services
{
    public interface IPackageService
    {
        void Create(double weight, string description, string shippingAddress, string recipient);
        List<Package> GetAllByStatus(PackageStatus packageStatus);

        void Deliver(string id);
    }
}