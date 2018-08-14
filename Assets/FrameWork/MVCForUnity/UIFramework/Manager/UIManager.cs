using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using ZW.MVCForUnity;

namespace ZW.UIFramework
{
    public class UIManager
    {
        /// 
        /// 单例模式的核心
        /// 1，定义一个静态的对象 在外界访问 在内部构造
        /// 2，构造方法私有化

        private static UIManager _instance;

        public static UIManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UIManager();
                }
                return _instance;
            }
        }

        private Transform m_canvasTransform;
        private Transform CanvasTransform
        {
            get
            {
                if (m_canvasTransform == null)
                {
                    m_canvasTransform = GameObject.Find("Canvas").transform;
                }
                return m_canvasTransform;
            }
        }

        private Dictionary<UIPanelType, string> m_panelPathDict = new Dictionary<UIPanelType, string>();//存储所有面板Prefab的路径
        private Dictionary<UIPanelType, IPanel> m_panelDict = new Dictionary<UIPanelType, IPanel>();//保存所有实例化面板的游戏物体身上的BasePanel组件
        private Stack<IPanel> m_panelStack = new Stack<IPanel>();

        private UIManager()
        {
            ReadPanelAssets();
        }

        /// <summary>
        /// 把某个页面入栈，  把某个页面显示在界面上
        /// </summary>
        public void PushPanel(UIPanelType panelType)
        {
            if (m_panelStack == null)
                m_panelStack = new Stack<IPanel>();

            //判断一下栈里面是否有页面
            if (m_panelStack.Count > 0)
            {
                IPanel topPanel = m_panelStack.Peek();
                topPanel.OnPause();
            }

            IPanel panel = GetPanel(panelType);
            panel.OnEnter();
            m_panelStack.Push(panel);
        }
        /// <summary>
        /// 出栈 ，把页面从界面上移除
        /// </summary>
        public void PopPanel()
        {
            if (m_panelStack == null)
                m_panelStack = new Stack<IPanel>();

            if (m_panelStack.Count <= 0) return;

            //关闭栈顶页面的显示
            IPanel topPanel = m_panelStack.Pop();
            topPanel.OnExit();

            if (m_panelStack.Count <= 0) return;
            IPanel topPanel2 = m_panelStack.Peek();
            topPanel2.OnResume();

        }

        /// <summary>
        /// 根据面板类型 得到实例化的面板
        /// </summary>
        /// <returns></returns>
        private IPanel GetPanel(UIPanelType panelType)
        {
            if (m_panelDict == null)
            {
                m_panelDict = new Dictionary<UIPanelType, IPanel>();
            }

            IPanel panel = m_panelDict.TryGet(panelType);

            if (panel == null)
            {
                //如果找不到，那么就找这个面板的prefab的路径，然后去根据prefab去实例化面板
                string path = m_panelPathDict.TryGet(panelType);
                GameObject instPanel = GameObject.Instantiate(Resources.Load(path)) as GameObject;
                instPanel.transform.SetParent(CanvasTransform, false);
                m_panelDict.Add(panelType, instPanel.GetComponent<IPanel>());
                return instPanel.GetComponent<IPanel>();
            }
            else
            {
                return panel;
            }

        }

        private void ReadPanelAssets()
        {
            UIPanelAssets panelAssets = Resources.Load<UIPanelAssets>("UI Panel Assets");

            foreach (UIPanelAssets.PanelInfo info in panelAssets.panelInfos)
            {
                m_panelPathDict.Add(info.panelType, info.prefabPath);
            }
        }
	}
}