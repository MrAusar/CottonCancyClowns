using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToggle : MonoBehaviour
{
    public GameObject prefabToToggle;

    private void Awake()
    {
        // Set the prefab to inactive by default.
        prefabToToggle.SetActive(false);
    }

    // Create a method to toggle the visibility of the prefab.
    public void TogglePrefabVisibility()
    {
        prefabToToggle.SetActive(!prefabToToggle.activeSelf);
    }
}
