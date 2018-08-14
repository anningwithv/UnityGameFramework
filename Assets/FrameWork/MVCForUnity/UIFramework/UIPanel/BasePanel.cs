using UnityEngine;
using System.Collections;

namespace ZW.UIFramework
{
    public class BasePanel : MonoBehaviour, IPanel
    {
        public GameObject m_children = null;

        /// <summary>
        /// 界面被显示出来
        /// </summary>
        public virtual void OnEnter()
        {
            SetInteractable(true);
            SetChildrenVisible(true);
        }

        /// <summary>
        /// 界面暂停
        /// </summary>
        public virtual void OnPause()
        {
            SetInteractable(false);
            SetChildrenVisible(false);
        }

        /// <summary>
        /// 界面继续
        /// </summary>
        public virtual void OnResume()
        {
            SetInteractable(true);
            SetChildrenVisible(true);
        }

        /// <summary>
        /// 界面不显示,退出这个界面，界面被关闭
        /// </summary>
        public virtual void OnExit()
        {
            SetInteractable(false);
            SetChildrenVisible(false);
        }

        protected void SetInteractable(bool enable)
        {
            CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
            if (canvasGroup != null)
            {
                canvasGroup.blocksRaycasts = enable;
            }
        }

        protected void SetChildrenVisible(bool visible)
        {
            Debug.Assert(m_children != null, "Panel child is null");

            m_children.SetActive(visible);
        }
    }
}