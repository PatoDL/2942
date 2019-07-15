using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenuCanvas : MonoBehaviour
{
    public delegate void OnPlayGame();
    public static OnPlayGame PlayGame;

    public delegate void OnGameQuit();
    public static OnGameQuit QuitGame;

    public void Play()
    {
        PlayGame();
    }

    public void Quit()
    {
        QuitGame();
    }
}
