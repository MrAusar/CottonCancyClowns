using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveItem : MonoBehaviour
{
    // Reference to the InventoryManager script
    public InventoryManager inventoryManager;

    private void Start()
    {
        // Ensure that the InventoryManager script is assigned
        if (inventoryManager == null)
        {
            Debug.LogError("InventoryManager is not assigned to RemoveItem script!");
            // Disable the script to prevent errors
            enabled = false;
        }
    }

    private void Update()
    {
        // Check for left-click
        if (Input.GetMouseButtonDown(0))
        {
            // Raycast to detect the object clicked
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Check if the clicked object has this script attached
                if (hit.collider.gameObject == gameObject)
                {
                    // Remove the item from the inventory
                    // inventoryManager.RemoveItem();
                    inventoryManager.dropItem();
                }
            }
        }
    }
}