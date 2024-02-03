using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations.Rigging;

public class JumpAwayBlue : MonoBehaviour
{
    Animator anim;
    [HideInInspector] public LayerMask playerMask;
    public Transform GetFacets;
    Transform rigth;
    Transform left;
    bool isJumpAway;
    public float radiusJump = 5f;
    public float directionJump;
    public float speed;
    public float speedUp;
    public AnimationCurve dodgeCurve;
    float dodgeTimer;

    public float timeDirection;
    float time;

    public bool isDodge;
    
    public Transform childTransform;

    AIAgentBlue agent;
    
    public bool dodgeFalse;
    public float rigthInt;
    public float leftInt;
    public bool one;
    void Start()
    {
        rigth = GetFacets.GetChild(0);
        left = GetFacets.GetChild(1);
        agent = GetComponent<AIAgentBlue>();
        anim = GetComponent<Animator>();
        playerMask = LayerMask.GetMask("Player"); 

        Keyframe dodge_lastFrame = dodgeCurve[dodgeCurve.length - 1];
        dodgeTimer = dodge_lastFrame.time;
        dodgeFalse = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dodgeFalse == false)
        {
            isJumpAway = Physics.CheckSphere(transform.position, radiusJump, playerMask);
            if (isJumpAway)
            {
                time = timeDirection;
                /*anim.SetTrigger("JumpAway");
                Vector3 jumpRight = transform.GetChild(0).transform.position;
                jumpRight.x -= Time.deltaTime * directionJump;
                jumpRight.y = transform.position.y;
                jumpRight.z = transform.position.z;
                transform.position = jumpRight;
                radiusJump = 0f;*/

                StartCoroutine(Dodge());
            }
            else
            {
                if (time < 0)
                {

                    radiusJump = 5f;

                }
            }
            if (time > 0)
            {
                time -= Time.deltaTime;
            }
            if (isDodge == false)
            {
                
                Vector3 rigthDirection = agent.playerTransform.position - rigth.transform.position;
                Vector3 leftDirection = agent.playerTransform.position - left.transform.position;
                rigthInt = rigthDirection.x * Time.deltaTime;
                leftInt = leftDirection.x * Time.deltaTime;
                /*if (rigthInt < leftInt)
                {
                    Vector3 f = new Vector3(0, 0, 0);
                    f.x = 11f;
                    childTransform.localPosition = f;
                }
                if(rigthInt > leftInt)
                {
                    Vector3 f = new Vector3(0, 0, 0);
                    f.x = -11f;
                    childTransform.localPosition = f;
                }*/
               
                    
                
                agent.weaponIk.isStopAim = false;
                agent.activateWeaponBlue.isStopFire = false;


            }
        }
        
    }
    IEnumerator Dodge()
    {
        if (one == false)
        {
            if (rigthInt > leftInt)
            {
                anim.SetTrigger("DodgeLeft");
                childTransform.SetParent(rigth);
                childTransform.localPosition = new Vector3(0, 0, 0);
                one = true;
            }
            else if (leftInt > rigthInt)
            {
                anim.SetTrigger("DodgeRigth");
                
                childTransform.SetParent(left);
                childTransform.localPosition = new Vector3(0, 0, 0);
                one = true;
            }
        }
        radiusJump = 0f;
    
        agent.activateWeaponBlue.fireActiv = false;
        

        agent.weaponIk.isStopAim = true;
        agent.activateWeaponBlue.isStopFire = true;
        
        isDodge = true;
        float timer = 0;
        while(timer < dodgeTimer)
        {
            float _speed = dodgeCurve.Evaluate(timer);
            
           
            childTransform.SetParent(transform.parent);
            /*agent.navMesh.stoppingDistance = 0f;
            agent.navMesh.speed = speed;
            
            if (dodgeFalse == false)
            {
                agent.navMesh.destination = childTransform.position;
            }*/
            transform.position = Vector3.MoveTowards(transform.position, Vector3.Lerp(transform.position, childTransform.position, speed), speedUp);
            timer += Time.deltaTime;
            yield return null;
        }
        isDodge = false;
        one = false;
        
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radiusJump);
    }
  
}
