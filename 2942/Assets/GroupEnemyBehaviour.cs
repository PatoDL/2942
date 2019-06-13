using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupEnemyBehaviour : MonoBehaviour
{
    float xWide = 0.2f;
    float ySpeed = 3f;
    float timer = 0f;
    float xSpeed = 5f;
    public float xSetted = 1.5f;
    public GameObject flame;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0,
            CameraUtils.OrthographicBounds().max.y + 7f);
        name = "GroupEnemy";
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.position = new Vector3(xSetted + Mathf.Sin(timer*xSpeed)*xWide,transform.position.y);
        transform.position += Vector3.down * ySpeed*Time.deltaTime;

        if(transform.position.y < CameraUtils.OrthographicBounds().min.y)
        {
            transform.position += Vector3.up * (CameraUtils.OrthographicBounds().max.y + 7f);
        }
    }

    public void Death()
    {
        GameObject f = Instantiate(flame);
        f.transform.position = transform.position;
        Destroy(gameObject);
    }
}
