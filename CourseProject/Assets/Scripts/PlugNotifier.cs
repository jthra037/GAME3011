using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlugNotifier : MonoBehaviour {

    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private Text timerText;
    [SerializeField] private int gameTimeSeconds;
    [SerializeField] private float waitTime = 5f;

    private void Start()
    {
        gameTimeSeconds = LockpickInfo.GameTime;
        StartCoroutine(GameTimer());

        gameOverUI.SetActive(false);
        GameInfo.GameOver += ActivateGameOverUI;
    }


    private void ActivateGameOverUI()
    {
        gameOverUI.SetActive(true);
        GameInfo.GameOver -= ActivateGameOverUI;
        StartCoroutine(WaitTimeAndChangeScenes());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            GameInfo.EndTheGame();
        }
    }

    private IEnumerator WaitTimeAndChangeScenes()
    {
        yield return new WaitForSeconds(waitTime);
        LockpickInfo.LoadNextScene();
    }

    private IEnumerator GameTimer()
    {
        while (gameTimeSeconds > 0)
        {
            timerText.text = (gameTimeSeconds / 60) + "." + (gameTimeSeconds % 60);
            yield return new WaitForSeconds(1);
            gameTimeSeconds--;
        }
        GameInfo.EndTheGame();
    }
}
