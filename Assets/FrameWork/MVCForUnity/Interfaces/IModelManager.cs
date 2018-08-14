using System;

namespace ZW.MVCForUnity
{
    public interface IModelManager
    {
        void RegisterProxy(IProxy proxy);
        IProxy GetProxy(string proxyName);
        void UnregisterProxy(IProxy proxy);
    }
}
