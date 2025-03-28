using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn : MonoBehaviour
{
    public GameObject[] objectsToToggle;

    void Start()
    {
        // Optional: Turn off objects at the start if you want them to be initially inactive.
        foreach (GameObject obj in objectsToToggle)
        {
            obj.SetActive(false);
        }
    }

    public void ToggleObjectsOnClick()
    {
        foreach (GameObject obj in objectsToToggle)
        {
            obj.SetActive(true);
        }
    }
}