using UnityEngine;

public class AppearThings : MonoBehaviour
{
    public GameObject objectToActivate; // Reference to the object to activate
    public AudioSource move;

    private void OnMouseDown()
    {
        // Check if the objectToActivate is not null
        if (objectToActivate != null)
        {
            // Activate the specified object
            objectToActivate.SetActive(true);
            move.Play();
        }
    }
}