using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSource : MonoBehaviour {

    private Player player;
    private Light lightTorch;

    private void Start()
    {
        player = GetComponentInParent<Player>();

        lightTorch = GetComponent<Light>();
    }

    private void Update()
    {
        UpdateRange();
    }

    private void UpdateRange()
    {
        lightTorch.range = player.lightRange;
    }
}
