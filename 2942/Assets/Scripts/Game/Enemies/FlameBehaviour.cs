using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameBehaviour : MonoBehaviour
{
    float timeForDisappear = 0.75f;
    float duration = 0f;

    void Update()
    {
        duration += Time.deltaTime;
        if(duration>timeForDisappear)
        {
            Destroy(gameObject);
        }
    }
}
