using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonShipBehaviour : MonoBehaviour
{
    GameObject player;
    float speed = 5f;
    bool switchSpeedLine = false;
    public GameObject flame;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(CameraUtils.OrthographicBounds().min.x, CameraUtils.OrthographicBounds().max.x),
            CameraUtils.OrthographicBounds().max.y + 7f);
        name = "CommonEnemy";
        player = GameObject.Find("Ship");
    }

    // Update is called once per frame
    void Update()
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
        else if(switchSpeedLine)
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

    void AdjustPositionToPlayer(Vector3 v)
    {
        transform.position += v*Time.deltaTime;
    }

    public void Death()
    {
        GameObject f = Instantiate(flame);
        f.transform.position = transform.position;
     //   EnemyGenerator.enemies.Remove(gameObject);
        Destroy(gameObject);
    }
}
