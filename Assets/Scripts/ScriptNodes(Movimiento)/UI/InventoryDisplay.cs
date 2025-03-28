using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryDisplay : MonoBehaviour
{
    TMP_Text displayText;

    private void Start()
    {
        displayText = GetComponent<TMP_Text>();
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        string displayName;
        if (GameManager.ins.itemHeld != null)
        {
            displayName = GameManager.ins.itemHeld.itemName;
        }
        else 
            {
                displayName = "Ninguno: ";
            } 
        displayText.text = "Pista: " + displayName;
    }
}
