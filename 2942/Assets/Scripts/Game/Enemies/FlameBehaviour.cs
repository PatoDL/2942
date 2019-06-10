using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameBehaviour : MonoBehaviour
{
    float timeForDisappear = 0f;
    // Update is called once per frame
    void Update()
    {
        timeForDisappear += Time.deltaTime;
        if(timeForDisappear>0.75f)
        {
            Destroy(gameObject);
        }
    }
}
