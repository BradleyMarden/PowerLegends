using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiComponent : MonoBehaviour
{
    
    //inherited values, set in the child class
    protected enum EnemyState { IDLE, PATROLLING, DETECTING, ENGAGED}
    protected bool canMove = false;
    public float health = 100;
    protected float damage = 0;
    protected float movementSpeed = 0;
    protected float attackRange = 0;
    protected float detectRange = 4;
    protected float patrolRange = 7;
    protected EnemyState state;
   
    protected GameObject player;
    protected GameObject me;

    protected bool isDead = false;
    public bool IsEnemyDead() { return isDead; }

    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
       
    }

    // Update is called once per frame
    void Update()
    {
       
       
       

    }

    
    protected void SetState()
    {
        float playerDist = Vector3.Distance(transform.position, player.transform.position);
        if(playerDist > patrolRange)
        {
            state = EnemyState.PATROLLING;
        }

        else if(playerDist > detectRange && playerDist <= patrolRange) 
        {
            state = EnemyState.DETECTING;
        }
        else if (playerDist <= detectRange) 
        {
            state = EnemyState.ENGAGED;
           // MoveTowardsTarget(player.transform);
            transform.LookAt(player.transform);
            
        }
    }
    protected void DetectPlayer() 
    {
        switch (state)
        {

            case EnemyState.PATROLLING:
                {
                  
                    if (canMove)
                    Move();

                    break;
                }

            case EnemyState.DETECTING:
                {
                  

                    //StopLook();

                    break;
                }
            case EnemyState.ENGAGED:
                {
                  
                    
                    
                    break;
                }
            default: break;

        }
    }
    void Move()//moves the ai around in a generic area NOTE: FUNCTIONALY NOT IMPLEMENTED DO NOT SET canMove TO TRUE AS IT WILL NOT WORK!!
    {
        
    }

    void StopLook() //stops and look around, used when a player is detected.
    {
    
    }
    void MoveTowardsTarget(Transform target) //target has been spotted, move towards target
    {
        
        Vector3.Lerp(transform.position, target.transform.position, 1f);
    }

    
}
