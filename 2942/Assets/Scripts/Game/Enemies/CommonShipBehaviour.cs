using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonShipBehaviour : MonoBehaviour
{
    GameObject player;
    float speed = 5f;
    bool switchSpeedLine = false;
    public GameObject flame;
    public float hasItem = 0;

    public GameObject item;
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
        float trueSpeed = speed * Time.deltaTime;

        bool samePosAsPlayer = (transform.position.x >= player.transform.position.x - trueSpeed &&
                                transform.position.x <= player.transform.position.x + trueSpeed) &&
                                (transform.position.y >= player.transform.position.y - trueSpeed &&
                                transform.position.y <= player.transform.position.y + trueSpeed);

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

    void AdjustPositionToPlayer(Vector3 v)
    {
        transform.position += v*Time.deltaTime;
    }

    public void Death()
    {
        GameObject f = Instantiate(flame);
        f.transform.position = transform.position;
        if (hasItem > 0)
        {
            GameObject i = Instantiate(item);
            i.transform.position = transform.position;
        }
        Destroy(gameObject);
    }
}
