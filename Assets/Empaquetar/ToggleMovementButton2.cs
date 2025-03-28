using UnityEngine;
using UnityEngine.UI;

public class ToggleMovementButton2 : MonoBehaviour
{
    public AutoMove2 autoMoveScript; // Reference to the script controlling movement

    private Button button;

    void Start()
    {
        // Get the Button component on this GameObjecs
        button = GetComponent<Button>();

        // Attach the button click listener
        button.onClick.AddListener(ToggleMovement2);
    }

    void ToggleMovement2()
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