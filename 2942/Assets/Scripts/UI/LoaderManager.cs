﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoaderManager : MonoBehaviour
{
    public float loadingProgress;
    public float timeLoading;
    public float minTimeToLoad = 2;
    private static LoaderManager instance;

    private void Awake()
    {
        Init();
    }

    public static LoaderManager Instance
    {
        get { return instance; }
    }

    public void Init()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public static void Create()
    {
        instance = new LoaderManager();
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(AsynchronousLoad(sceneName));
    }

    IEnumerator AsynchronousLoad(string scene)
    {
        loadingProgress = 0;
        timeLoading = 0;
        yield return null;

        AsyncOperation ao = SceneManager.LoadSceneAsync(scene);
        ao.allowSceneActivation = false;

        while (!ao.isDone)
        {
            timeLoading += Time.deltaTime;
            loadingProgress = ao.progress + 0.1f;
            loadingProgress = loadingProgress * timeLoading / minTimeToLoad;

            if (loadingProgress >= 1)
            {
                ao.allowSceneActivation = true;
                if(SceneManager.GetActiveScene().name=="GameOver")
                    GameManager.Instance.changingScene = false;
            }

            yield return null;
        }
    }
}
