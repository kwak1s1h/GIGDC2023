using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "SO/Agent/MonsterMove")]
public class MonsterAgentMoveSO : ScriptableObject
{
    public float speed = 5;
    [Range(0.1f, 10f)] public float maxSpeed = 10f;

}
