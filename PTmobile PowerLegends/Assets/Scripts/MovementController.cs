using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField]
    float m_MoveSpeed;
    [SerializeField]
    float m_RotateSpeed;
    [SerializeField]
    FixedJoystick joystick;
    [SerializeField]
    Cinemachine.CinemachineVirtualCamera cam;

    bool isAttacking = false;

    float dist;
    [SerializeField]
    GameController GC;

    [SerializeField]
    float attackDistance;

    bool isMoving = false;

    [SerializeField]
    GameObject projectile;

    [SerializeField]
    Transform projectileSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //MovePlayer();

        rb.velocity = new Vector3(joystick.Horizontal * m_MoveSpeed, rb.velocity.y, joystick.Vertical * m_MoveSpeed);
        if (joystick.Horizontal != 0f || joystick.Vertical != 0f) 
        {
            //walking
            isMoving = true;
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
        else
        {
            isMoving = false;
           
            //algorithm to detect if enemy is nearby
            if (!isAttacking) 
            {
                isAttacking = true;
                StartCoroutine(attack(1f));
            }
           
            

            

            //NOT WALKING
        }
    }
    IEnumerator attack(float delayTime) 
    {

        yield return new WaitForSeconds(delayTime);

        Debug.Log("Start attack couroutine");
        GameObject tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject t in GC.enemysSpawnedOnLevel)//gets closest enemy
        {
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        
        if (tMin != null && !isMoving)// && Vector3.Distance(tMin.transform.position, transform.position) <= attackDistance && !isMoving )
        {

            //shoot
            /*
                tMin.GetComponent<Warrior>().DealDamage(10);
                 Debug.Log("damage sent from player");


            if (!tMin.GetComponent<Warrior>().IsEnemyDead())
            {//check enemy is alive

            }
            else 
            {
                Debug.Log("enemy is dead");

            }
            */

            //shoot projectile
            shoot(tMin.transform.position);
        }
        StartCoroutine(attack(1f));

    }

    void shoot(Vector3 enemyPos) 
    {
        if(projectile == null)
        {
            Debug.LogError("No Proejectile set.");
            return;
        }

       GameObject spawnedBullet =  Instantiate(projectile, projectileSpawnPoint.position, Quaternion.identity);
        Vector3 shootDir = (enemyPos - projectileSpawnPoint.position).normalized;
        spawnedBullet.GetComponent<Projectile>().Setup(shootDir);

      

    }

    void MovePlayer() 
    {
       
        if (joystick.Direction.y > 0) //forward
        {
            if (joystick.Direction.x > 0)//forward right
            {
                rb.velocity = (transform.right * joystick.Horizontal * m_MoveSpeed) + (transform.forward * joystick.Vertical * m_MoveSpeed);
               // transform.forward = (transform.right * joystick.Horizontal);

            }
            else if (joystick.Direction.x < 0)//forward left
            {
                rb.velocity = (-transform.right * -joystick.Horizontal * m_MoveSpeed) + (transform.forward * joystick.Vertical * m_MoveSpeed);
               // transform.forward = (-transform.right * -joystick.Horizontal);
            }
            else//foward
            {
                rb.velocity = transform.forward * joystick.Vertical * m_MoveSpeed;
                //transform.forward = (transform.forward * joystick.Vertical);
            }

        }
       if (joystick.Direction.y < 0)//backwards
        {
            if (joystick.Direction.x > 0)//backwards and right
            {
                rb.velocity = (transform.right * joystick.Horizontal * m_MoveSpeed) + (-transform.forward * -joystick.Vertical * m_MoveSpeed);

            }
            else if (joystick.Direction.x < 0)//backwards and left
            {
                rb.velocity = (-transform.right * -joystick.Horizontal * m_MoveSpeed) + (-transform.forward * -joystick.Vertical * m_MoveSpeed);
            }
            else//backwards
            {
                rb.velocity = -transform.forward * -joystick.Vertical * m_MoveSpeed;

            }
        }

    }
}
