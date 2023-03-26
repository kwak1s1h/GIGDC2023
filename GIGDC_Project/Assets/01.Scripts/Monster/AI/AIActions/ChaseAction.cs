using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAction : AIAction
{
    private Vector3Int _beforeTargetPos = Vector3Int.zero;
    
    private Vector3 _nextPos;

    public override void TakeAction()
    {
        Debug.Log("Chase");

        Vector3Int targetPos = MapManager.Instance.GetTilePos(_brain.target.position);
        if(targetPos != _beforeTargetPos)
        {
            _brain.Agent.Destination = targetPos;
            _beforeTargetPos = targetPos;
            SetNextPos();
        }

        if(Vector3.Distance(_nextPos, transform.position) <= 0.2f)
        {
            SetNextPos();
        }

        _brain.Move((_nextPos - transform.position).normalized, true);
    }

    private void SetNextPos()
    {
        if(!_brain.Agent.CanMovePath)
        {
            _brain.Move(Vector3.zero, true);
            _nextPos = transform.position;
        }
        else
        {
            _nextPos = MapManager.Instance.GetWorldPos(_brain.Agent.GetNextTarget());
        }
    }
}
