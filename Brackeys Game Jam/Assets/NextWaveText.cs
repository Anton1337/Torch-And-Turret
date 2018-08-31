using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NextWaveText : MonoBehaviour {

    public TextMeshProUGUI text;

    public GameObject textObject;

    private float slowFlashTime = 0.1f;
    private float fastFlashTime = 1.0f;

    //private EnemySpawner spawner;

    private void Start()
    {
        textObject.SetActive(false);
       // spawner = GetComponent<EnemySpawner>();
    }

    private void Update()
    {
        text.text = "Wave " + EnemySpawner.waveNumber + " Cleared!";
        
        if(EnemySpawner.showText)
        {
            textObject.SetActive(true);
        }
        else
        {
            textObject.SetActive(false);
        }
    }

}
