using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZW.MVCForUnity
{
    public class ModelManager : IModelManager
    {
        protected Dictionary<string, IProxy> m_proxyMap = new Dictionary<string, IProxy>();

        protected static IModelManager Instance = null;

        public static IModelManager GetInstance()
        {
            if (Instance == null)
                Instance = new ModelManager();

            return Instance;
        }

        public IProxy GetProxy(string proxyName)
        {
            if (m_proxyMap.ContainsKey(proxyName))
                return m_proxyMap[proxyName];

            return null;
        }

        public virtual void RegisterProxy(IProxy proxy)
        {
            if (!m_proxyMap.ContainsKey(proxy.ProxyName))
            {
                m_proxyMap.Add(proxy.ProxyName, proxy);

                proxy.OnRegister();
            }
        }
		
        public virtual void  UnregisterProxy(IProxy proxy)
		{
            if (m_proxyMap.ContainsKey(proxy.ProxyName))
            {
                m_proxyMap.Remove(proxy.ProxyName);

                proxy.OnRemove();
            }
		}

        public virtual void TriggerEvent(string eventName)
        {
   
        }

    }
}
