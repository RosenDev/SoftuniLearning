using System.Collections.Generic;
using PANDA.Data.Models;

namespace PANDA.Services
{
    public interface IReceiptService
    {
        List<Receipt> GetAllReceipts(string userId);
        void CreateFromPackage(Package package);
    }
}