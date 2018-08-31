using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveText : MonoBehaviour {

    public TextMeshProUGUI waveText;

    private void Update()
    {
        waveText.text = "Wave: " + EnemySpawner.waveNumber;
    }
}
