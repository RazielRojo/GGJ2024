using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    public Text MoneyText;

    // Update is called once per frame
    void Update()
    {
        MoneyText.text = "$"+PlayerStates.Money.ToString();
    }
}
