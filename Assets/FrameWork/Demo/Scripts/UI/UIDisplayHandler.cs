using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZW.UIFramework;
using ZW.MVCForUnity;

public class UIDisplayHandler : EventNodeMono
{
    void Start()
    {
        UIManager.Instance.PushPanel(UIPanelType.MainMenu);

        InitEvent();
    }


    private void InitEvent()
    {
        m_name = this.GetType().ToString();
        m_interests = new string[] { EventCode.ShowOperateCubePanel.ToString(), EventCode.ShowMainMenu.ToString() };
        RegisterSelf();
    }

    public override void HandleEvent(IEventMessage eventNode)
    {
        base.HandleEvent(eventNode);

        if (eventNode.Name.Equals(EventCode.ShowOperateCubePanel.ToString()))
        {
            UIManager.Instance.PushPanel(UIPanelType.OperateCubePanel);
        }
        else if(eventNode.Name.Equals(EventCode.ShowMainMenu.ToString()))
        {
            UIManager.Instance.PushPanel(UIPanelType.MainMenu);
        }
    }
}
