using TMPro;
using UnityEngine;
using UnityEngine.UI; // Import the UI namespace

public class ArrowGood : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    public Canvas targetCanvas;
    public Button myButton; // Reference to the button you want to enable
    private int arrowYesCounter = 0;
    private int maxCounter = 10;
    public float baseSpeed = 2.0f;
    public float speedIncreaseFactor = 0.5f;

    public float BaseSpeed
    {
        get { return baseSpeed; }
    }

    void Start()
    {
        // Set the initial speed of the arrow
        AutoMove2 autoMoveScript = GetComponent<AutoMove2>();
        if (autoMoveScript != null)
        {
            autoMoveScript.SetSpeed(BaseSpeed);
        }

        // Disable the button at the start
        if (myButton != null)
        {
            myButton.gameObject.SetActive(false);
        }
    }

    public void IncreaseArrowYesCounter()
    {
        arrowYesCounter++;

        // Ensure the counter does not exceed the maximum value
        arrowYesCounter = Mathf.Clamp(arrowYesCounter, 0, maxCounter);

        // Update the TextMeshProUGUI text
        counterText.text = arrowYesCounter + " / " + maxCounter;

        // Check if the counter has reached 10 before adjusting the speed and turning on the button
        if (arrowYesCounter >= maxCounter)
        {
            // Disable the specified Canvas component
            if (targetCanvas != null)
            {
                targetCanvas.enabled = false;
            }

            // Enable the button
            if (myButton != null)
            {
                myButton.gameObject.SetActive(true);
            }
        }
        else
        {
            // Adjust the speed based on the counter and speedIncreaseFactor
            float newSpeed = baseSpeed + arrowYesCounter * speedIncreaseFactor;

            // Log the new speed to check if it's being calculated correctly
            Debug.Log("New Speed: " + newSpeed);

            // Apply the new speed to the arrow
            AutoMove2 autoMoveScript = GetComponent<AutoMove2>();
            if (autoMoveScript != null)
            {
                autoMoveScript.SetSpeed(newSpeed);
            }
        }
    }

    public void ResetCounter()
    {
        arrowYesCounter = 0;
        counterText.text = arrowYesCounter + " / " + maxCounter;

        // Disable the button when resetting the counter
        if (myButton != null)
        {
            myButton.gameObject.SetActive(false);
        }
    }
}