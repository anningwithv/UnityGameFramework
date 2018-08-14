using UnityEngine;

namespace ZW.MVCForUnity
{
    public class EventTrigger :MonoBehaviour, IEventTrigger
    {
        protected IFacade Facade
        {
            get
            {
                return ZW.MVCForUnity.Facade.GetInstance();
            }
        }

        public void TriggerEvent(IEventMessage eventNode)
        {
            Debug.Log("Event: " + eventNode.Name + " is triggered");
            Facade.TriggerEvent(eventNode);
        }
    }
}