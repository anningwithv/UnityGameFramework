using System;
using System.Collections.Generic;

namespace ZW.MVCForUnity
{
    /// <summary>
    /// Interface for facade
    /// </summary>
    public interface IFacade: IEventTrigger
    {
        Dictionary<string, IList<IEventObserver>> EventHandlerList { get; }

        void RegisterProxy(IProxy proxy);
        IProxy GetProxy(string proxyName);
        void UnregisterProxy(IProxy proxy);

        void RegisterMediator(IMediator mediator);
        IMediator GetMediator(string mediatorName);
        void UnregisterMediator(string mediatorName);

        void RegisterCommand(string eventName, Func<ICommand> commandClassRef);
        bool HasCommand(string eventName);
        void UnregisterCommand(string eventName);

        void AddEventHandler(string eventName, IEventObserver eventHandler);
        void RemoveEventHandler(string eventName, object methodContext);
    }
}
