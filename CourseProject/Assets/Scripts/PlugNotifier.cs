using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlugNotifier : MonoBehaviour {

    [SerializeField] private GameObject gameOverUI;

    private void Start()
    {
        gameOverUI.SetActive(false);
        GameInfo.GameOver += ActivateGameOverUI;
    }


    private void ActivateGameOverUI()
    {
        gameOverUI.SetActive(true);
        GameInfo.GameOver -= ActivateGameOverUI;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            GameInfo.EndTheGame();
        }
    }


}
