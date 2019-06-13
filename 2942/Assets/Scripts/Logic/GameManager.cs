using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    GameObject canvas;
    float levelTimer = 0f;
    Text scoreText;
    bool gameOver = false;
    public GameObject player;
    public bool changingScene = false;

    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level1" || SceneManager.GetActiveScene().name == "Level2")
        {
            levelTimer += Time.deltaTime;
            if (levelTimer >= 120f)
            {
                levelTimer = 0f;
                if (SceneManager.GetActiveScene().name == "Level1")
                    LoaderManager.Instance.LoadScene("Level2");
                else
                    SceneManager.LoadScene("GameOver");
            }
        }

        if (UIGameOverCanvas.playAgain)
        {
            UIGameOverCanvas.playAgain = false;
            SceneManager.LoadScene("Level1");
        }
    }

    public void setGameOver(bool g)
    {
        gameOver = g;
        if (gameOver)
        {
            gameOver = false;
            SceneManager.LoadScene("GameOver");
        }
    }

    void Init()
    {
        
    }
}