using UnityEngine;
using UnityEngine.UI;

public class ButtonClickCounter : MonoBehaviour
{
    private int clickCount = 0;  // Counter for button clicks

    public AudioManager refAudio;


    void Start()
    {
        // Ensure that the Button component is attached to the GameObject
        Button myButton = GetComponent<Button>();

        if (myButton != null)
        {
            // Subscribe to the button click event
            myButton.onClick.AddListener(OnClick);
        }
        else
        {
            Debug.LogError("Button component not found on the GameObject!");
        }
    }

    // This method is called when the TextMeshPro button is clicked
    void OnClick()
    {
        refAudio.PlaySFX(refAudio.limpiar);

        clickCount++;  // Increment the click count
        Debug.Log("Click Count: " + clickCount);

        // Check if the click count has reached 15
        if (clickCount == 15)
        {
            Debug.Log("Good job! You clicked the button 15 times.");
        }
    }
}