using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipController : MonoBehaviour
{
    float speed = 5f;
    public int bombAmount = 3;
    public GameObject fireball;

    bool shootPowerUp = false;
    float shootPowerUpTimer = 0f;

    public GameObject energyBarImage;
    float energy = 1f;

    // Start is called before the first frame update
    void Awake()
    {
        energy = 1f;
    }

    void Start()
    {
        energyBarImage.transform.localScale = new Vector3(energy, energyBarImage.transform.localScale.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        InputCheck();
        if(energy<=0f && !GameManager.Instance.changingScene)
        {
            GameManager.Instance.setGameOver(true);
        }
        if(shootPowerUp)
        {
            shootPowerUpTimer += Time.deltaTime;
        }
        if(shootPowerUpTimer>10f)
        {
            shootPowerUp = false;
            shootPowerUpTimer = 0f;
        }
    }

    void Move()
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
            energy -= 0.1f;
            energyBarImage.transform.localScale = new Vector3(energy, energyBarImage.transform.localScale.y, 0);
        }
        if(col.gameObject.name=="Item")
        {
            switch(col.gameObject.GetComponent<ItemBehaviour>().itemType)
            {
                case ItemBehaviour.ItemType.energy:
                    if (energy < 1f)
                    {
                        energy += 0.1f;
                        energyBarImage.transform.localScale = new Vector3(energy, energyBarImage.transform.localScale.y, 0);
                    }
                    break;
                case ItemBehaviour.ItemType.shootBoost:
                    if (shootPowerUp)
                    {
                        shootPowerUpTimer = 0f;
                    }
                    else
                        shootPowerUp = true;
                    break;
            }
            Destroy(col.gameObject);
        }
    }

    void InputCheck()
    {
        if (Input.GetKey(KeyCode.Z) || Input.GetKeyDown(KeyCode.Z))
        {
            if (shootPowerUp)
            {
                GameObject fb = Instantiate(fireball);
                fb.transform.position = transform.position + Vector3.right / 2;
                GameObject fb2 = Instantiate(fireball);
                fb2.transform.position = transform.position + Vector3.left / 2;
            }
            else
            {
                GameObject fb = Instantiate(fireball);
                fb.transform.position = transform.position;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space) && bombAmount > 0)
        {
            foreach (GameObject e in EnemyGenerator.enemies)
            {
                if (e.gameObject != null)
                {
                    if (e.transform.position.y < CameraUtils.OrthographicBounds().max.y)
                    {
                        if (e.name == "CommonEnemy")
                            e.GetComponent<CommonShipBehaviour>().Death();
                        else if (e.name == "GroupEnemy")
                            e.GetComponent<GroupEnemyBehaviour>().Death();
                    }
                }
            }
            bombAmount--;
        }
    }
}