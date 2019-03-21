namespace MyApp.Core.Interfaces
{
    public interface ICommand
    {
        string Execute(string[] args);
    }
}