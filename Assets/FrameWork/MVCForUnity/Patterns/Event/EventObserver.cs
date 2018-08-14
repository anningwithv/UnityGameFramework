using System;

namespace ZW.MVCForUnity
{
    public class EventObserver : IEventObserver
    {
        public Action<IEventMessage> HandleMethod { get; set;}
        public object Context { get; set; }

        public string Name
        {
            get
            {
                return m_observerName;
            }

            set
            {
                m_observerName = value;
            }
        }

        protected string m_observerName = "EventObserver";

  
        public EventObserver(Action<IEventMessage> handleMethod, object context, string observerName)
        {
            this.HandleMethod = handleMethod;
            this.Context = context;
            this.Name = observerName;
        }

        public void HandleEvent(IEventMessage eventNode)
        {
            HandleMethod(eventNode);
        }

        public virtual bool CompareMethodContext(object obj)
        {
            return Context.Equals(obj);
        }
    }
}
