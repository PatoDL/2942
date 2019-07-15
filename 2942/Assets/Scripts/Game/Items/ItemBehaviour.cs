using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    public ItemManager.ItemType type;

    float duration;

    public delegate void OnExtraEnergyActivation();
    public static OnExtraEnergyActivation ActivateExtraEnergy;

    public delegate void OnShootBoostActivation();
    public static OnShootBoostActivation ActivateShootBoost;

    void Start()
    {
        duration = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (duration > 2.5f)
        {
            Destroy(gameObject);
        }
        duration += Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag=="Player")
        {
            ActivateEffect();
            Destroy(gameObject);
        }
    }

    public void ActivateEffect()
    {
        switch (type)
        {
            case ItemManager.ItemType.energy:
                ActivateExtraEnergy();
                break;
            case ItemManager.ItemType.shootBoost:
                ActivateShootBoost();
                break;
        }
    }
}
