using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject commonShip;
    float commonEnemyTimer = 0f;
    float groupEnemyTimer = 0f;
    public static List<GameObject> enemies = new List<GameObject>();
    public GameObject groupEnemy;
    public bool changeGroupStartPos = false;
    public float groupEnemiesSpawnRatio = 0.2f;
    public float groupSpawnRatio = 10f;
    public int amountOfEnemiesToSpawn = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        commonEnemyTimer += Time.deltaTime;
        groupEnemyTimer += Time.deltaTime;

        if (commonEnemyTimer > 2.5f)
        {
            GameObject cs = Instantiate(commonShip);
            cs.GetComponent<CommonShipBehaviour>().hasItem = Random.Range(0f, 1f);
            enemies.Add(cs);
            commonEnemyTimer = 0f;
        }

        float groupXPos;
        

        if(groupSpawnRatio<=0f)
        {
            groupSpawnRatio = 20f;
            amountOfEnemiesToSpawn = 10;
        }

        if(groupEnemyTimer> groupEnemiesSpawnRatio && amountOfEnemiesToSpawn>0)
        {
            GameObject ge = Instantiate(groupEnemy);
            ge.GetComponent<GroupEnemyBehaviour>().hasItem = Random.Range(0f, 1f);
            if (changeGroupStartPos)
            {
                groupXPos = 1.5f;
            }
            else
            {
                groupXPos = -1.5f;
            }
            ge.GetComponent<GroupEnemyBehaviour>().xSetted = groupXPos;
            enemies.Add(ge);
            changeGroupStartPos = !changeGroupStartPos;
            groupEnemyTimer = 0f;
            amountOfEnemiesToSpawn--;
        }
        else
        {
            groupSpawnRatio -= Time.deltaTime;
        }

    }
}
