using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LockpickInfo
{
    public static bool Successful = false;
    public static DifficultyOptions Difficulty;

    public enum DifficultyOptions
    {
        Easy = 0, Med = 1, Hard = 2
    };

    public static float Tolerance
    {
        get
        {
            return 0.09f - ((int)Difficulty * 0.015f);
        }
    }

    public static void LoadSceneByIndex(int idx)
    {
        SceneManager.LoadScene(idx);
    }

    public static void LoadNextScene()
    {
        SceneManager.LoadScene(
            (SceneManager.GetActiveScene().buildIndex + 1) % 
            SceneManager.sceneCountInBuildSettings
            );
    }
}
