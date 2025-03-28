using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public AutoMove autoMoveScript; // Reference to the AutoMove script

    void Start()
    {
        // Find the Button component on this GameObject
        Button button = GetComponent<Button>();

        // Add a listener for the button click event
       // button.onClick.AddListener(ToggleMovement);
    }

}
