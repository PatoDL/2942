using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameOverCanvas : UIMenuCanvas
{
    public Text resultText;
    public Text scoreText;
    public Text highScoreText;

    void Start()
    {
        resultText.text = GameManager.Get().GetResult();
        scoreText.text = "Final Score: " + GameManager.Get().GetScore();
        highScoreText.text = "Your HighScore Was: " + PlayerPrefs.GetInt("HighScore");
    }
}
