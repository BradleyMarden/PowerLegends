using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNewLevel : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    GameController GC;
    void Start()
    {
        GC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GC.LoadNewLevel(1);
            other.transform.position = new Vector3(4.05000019f, 0.79999976f, -7.6500001f);
            
        }
    }
}
