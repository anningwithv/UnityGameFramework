using System;

namespace ZW.MVCForUnity
{
    public interface IControllerManager
    {
        void RegisterCommand(string eventName, Func<ICommand> commandClassRef);
        bool HasCommand(string eventName);
        void UnregisterCommand(string eventName);
        void ExecuteCommand(IEventMessage eventNode);
    }
}
