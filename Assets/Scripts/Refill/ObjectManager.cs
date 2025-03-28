using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    private ObjectHover firstObject;
    private ObjectHover secondObject;

    private void Start()
    {
        // Find the first object in the scene
        firstObject = FindObjectOfType<ObjectHover>();

        // Find the second object in the scene
        ObjectHover[] objectHovers = FindObjectsOfType<ObjectHover>();
        foreach (var obj in objectHovers)
        {
            if (obj != firstObject)
            {
                secondObject = obj;
                break;
            }
        }
    }

    // This method is called when the first object loses percentage
    public void FirstObjectLostPercentage()
    {
        // Subtract percentage from the second object
        if (secondObject != null)
        {
            secondObject.SubtractPercentage(20);

            // Allow the second object to refill when holding "R"
            secondObject.SetCanRefill(true);
        }
    }
}