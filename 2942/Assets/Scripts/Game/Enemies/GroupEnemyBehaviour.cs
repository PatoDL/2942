using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupEnemyBehaviour : EnemyBehaviour
{
    float xWide = 0.2f;
    float ySpeed = 3f;
    float timer = 0f;
    float xSpeed = 5f;
    public float xSetted = 1.5f;

    void Start()
    {
        transform.position = new Vector3(0,
            CameraUtils.OrthographicBounds().max.y + 7f);
        name = "GroupEnemy";
        PlayerController.ExplodeBomb += BombEffect;
    }

    void OnDestroy()
    {
        PlayerController.ExplodeBomb -= BombEffect;
    }

    void Update()
    {
        timer += Time.deltaTime;
        transform.position = new Vector3(xSetted + Mathf.Sin(timer*xSpeed)*xWide,transform.position.y);
        transform.position += Vector3.down * ySpeed*Time.deltaTime;

        if(transform.position.y < CameraUtils.OrthographicBounds().min.y)
        {
            transform.position = Vector3.up * (CameraUtils.OrthographicBounds().max.y + 7f);
        }
    }

   
}
