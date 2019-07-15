using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    float speed = 5f;
    public int bombAmount = 3;
    public GameObject fireBullet;

    bool shootPowerUp = false;
    float shootPowerUpTimer = 0f;

    public float energy;

    float shootTimer = 0f;

    public delegate void OnPlayerDeath();
    public static OnPlayerDeath PlayerDeath;

    public delegate void OnBombExplode();
    public static OnBombExplode ExplodeBomb;

    public delegate void OnEnergyBarModification(float s);
    public static OnEnergyBarModification ModifyEnergyBar;

    public delegate void OnBombAmountUpdate();
    public static OnBombAmountUpdate UpdateUIBombAmount;

    void Start()
    {
        energy = 1f;
        ItemBehaviour.ActivateExtraEnergy = ActivateExtraEnergy;
        ItemBehaviour.ActivateShootBoost = ActivateShootBoost;
    }


    void Update()
    {
        shootTimer += Time.deltaTime;
        Move();
        InputCheck();
        if(shootPowerUp)
        {
            shootPowerUpTimer += Time.deltaTime;
            if (shootPowerUpTimer > 10f)
            {
                shootPowerUp = false;
                shootPowerUpTimer = 0f;
            }
        }
    }

    void Move()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        float speedV = speed * Time.deltaTime;
        Vector3 pos = transform.position + Vector3.up * ver * speedV + Vector3.right * hor * speedV;
        Vector3 scale = transform.localScale;
        Bounds bounds = CameraUtils.OrthographicBounds();

        bool posMayorALimiteX = pos.x > bounds.max.x - scale.x / 3;
        bool posMenorALimiteX = pos.x < bounds.min.x + scale.x / 3;

        if(posMayorALimiteX)
            pos.x = bounds.max.x - scale.x / 3;
        if(posMenorALimiteX)
            pos.x = bounds.min.x + scale.x / 3;

        bool posMayorALimiteY = pos.y > bounds.max.y - scale.y / 3;
        bool posMenorALimiteY = pos.y < bounds.min.y + scale.y / 3;

        if(posMayorALimiteY)
            pos.y = bounds.max.y - scale.y / 3;
        if (posMenorALimiteY)
            pos.y = bounds.min.y + scale.y / 3;

        transform.position = pos;
    }

    void PlayerHitByEnemy()
    {
        energy -= 0.01f;
        ModifyEnergyBar(energy);
        if (energy <= 0)
        {
            PlayerDeath();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag=="Enemy")
        {
            PlayerHitByEnemy();
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            PlayerHitByEnemy();
        }
    }

    void InputCheck()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            float shootRateTime = 0.1f;
            if (shootTimer > shootRateTime)
            {
                if (shootPowerUp)
                {
                    GameObject fb = Instantiate(fireBullet);
                    fb.transform.position = transform.position + Vector3.right / 2;
                    GameObject fb2 = Instantiate(fireBullet);
                    fb2.transform.position = transform.position + Vector3.left / 2;
                }
                else
                {
                    GameObject fb = Instantiate(fireBullet);
                    fb.transform.position = transform.position;
                }
                shootTimer = 0f;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space) && bombAmount > 0)
        {
            ExplodeBomb();
            UpdateUIBombAmount();
            bombAmount--;
        }
    }

    void ActivateExtraEnergy()
    {
        energy += 0.1f;
        if (energy > 1f)
            energy = 1f;
        ModifyEnergyBar(energy);
    }

    void ActivateShootBoost()
    {
        if (!shootPowerUp)
            shootPowerUp = true;
        shootPowerUpTimer = 0f;
            
    }
}