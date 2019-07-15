using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public delegate void OnScoreAdded();
    public static OnScoreAdded AddScore;

    public delegate void OnItemSpawn(ItemManager.ItemType i, Vector3 pos, float posibility);
    public static OnItemSpawn SpawnItem;

    public GameObject flame;

    void Death()
    {
        AddScore();
        GameObject f = Instantiate(flame);
        f.transform.position = transform.position;
        SpawnItem((ItemManager.ItemType)Random.Range(0, (int)ItemManager.ItemType.last), transform.position, Random.Range(0, 10));
        Destroy(gameObject);
    }

    public void BombEffect()
    {
        Vector3 pos = transform.position;
        Vector3 scale = transform.localScale;
        Bounds b = CameraUtils.OrthographicBounds();
        bool inBounds = pos.x < b.max.x - scale.x/3 &&
                        pos.x>b.min.x+scale.x/3 &&
                        pos.y<b.max.y-scale.y/3 &&
                        pos.y > b.min.y + scale.y / 3;

        if(inBounds)
        {
            Death();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.tag=="Bullet")
        {
            Death();
        }
    }
}
