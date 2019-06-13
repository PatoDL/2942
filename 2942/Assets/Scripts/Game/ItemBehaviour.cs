using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{ 
    public Sprite energySprite;
    public Sprite shootSprite;
    float timer;
    public enum ItemType
    {
        energy,
        shootBoost
    }

    public ItemType itemType;

    void Start()
    {
        name = "Item";
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        itemType = (ItemType)Random.Range(0, 2);
        Vector2 collsize = GetComponent<BoxCollider2D>().size;
        switch (itemType)
        {
            case ItemType.energy:
                sr.sprite = energySprite;
                sr.transform.localScale /= 5;
                break;
            case ItemType.shootBoost:
                sr.sprite = shootSprite;
                sr.transform.localScale *= 5;
                GetComponent<BoxCollider2D>().size = collsize/25;
                break;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3f)
            Destroy(gameObject);
    }
}
