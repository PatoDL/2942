using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBehaviour : MonoBehaviour
{
    float speed = 15f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;

        bool posMayorALimiteY = transform.position.y > CameraUtils.OrthographicBounds().max.y;

        if (posMayorALimiteY)
            Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "CommonEnemy")
        {
            col.gameObject.GetComponent<CommonShipBehaviour>().Death();
        }
        else if(col.gameObject.name == "GroupEnemy")
        {
            col.gameObject.GetComponent<GroupEnemyBehaviour>().Death();
        }
        Destroy(gameObject);
    }
}
