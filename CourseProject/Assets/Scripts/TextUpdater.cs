using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdater : MonoBehaviour
{
    [SerializeField] private Toggle toggleBox;
    [SerializeField] private Text toggleText;
    [SerializeField] private Text scansText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text extractionsText;
    [SerializeField] private Text tipsText;
    [SerializeField] private GameObject gameOverPanel;

    private void Update()
    {
        toggleBox.isOn = GameInfo.Scanning;
        toggleText.text = toggleBox.isOn ? "Scanning" : "Extracting";
        scansText.text = "Scans: " + GameInfo.Scans.ToString();
        extractionsText.text = "Extractions: " + GameInfo.Extractions.ToString();
        scoreText.text = "Score: " + GameInfo.Score.ToString();
        tipsText.text = GameInfo.Tip;

        if (!GameInfo.CanExtract)
        {
            GameInfo.TipIndex = 4;
            tipsText.text = GameInfo.Tip;

            gameOverPanel.SetActive(true);
            Destroy(this);
        }
    }
}
