using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowPush : MonoBehaviour
{
    public GameObject[] arrowKeys; // Assign the arrow key GameObjects in the Inspector
    private int currentArrowIndex = 0;

    private void Start()
    {
        // Ensure you have assigned the arrow key GameObjects in the Inspector.
        if (arrowKeys == null || arrowKeys.Length == 0)
        {
            Debug.LogError("Arrow key GameObjects not assigned.");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && currentArrowIndex < arrowKeys.Length && IsMatchingArrow(KeyCode.UpArrow))
        {
            Destroy(arrowKeys[currentArrowIndex]);
            currentArrowIndex++;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && currentArrowIndex < arrowKeys.Length && IsMatchingArrow(KeyCode.DownArrow))
        {
            Destroy(arrowKeys[currentArrowIndex]);
            currentArrowIndex++;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && currentArrowIndex < arrowKeys.Length && IsMatchingArrow(KeyCode.LeftArrow))
        {
            Destroy(arrowKeys[currentArrowIndex]);
            currentArrowIndex++;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && currentArrowIndex < arrowKeys.Length && IsMatchingArrow(KeyCode.RightArrow))
        {
            Destroy(arrowKeys[currentArrowIndex]);
            currentArrowIndex++;
        }

        if (currentArrowIndex == arrowKeys.Length)
        {
            Debug.Log("All arrow keys typed correctly!");
        }
    }

    private bool IsMatchingArrow(KeyCode keyCode)
    {
        return arrowKeys[currentArrowIndex].GetComponentInChildren<Text>().text.Contains(keyCode.ToString());
    }
}