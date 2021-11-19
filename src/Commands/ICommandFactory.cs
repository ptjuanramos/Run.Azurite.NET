using System;

namespace Run.Azurite.NET.Commands
{
    public interface ICommandFactory
    {
        ICommand GetCommand();
    }
}
