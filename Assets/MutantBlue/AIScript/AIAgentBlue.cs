using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAgentBlue : MonoBehaviour
{
    public AIStateMachineBlue stateMachine;
    [Header("Начальное состояние")]
    public AiStateIdBlue initialState;
    [HideInInspector] public NavMeshAgent navMesh;
    [Header("Конфигурация")]
    public AiAgentConfigBlue config;
    [HideInInspector] public AIMutant_Blue mutant;
    [HideInInspector] public Transform playerTransform;
    [Header("Оружие")]
    public GameObject weapon;
    [HideInInspector] public WeaponIkBlue weaponIk;
    [HideInInspector] public Animator anim;
    [HideInInspector] public ActivateWeaponBlue activateWeaponBlue;
    [HideInInspector] public PatrullingBlue patrulling;
    public JumpAwayBlue jumpAwayBlue;


    void Start()
    {
        jumpAwayBlue = GetComponent<JumpAwayBlue>();
        patrulling = GetComponent<PatrullingBlue>();
        activateWeaponBlue = GetComponent<ActivateWeaponBlue>();
        weaponIk = GetComponent<WeaponIkBlue>();
        anim = GetComponent<Animator>();
        mutant = GetComponent<AIMutant_Blue>();
        navMesh = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        stateMachine = new AIStateMachineBlue(this);
        stateMachine.RegisterState(new AiChasePlayerStateBlue());
        stateMachine.RegisterState(new AiDeathStateBlue());
        stateMachine.RegisterState(new AiIdleStateBlue());
        stateMachine.RegisterState(new AiAttackStateBlue());
        stateMachine.RegisterState(new AiAttackWalkStateBlue());
        stateMachine.ChangeState(initialState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }
}
