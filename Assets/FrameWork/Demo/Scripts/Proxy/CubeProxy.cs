using ZW.MVCForUnity;
using System;
using UnityEngine;

public class CubeProxy : Proxy
{
    protected override void Awake()
	{
        base.Awake();
	}

	private void Start()
	{
        Facade.RegisterCommand(EventCode.EventMoveCube.ToString(), () => new MoveCubeCommand(this));
	}

    public void MoveTo(Vector3 targetPos)
    {
        transform.position = targetPos;
    }
}
