using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipController : MonoBehaviour
{
    float speed = 5f;
    public int bombAmount = 3;
    public GameObject fireball;
    public Text bombAmountText;

    public GameObject energyBarImage;
    float barModifier = 1f;

    // Start is called before the first frame update
    void Start()
    {
        bombAmountText.text = bombAmount.ToString();
        energyBarImage.transform.localScale = new Vector3(barModifier, energyBarImage.transform.localScale.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        move();
        if(Input.GetKeyUp(KeyCode.Z))
        {
            GameObject fb = Instantiate(fireball);
            fb.transform.position = transform.position;
        }
        if(Input.GetKeyUp(KeyCode.Space) && bombAmount>0)
        {
            foreach(GameObject e in EnemyGenerator.enemies)
            {
                if (e.gameObject != null)
                {
                    if (e.transform.position.y < CameraUtils.OrthographicBounds().max.y)
                    {
                        e.GetComponent<CommonShipBehaviour>().Death();
                    }
                }
            }
            bombAmount--;
            bombAmountText.text = bombAmount.ToString();
        }
        if(barModifier<=0f)
        {
            Destroy(gameObject);
        }
    }

    void move()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        transform.position += Vector3.up * ver * speed * Time.deltaTime;
        transform.position += Vector3.right * hor * speed * Time.deltaTime;

        bool posMayorALimiteX = transform.position.x > CameraUtils.OrthographicBounds().max.x - this.transform.localScale.x / 3;
        bool posMenorALimiteX = transform.position.x < CameraUtils.OrthographicBounds().min.x + this.transform.localScale.x / 3;

        if (posMayorALimiteX)
            transform.position = new Vector3(CameraUtils.OrthographicBounds().max.x - this.transform.localScale.x / 3, transform.position.y, transform.position.z);

        if (posMenorALimiteX)
            transform.position = new Vector3(CameraUtils.OrthographicBounds().min.x + this.transform.localScale.x / 3, transform.position.y, transform.position.z);

        bool posMayorALimiteY = transform.position.y > CameraUtils.OrthographicBounds().max.y - this.transform.localScale.y / 3;
        bool posMenorALimiteY = transform.position.y < CameraUtils.OrthographicBounds().min.y + this.transform.localScale.y / 3;

        if (posMayorALimiteY)
            transform.position = new Vector3(transform.position.x, CameraUtils.OrthographicBounds().max.y - this.transform.localScale.y / 3, transform.position.z);

        if (posMenorALimiteY)
            transform.position = new Vector3(transform.position.x, CameraUtils.OrthographicBounds().min.y + this.transform.localScale.y / 3, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "CommonEnemy")
        {
            barModifier -= 0.1f;
            energyBarImage.transform.localScale = new Vector3(barModifier, energyBarImage.transform.localScale.y, 0);
        }
    }
}