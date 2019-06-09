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
    Text livesText;
    Text scoreText;
    public bool gameOver = false;
   

    public bool changing = false;

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

    void Init()
    {
        
    }

    void Update()
    {
        
    }
}