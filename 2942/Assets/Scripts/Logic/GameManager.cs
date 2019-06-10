using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    int timer = 0;
    GameObject canvas;
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

    public void setGameOver(bool g)
    {
        gameOver = g;
        if (gameOver)
        {
            UILoadingScreen.Instance.SetVisible(true);
            LoaderManager.Instance.LoadScene("GameOver");
        }
    }

    void Init()
    {
        
    }

    void Update()
    {
        
    }
}