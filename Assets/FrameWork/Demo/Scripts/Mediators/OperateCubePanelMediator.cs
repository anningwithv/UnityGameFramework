using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZW.MVCForUnity;

public class OperateCubePanelMediator : Mediator
{
    private OperateCubePanel m_panel = null;

    protected override void Awake()
    {
        base.Awake();

        m_panel = GetComponent<OperateCubePanel>();

        m_panel.m_btnMoveCube.onClick.AddListener(MoveCube);
        m_panel.m_btnClose.onClick.AddListener(Close);
	}

	protected override void InitEvent()
	{
        base.InitEvent();

        m_interests = new string[] { EventCode.EventMoveCube.ToString() };
	}

    private void MoveCube()
    {
        EventMessage msg = new EventMessage(EventCode.EventMoveCube.ToString(), 
                                            new MsgBodyMoveCube(new Vector3(0,0,0)));
    
        TriggerEvent(msg);
    }

    private void Close()
    {
        EventMessage msg = new EventMessage(EventCode.ShowMainMenu.ToString(), null);

        TriggerEvent(msg);
    }
}
