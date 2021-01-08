using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{


    Vector3 Dir;
    float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Dir * speed * Time.deltaTime;
    }

    public void Setup(Vector3 shootDir)
    {
        Dir = shootDir;

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit" + collision.gameObject.name);
    }
}
