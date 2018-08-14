using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZW.MVCForUnity
{
    public class Proxy : EventTrigger, IProxy
    {
        protected string m_name = string.Empty;

        public string ProxyName
        {
            get
            {
                return m_name;
            }
        }

        public object Data
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
                throw new System.NotImplementedException();
            }
        }

        public virtual void OnRegister()
        {
            Debug.Log("Proxt is registered: " + m_name);
        }

        public virtual void OnRemove()
        {
            Debug.Log("Mediator is removed: " + m_name);
        }

        protected virtual void InitProxy()
        {
            m_name = this.GetType().ToString();
        }

        protected virtual void Awake()
        {
            InitProxy();
        }

        protected virtual void OnEnable()
        {
            Facade.RegisterProxy(this);
        }

        protected virtual void OnDisable()
        {
            Facade.UnregisterProxy(this);
        }
    }
}
