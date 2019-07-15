using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonShipBehaviour : EnemyBehaviour
{
    GameObject player;
    float speed = 5f;
    bool switchSpeedLine = false;
    public float hasItem = 0;
    Animator a;

    void Start()
    {
        transform.position = new Vector3(Random.Range(CameraUtils.OrthographicBounds().min.x, CameraUtils.OrthographicBounds().max.x),
            CameraUtils.OrthographicBounds().max.y + 7f);
        name = "CommonEnemy";
        player = GameObject.Find("Player");
        a = GetComponent<Animator>();
        PlayerController.ExplodeBomb += BombEffect;
    }

    void OnDestroy()
    {
        PlayerController.ExplodeBomb -= BombEffect;
    }

    void Update()
    {
        if (player)
        {
            float range = speed * Time.deltaTime;

            bool samePosAsPlayer = (transform.position.x >= player.transform.position.x - range &&
                                    transform.position.x <= player.transform.position.x + range) &&
                                    (transform.position.y >= player.transform.position.y - range &&
                                    transform.position.y <= player.transform.position.y + range);

            if (!samePosAsPlayer)
            {
                if (!switchSpeedLine)
                {
                    AdjustPositionToPlayer(Vector3.down * speed);
                    switchSpeedLine = transform.position.y < CameraUtils.OrthographicBounds().max.y - 2.5f;
                    if (switchSpeedLine)
                    {
                        speed /= 2;
                    }
                }
                else if (switchSpeedLine)
                {
                    if (player.transform.position.x > transform.position.x)
                    {
                        AdjustPositionToPlayer(Vector3.right);
                    }
                    else if (player.transform.position.x < transform.position.x)
                    {
                        AdjustPositionToPlayer(Vector3.left);
                    }

                    if (player.transform.position.y > transform.position.y)
                    {
                        AdjustPositionToPlayer(Vector3.up * speed);
                    }
                    else if (player.transform.position.y < transform.position.y)
                    {
                        AdjustPositionToPlayer(Vector3.down * speed);
                    }
                }
            }
        }
    }

    void AdjustPositionToPlayer(Vector3 v)
    {
        transform.position += v*Time.deltaTime;
    }
}
