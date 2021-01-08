using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    List<GameObject> levels = new List<GameObject>();
    GameObject curLevel;
    [SerializeField]
    public List<GameObject> enemysSpawnedOnLevel = new List<GameObject>();
    void Start()
    {
        LoadNewLevel(0);

        //load player prefs
    }

    void LeavingForMenu() 
    {
        //SaveDuringPlay player prefs 
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNewLevel(int levelNum) 
    {
        Destroy(curLevel);
        curLevel = Instantiate(levels[levelNum], new Vector3(0, 0, 0), new Quaternion(0, 0, 0,0));
        enemysSpawnedOnLevel = curLevel.GetComponent<LevelController>().enemies;

    }
}
