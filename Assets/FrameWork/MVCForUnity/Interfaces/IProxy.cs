using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZW.MVCForUnity
{
    public interface IProxy : IEventTrigger
    {
        string ProxyName { get; }

        object Data { get; set; }

        void OnRegister();

        void OnRemove();
    }
}
