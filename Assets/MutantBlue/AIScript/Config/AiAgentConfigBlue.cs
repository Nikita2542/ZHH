using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AiAgentConfigBlue : ScriptableObject
{
    public float maxTime = 1f;
    public float maxDistance = 1f;
    public float maxSightDistance = 5f;
    public float maxDistancePlayer = 50f;

    public float RadiusAttackPlayer;
    public float RadiusAttackStandart;
    public float RadiusAttackCurrent;
    public float RadiusWalk;

    public float EnemySpeed;
    public float EnemyMaxSpeed;

    public float attackTimeWalk = 1f;
    public float radiusWalkAttack = 2f;
}
