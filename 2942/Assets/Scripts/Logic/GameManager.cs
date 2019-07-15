using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    public int score;
    float levelTimer = 0f;
    public float levelTimeLimit = 80f;

    string result = "You Lost...";

    void Start()
    {
        EnemyBehaviour.AddScore += AddScore;
        PlayerController.PlayerDeath += PlayerLoseResult;
        PlayerController.PlayerDeath += UpdateHighScore;
        PlayerController.ExplodeBomb += AddScore;
        UIMenuCanvas.PlayGame += ResetScore;
    }

    void OnDestroy()
    {
        PlayerController.PlayerDeath -= PlayerLoseResult;
        PlayerController.PlayerDeath -= UpdateHighScore;
        PlayerController.ExplodeBomb -= AddScore;
        EnemyBehaviour.AddScore -= AddScore;
        UIMenuCanvas.PlayGame -= ResetScore;
    }

    void ResetScore()
    {
        score = 0;
    }

    void UpdateHighScore()
    {
        if(PlayerPrefs.HasKey("HighScore"))
        {
            if(PlayerPrefs.GetInt("HighScore")<score)
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    void Update()
    {
        if (LevelManager.Get().GetActualLevel() != 0 && LevelManager.Get().GetActualLevel() != 3)
        {
            bool survivedTheLevel = levelTimer >= levelTimeLimit;
            if (survivedTheLevel)
            {
                result = "You Survived!";
                LevelManager.Get().GoToNextLevel();
                UpdateHighScore();
                levelTimer = 0f;
            }
            levelTimer += Time.deltaTime;
        }
    }

    void PlayerLoseResult()
    {
        result = "You Lost...";
    }

    void AddScore()
    {
        score += 50;
    }

    public int GetScore()
    {
        return score;
    }

    public string GetResult()
    {
        return result;
    }
}