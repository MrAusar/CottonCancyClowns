using UnityEngine;
using UnityEngine.UI;

public class ToggleMovementButton : MonoBehaviour
{
    public AutoMove autoMoveScript; // Reference to the script controlling movement

    private Button button;

    void Start()
    {
        // Get the Button component on this GameObject
        button = GetComponent<Button>();

        // Attach the button click listener
        button.onClick.AddListener(ToggleMovement1);
    }

    void ToggleMovement1()
    {
        // Check if the AutoMove script is attached
        if (autoMoveScript != null)
        {
            // Call the CheckColliders method in the AutoMove scrip
            autoMoveScript.CheckColliders();
        }
        else
        {
            Debug.LogWarning("AutoMove script not attached to the ToggleMovementButton.");
        }
    }
}