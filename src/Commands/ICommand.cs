namespace Run.Azurite.NET.Commands
{
    public interface ICommand
    {
        bool Run(string command);
    }
}