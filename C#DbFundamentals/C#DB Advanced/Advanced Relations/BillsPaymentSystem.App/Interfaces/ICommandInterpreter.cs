using BillsPaymentSystem.Data;

namespace BillsPaymentSystem.App.Interfaces
{
    public interface ICommandInterpreter
    {
        string Read(string[] args,BillsPaymentSystemContext context);
    }
}