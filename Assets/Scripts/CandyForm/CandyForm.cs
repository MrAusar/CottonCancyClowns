using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public GameObject objectToActivate; // Reference to the object to activate

    private void OnMouseDown()
    {
        // Check if the objectToActivate is not null
        if (objectToActivate != null)
        {
            // Activate the specified object
            objectToActivate.SetActive(true);
        }
    }
}