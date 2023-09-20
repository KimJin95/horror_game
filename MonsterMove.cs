using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static MonsterState;

public class MonsterMove : MonoBehaviour
{

    Transform myTr;
    Transform playerTr;

    public Transform[] patrolPath;
    Transform currentTarget;
    int currentIndex = 0;

    NavMeshAgent agent;

    public GameObject GameOverUI;

    [Header("Speed")]
    [SerializeField] float chaseDist = 5f;
    [SerializeField] float chaseSpeed = 3f;
    [SerializeField] float moveSpeed = 1.5f;
    public float speedOffset = 4;

    [Header("Distance")]
    [SerializeField] float patroldist = 1f;
    [SerializeField] float playerdist = 5f;
    [SerializeField] float attackRange = 1.5f;

    [Header("Pause")]
    public float waitTime = 14f;
    private float waitTimer = 0f;
    public bool isWaiting = false;

    public bool isChasingPlayer = false;
    public bool isDamage = false;

    public float damageDelay = 10f;
    int M_AttackPower = 1;

    m_State currentState = m_State.Patrol;

    UIManager UIManager;
    Animator monsterAnim;
    SoundManager soundManager;

    [Header("DoorSound-------------")]
    Door_Open doors;

    private float distanceToPlayer_;
    AudioSource myaudio;
    public AudioClip footStepClip;

    bool speedUp;

    private void Start()
    {
        GameOverUI.SetActive(false);

        myTr = GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        currentTarget = patrolPath[currentIndex];

        playerTr = GameObject.FindWithTag("Player").transform;

        UIManager = GameObject.FindObjectOfType<UIManager>();
        monsterAnim = GetComponent<Animator>();
        doors = FindObjectOfType<Door_Open>();
        soundManager = FindObjectOfType<SoundManager>();
        myaudio = gameObject.GetComponent<AudioSource>();

    }

    private void Update()
    {
        // print("현재 상태 : " + currentState);

        switch (currentState)
        {
            case m_State.Patrol:
                PatrolBehavior();
                break;
            case m_State.Attack:
                AttackBehavior();
                break;
            default:
                break;
        }
    }


    private void PatrolBehavior()
    {
        float distanceToTarget = Vector3.Distance(transform.position, currentTarget.position); //a-b
        float distanceToPlayer = Vector3.Distance(transform.position, playerTr.position); //a-b

        monsterAnim.SetBool("IsMove", true);

        if (distanceToTarget <= patroldist)
        {
            currentIndex = (currentIndex + 1) % patrolPath.Length;
            currentTarget = patrolPath[currentIndex];

            isWaiting = true;
            waitTimer = 0;
        }

        //if (isWaiting)
        //{
        //    monsterAnim.SetBool("IsMove", false);
        //    waitTimer += Time.deltaTime;
        //    if (waitTimer >= waitTime)
        //    {
        //        monsterAnim.SetBool("IsMove", true);
        //        isWaiting = false;
        //    }
        //}

        if (distanceToPlayer <= playerdist && !Hide.isHide)
        {
            if (!speedUp)
            {
                monsterAnim.SetFloat("IsMoveSpeed", monsterAnim.GetFloat("IsMoveSpeed") + speedOffset);

                speedUp = true;
            }

            isChasingPlayer = true;
        }
        else
        {
            if (speedUp)
            {
                monsterAnim.SetFloat("IsMoveSpeed", monsterAnim.GetFloat("IsMoveSpeed") - speedOffset);
                speedUp = false;
            }
            isChasingPlayer = false;
        }

        if (isChasingPlayer)
        {

            agent.SetDestination(playerTr.position);

        }

        if (!isChasingPlayer)
        {
            //    if (!isWaiting)
            //  {
            agent.SetDestination(patrolPath[currentIndex].transform.position);
            // }
        }
    }

    private void ChaseSpeed()
    {
        monsterAnim.SetFloat("IsMoveSpeed", monsterAnim.GetFloat("IsMoveSpeed") + speedOffset);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentState = m_State.Attack;
        }

        if (other.gameObject == doors.Room1_Door)
        {
            doors.door1_Anim.SetTrigger("Open");
            soundManager.Door1Audio.Play();
        }
        else if (other.gameObject == doors.Room2_Door)
        {
            doors.door2_Anim.SetTrigger("Open");
            soundManager.Door2Audio.Play();
        }
        else if (other.gameObject == doors.Room3_Door)
        {
            doors.door3_Anim.SetTrigger("Open");
            soundManager.Door3Audio.Play();
        }
        else if (other.gameObject == doors.Room4_Door)
        {
            doors.door4_Anim.SetTrigger("Open");
            soundManager.Door4Audio.Play();
        }
    }

    private void AttackBehavior()
    {

        // Debug.Log("AttackBehavior");

        distanceToPlayer_ = Vector3.Distance(transform.position, playerTr.position);

        Debug.Log("distanceToPlayer_: " + distanceToPlayer_);

        if (!isDamage)
        {
            monsterAnim.SetTrigger("Attack");

            GameOverUI.SetActive(true);
            //PlayerState.playerHP -= M_AttackPower;
            //UIManager.TakeDamage();
            isDamage = true;


            //currentState = m_State.Patrol;
        }


        if (isDamage & damageDelay > 0)
        {
            damageDelay -= Time.deltaTime;

            if (damageDelay <= 0)
            {
                damageDelay = 10f;
                isDamage = false;
                currentState = m_State.Attack;
            }
        }

        if (distanceToPlayer_ > 40f)
        {
            currentState = m_State.Patrol;
        }
        else
        {
            agent.SetDestination(playerTr.transform.position);
        }
    }

    public void FootStep()
    {
        myaudio.Play();
    }


}
