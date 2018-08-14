using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ZW.UIFramework
{
    [CreateAssetMenu(menuName = "UIFramework/Create panel assets")]
    public class UIPanelAssets : ScriptableObject
    {
        [Serializable]
        public class PanelInfo
        {
            public UIPanelType panelType;
            public string prefabPath;
        }

        public List<PanelInfo> panelInfos;
    }
}