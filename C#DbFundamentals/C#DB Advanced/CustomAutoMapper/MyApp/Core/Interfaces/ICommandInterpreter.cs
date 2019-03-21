using MyApp.Data;

namespace MyApp.Core.Interfaces
{
    public interface ICommandInterpreter
    {
        string Read(string[]args);

    }
}