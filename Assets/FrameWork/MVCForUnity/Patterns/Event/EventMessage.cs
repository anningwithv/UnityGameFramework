namespace ZW.MVCForUnity
{
    /// <summary>
    /// Event message.
    /// </summary>
    public class EventMessage : IEventMessage
    {
        protected string m_name = string.Empty;
        protected object m_msgBody = null;

        public EventMessage(string name, object msgBody)
        {
            this.m_name = name;
            this.m_msgBody = msgBody;
        }

        public string Name
        {
            get
            {
                return m_name;
            }
        }

        public object Body
        {
            get
            {
                return m_msgBody;
            }

            set
            {
                m_msgBody = value;
            }
        }
    }
}