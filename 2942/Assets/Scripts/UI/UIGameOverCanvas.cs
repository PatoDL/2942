﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameOverCanvas : MonoBehaviour
{
    Button playAgainButton;
    Button quitButton;
    public static Text score;
    public static Text highScore;
    public static bool playAgain = false;
    void Start()
    {
        playAgainButton = transform.Find("Panel").Find("PlayAgainButton").GetComponent<Button>();
        quitButton = transform.Find("Panel").Find("QuitButton").GetComponent<Button>();
        playAgainButton.onClick.AddListener(PlayAgain);
        quitButton.onClick.AddListener(UIMenuCanvas.Quit);
        score = transform.Find("Panel").Find("Score").GetComponent<Text>();
        highScore = transform.Find("Panel").Find("HighScore").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayAgain()
    {
        playAgain = true;
    }
}