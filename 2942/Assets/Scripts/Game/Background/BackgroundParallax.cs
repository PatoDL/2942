using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    [System.Serializable]
    public class ParallaxLayer
    {
        public GameObject layer;
        public float moveCameraRatioY = 0;
    }

    public ParallaxLayer[] layers;

    void Update()
    {
        foreach (ParallaxLayer layer in layers)
        {
            layer.layer.transform.position += Vector3.down * Time.deltaTime * layer.moveCameraRatioY;
            Vector3 screenPoint = Camera.main.WorldToViewportPoint(layer.layer.transform.position);
            bool onScreen = layer.layer.transform.position.y > -11.5f;
            if (!onScreen)
            {
                layer.layer.transform.position = new Vector3(0f, 12.1f, 0f);
            }
        }
    }
}