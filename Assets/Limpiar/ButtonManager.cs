using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public Button[] buttons;          // Array to hold all buttons
    public GameObject firstObject;    // The first 3D object
    public GameObject secondObject;   // The second 3D object
    public Button newButton;           // The new button to enable

    private int clickCount = 0;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
        // Ensure only one instance of GameManager exists
        if (FindObjectsOfType<GameManager>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);

            if (buttons != null && buttons.Length > 0 && firstObject != null && secondObject != null && newButton != null)
            {
                // Subscribe to the onClick event for each button
                foreach (Button button in buttons)
                {
                    button.onClick.AddListener(() => OnButtonClick(button));
                }

                // Ensure the first object starts turned on, and the second one starts turned off
                firstObject.SetActive(true);
                secondObject.SetActive(false);

                // Ensure the new button starts turned off
                newButton.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogError("Buttons, newButton, or 3D objects not assigned in the inspector!");
            }
        }
    }

    void OnButtonClick(Button clickedButton)
    {
        clickCount++;

        if (clickCount == 30)
        {
            Debug.Log("Good job! You clicked a button 15 times.");

            // Disable the clicked button
            clickedButton.gameObject.SetActive(false);

            // Disable the first 3D object
            firstObject.SetActive(false);

            // Enable the second 3D object
            secondObject.SetActive(true);

            // Enable the new button
            newButton.gameObject.SetActive(true);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reset the state when a new scene is loaded
        ResetState();
    }

    void ResetState()
    {
        clickCount = 0;

        // Enable the initial button and disable the second 3D object
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(true);
        }

        firstObject.SetActive(true);
        secondObject.SetActive(false);
        newButton.gameObject.SetActive(false);
    }
}