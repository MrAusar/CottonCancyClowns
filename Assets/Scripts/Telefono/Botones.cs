using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botones : MonoBehaviour
{
    public GameObject button1;

    void Start()
    {
        // Initially, hide the button
        button1.SetActive(false);
    }

    void OnMouseDown()
    {
        // Check if the mouse click hits the object
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Toggle the visibility of the buttons
            button1.SetActive(!button1.activeSelf);
        }
    }
}