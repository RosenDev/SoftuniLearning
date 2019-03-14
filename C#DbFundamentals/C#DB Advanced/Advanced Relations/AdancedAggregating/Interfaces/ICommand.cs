using Microsoft.EntityFrameworkCore;

namespace BillsPaymentSystem.App.Interfaces
{
    public interface ICommand
    {
       string Execute(string[] args);

    }
}