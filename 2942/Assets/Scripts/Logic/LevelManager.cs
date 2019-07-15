using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviourSingleton<LevelManager>
{
    LevelData actualLevelData;

    int savedLevelThatComesFrom;

    void Start()
    {
        LevelData.PassLevelData = UpdateLevelData;
        UIMenuCanvas.PlayGame += GoToNextLevel;
        UIMenuCanvas.QuitGame = QuitGame;
        PlayerController.PlayerDeath = GoToGameOver;
    }

    void OnDestroy()
    {
        UIMenuCanvas.PlayGame -= GoToNextLevel;
    }

    void UpdateLevelData(LevelData levelData)
    {
        actualLevelData = levelData;
    }

    public int GetActualLevel()
    {
        return actualLevelData.level;
    }

    public int GetLevelThatComesFrom()
    {
        return savedLevelThatComesFrom;
    }

    public void GoToMenu()
    {
        LoaderManager.Get().LoadScene(0);
        savedLevelThatComesFrom = actualLevelData.level;
    }

    public void GoToNextLevel()
    {
        LoaderManager.Get().LoadScene(actualLevelData.nextLevel);
        savedLevelThatComesFrom = actualLevelData.level;
    }

    public void GoToGameOver()
    {
        LoaderManager.Get().LoadScene(3);
        savedLevelThatComesFrom = actualLevelData.level;
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
