using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZW.MVCForUnity
{
    public class Mediator : EventTrigger, IMediator
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

        public bool CompareMethodContext(object obj)
        {
            return obj.Equals(this);
        }

        protected virtual void InitEvent()
        {
            m_name = this.GetType().ToString();
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
            Debug.Log("Mediator is registered: " + m_name);
        }

        public virtual void OnRemove()
        {
            Debug.Log("Mediator is removed: " + m_name);
        }

        protected virtual void Awake()
        {
            InitEvent();
        }

        protected virtual void OnEnable()
        {
            Facade.RegisterMediator(this);
        }

        protected virtual void OnDisable()
        {
            Facade.UnregisterMediator(m_name);
        }
    }
}
