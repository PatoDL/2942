using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameCanvas : MonoBehaviour
{
    public GameObject energyBarImage;
    public GameObject[] bombImage;
    public Text scoreText;
    public int bombAmount;

    void Start()
    {
        bombAmount = bombImage.Length;
        PlayerController.ModifyEnergyBar = UpdateEnergyBar;
        PlayerController.UpdateUIBombAmount = UpdateBombsImages;
        EnemyBehaviour.AddScore += ModifyScore;
        scoreText.text = "" + GameManager.Get().GetScore();
    }

    void OnDestroy()
    {
        EnemyBehaviour.AddScore -= ModifyScore;
    }

    void ModifyScore()
    {
        scoreText.text = ""+GameManager.Get().GetScore();
    }

    void UpdateEnergyBar(float xScale)
    {
        energyBarImage.transform.localScale = new Vector3(xScale, 0.2369064f);
    }

    void UpdateBombsImages()
    {
        bombImage[bombAmount - 1].SetActive(false);
        bombAmount--;
    }
}
