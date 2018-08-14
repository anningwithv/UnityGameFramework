using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZW.MVCForUnity;

public class MainMenuPanelMediator : Mediator
{
    private MainMenuPanel m_panel = null;

    protected override void Awake()
	{
        base.Awake();

        m_panel = GetComponent<MainMenuPanel>();

        m_panel.m_btn.onClick.AddListener(ShowOperateCubePanel);
	}

	protected override void InitEvent()
	{
        base.InitEvent();

        //m_interests = new string[] { EventCode.EventMoveCube.ToString() };
	}

	private void ShowOperateCubePanel()
    {
        TriggerEvent(new EventMessage(EventCode.ShowOperateCubePanel.ToString(), null));
    }
}
