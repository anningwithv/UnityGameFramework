using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZW.MVCForUnity;

public class MoveCubeCommand : Command 
{
    protected CubeProxy m_cube = null;

    public MoveCubeCommand(CubeProxy cube)
    {
        m_cube = cube;
    }

	public override void Execute(IEventMessage eventNode)
	{
        base.Execute(eventNode);

        MsgBodyMoveCube msgBody = (MsgBodyMoveCube)(eventNode.Body);

        m_cube.MoveTo(msgBody.targetPos);
	}
}
