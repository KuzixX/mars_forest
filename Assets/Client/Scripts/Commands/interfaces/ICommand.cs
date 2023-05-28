using Client.Scripts.Models;

namespace Client.Scripts.Commands.interfaces
{
    interface ICommand
    {
        public void Execute(string cmd);
    }
}