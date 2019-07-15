using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject commonShip;
    public GameObject groupEnemy;
    public float commonEnemyTimer = 0f;
    public float groupEnemyTimer = 0f;
    public float groupEnemiesSpawnRatio = 0.2f;
    public float groupSpawnRatio = 10f;
    public int amountOfEnemiesToSpawn = 10;
    float groupXPos = 1.5f;

    void Update()
    {
        commonEnemyTimer += Time.deltaTime;
        groupEnemyTimer += Time.deltaTime;

        if (commonEnemyTimer > 2.5f)
        {
            GameObject cs = Instantiate(commonShip);
            commonEnemyTimer = 0f;
        }

        if(groupSpawnRatio<=0f)
        {
            groupSpawnRatio = 20f;
            amountOfEnemiesToSpawn = 10;
        }

        if(groupEnemyTimer> groupEnemiesSpawnRatio && amountOfEnemiesToSpawn>0)
        {
            GameObject ge = Instantiate(groupEnemy);
            ge.GetComponent<GroupEnemyBehaviour>().xSetted = groupXPos;
            groupXPos = -groupXPos;
            groupEnemyTimer = 0f;
            amountOfEnemiesToSpawn--;
        }
        else
        {
            groupSpawnRatio -= Time.deltaTime;
        }

    }
}
