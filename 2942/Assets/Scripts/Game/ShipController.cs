using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        transform.position += Vector3.up * ver * speed * Time.deltaTime;
        transform.position += Vector3.right * hor * speed * Time.deltaTime;

        bool posMayorALimiteX = transform.position.x > CameraUtils.OrthographicBounds().max.x - this.transform.localScale.x / 3;
        bool posMenorALimiteX = transform.position.x < CameraUtils.OrthographicBounds().min.x + this.transform.localScale.x / 3;

        if (posMayorALimiteX)
            transform.position = new Vector3(CameraUtils.OrthographicBounds().max.x-this.transform.localScale.x/3,transform.position.y,transform.position.z);

        if (posMenorALimiteX)
            transform.position = new Vector3(CameraUtils.OrthographicBounds().min.x + this.transform.localScale.x / 3, transform.position.y, transform.position.z);

        bool posMayorALimiteY = transform.position.y > CameraUtils.OrthographicBounds().max.y - this.transform.localScale.y / 3;
        bool posMenorALimiteY = transform.position.y < CameraUtils.OrthographicBounds().min.y + this.transform.localScale.y / 3;

        if (posMayorALimiteY)
            transform.position = new Vector3(transform.position.x, CameraUtils.OrthographicBounds().max.y - this.transform.localScale.y / 3, transform.position.z);

        if (posMenorALimiteY)
            transform.position = new Vector3(transform.position.x, CameraUtils.OrthographicBounds().min.y + this.transform.localScale.y / 3, transform.position.z);
    }
}
