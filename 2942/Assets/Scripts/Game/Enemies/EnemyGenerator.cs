using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject commonShip;
    float turnTimer = 0f;
    public static List<GameObject> enemies = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        turnTimer += Time.deltaTime;

        if (turnTimer > 2.5f)
        {
            GameObject cs = Instantiate(commonShip);
            enemies.Add(cs);
            turnTimer = 0f;
        }
    }
}
