using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : AiComponent
{
    // Start is called before the first frame update
    void Start()
    {
        damage = 20;
        movementSpeed = 4;
        canMove = false;
        detectRange = 4;
        patrolRange = 7;
        state = EnemyState.PATROLLING;

        me = this.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        SetState();
        DetectPlayer();
    }

    public bool DealDamage(float damageToDeal)
    {

        if (health != 0)
        {
            health -= damageToDeal;
            Debug.Log("DAMAGE DEALT! HP REMAINING: " + health);
            
            if(health == 0) 
            {
                OnDead();
                return false;
            }
            return true;
        }
        else
        {
            OnDead();
            return false;
        }
        
    }
    void OnDead()
    {
        isDead = true;
        Debug.Log("Killing");
        //deal with death
        Destroy(this);

    }

}
