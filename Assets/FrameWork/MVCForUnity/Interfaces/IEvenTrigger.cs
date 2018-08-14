using System;

namespace ZW.MVCForUnity
{
    /// <summary>
    /// Trigger event
    /// </summary>
    public interface IEventTrigger
    {
        void TriggerEvent(IEventMessage eventNode);
    }
}
