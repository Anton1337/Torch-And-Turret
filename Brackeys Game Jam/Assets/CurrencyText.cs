using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CurrencyText : MonoBehaviour {

    public TextMeshProUGUI amountText;

    private void Update()
    {
        amountText.text = "Gold: " + Shop.goldAmount;
    }
}
