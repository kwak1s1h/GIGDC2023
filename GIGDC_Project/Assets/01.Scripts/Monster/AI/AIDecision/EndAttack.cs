using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAttack : AIDecision
{
    [SerializeField]
    private int _attackTypeIndex = 0;

    public override bool MakeADecision()
    {
        return !_brain._attackActions[_attackTypeIndex].IsDelay;
    }
}
