using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public enum ItemType
    {
        energy,
        shootBoost,
        last,
    }

    public GameObject energyItemPF;
    public GameObject shootBoostItemPF;
    GameObject[] items;

    float posibilityRatio = 3;

    // Start is called before the first frame update
    void Start()
    {
        items = new GameObject[(int)ItemType.last];
        items[(int)ItemType.energy] = energyItemPF;
        items[(int)ItemType.shootBoost] = shootBoostItemPF;
        EnemyBehaviour.SpawnItem = InstantiateItem;
    }

    void InstantiateItem(ItemType i, Vector3 pos, float posibility)
    {
        if(posibility<posibilityRatio)
        {
            GameObject g = Instantiate(items[(int)i]);
            g.transform.position = pos;
        }
    }
}
