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

    private void Update()
    {
        toggleBox.isOn = GameInfo.Scanning;
        toggleText.text = toggleBox.isOn ? "Scanning" : "Extracting";
        scansText.text = "Scans: " + GameInfo.Scans.ToString();
        scoreText.text = "Score: " + GameInfo.Score.ToString();
    }
}
