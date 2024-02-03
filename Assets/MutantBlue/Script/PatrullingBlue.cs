using Cinemachine.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrullingBlue : MonoBehaviour
{
    [Header("Позиция зоны патруля")]
    public Transform patrulZone;

    public float radiusEnemy;
    public bool _isAttack;
    public bool _isPointWalk;
    private Vector3 _pointWalk;

    private LayerMask _layerPlayer;
    private LayerMask _layerGround;
    

     public AIAgentBlue agent;
     public bool patrul;
     

    void Start()
    {
        agent = GetComponent<AIAgentBlue>();


        agent.config.RadiusAttackCurrent = agent.config.RadiusAttackStandart;

        _layerPlayer = LayerMask.GetMask("Player");
        _layerGround = LayerMask.GetMask("Ground");
       
        SetRandomWalkPoint();
    }


    public void FixedUpdate ()
    {
        _isAttack = Physics.CheckSphere(transform.position, agent.config.RadiusAttackCurrent, _layerPlayer);
        
        if (patrul)
        {
            if (_isAttack == true)
            {
               
                agent.config.RadiusAttackCurrent = agent.config.RadiusAttackPlayer;
                agent.navMesh.speed = agent.config.EnemyMaxSpeed;

                agent.stateMachine.ChangeState(AiStateIdBlue.ChasePlayer);
                
            }
            else
            {
                Pattrolling();

                agent.config.RadiusAttackCurrent = agent.config.RadiusAttackStandart;
                agent.navMesh.speed = agent.config.EnemySpeed;

            }
        }
        

    }



    private void Pattrolling()
    {
        if (_isPointWalk == true)
        {
            agent.navMesh.SetDestination(_pointWalk);

            if (Vector3.Distance(transform.position, _pointWalk) < 1)
            {
                _isPointWalk = false;
            }
        }
        else
        {
            SetRandomWalkPoint();
        }
    }

    private void SetRandomWalkPoint()
    {
        float ranX = Random.Range(-agent.config.RadiusWalk, agent.config.RadiusWalk);
        float ranZ = Random.Range(-agent.config.RadiusWalk, agent.config.RadiusWalk);

        _pointWalk = new Vector3(patrulZone.position.x + ranX, patrulZone.position.y, patrulZone.position.z + ranZ);

        Collider[] colliders = Physics.OverlapSphere(_pointWalk, 1);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].tag == "Wall")
            {
                _isPointWalk = false;
                return;
            }
        }

       
        _isPointWalk = true;
        
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, agent.config.RadiusAttackStandart);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, agent.config.RadiusAttackCurrent);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(patrulZone.position, agent.config.RadiusWalk);

        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(_pointWalk, 1);
    }
 
}
