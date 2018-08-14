using UnityEngine;

namespace ZW.MVCForUnity
{
    public class EventNode : IEventNode
    {
        protected string m_name = string.Empty;
        protected string[] m_interests = null;

        public string Name
        {
            get
            {
                return m_name;
            }

            set
            {
                m_name = value;
            }
        }

        protected IFacade Facade
        {
            get
            {
                return ZW.MVCForUnity.Facade.GetInstance();
            }
        }

        public bool CompareMethodContext(object obj)
        {
            return this.Equals(obj);
        }

        public virtual void HandleEvent(IEventMessage eventNode)
        {

        }

        public string[] ListInterestEvent()
        {
            return m_interests;
        }

        public virtual void OnRegister()
        {

        }

        public virtual void OnRemove()
        {

        }

        public void RegisterSelf()
        {
            if (m_interests == null)
                return;

            foreach (string eventCode in m_interests)
            {
                Facade.AddEventHandler(eventCode, this);
            }
        }

        public void TriggerEvent(IEventMessage eventNode)
        {
            Debug.Log("Message: " + eventNode.Name + " is triggered");
            Facade.TriggerEvent(eventNode);
        }
    }
}