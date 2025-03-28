using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CandyOptions : MonoBehaviour
{
    public Canvas buttonCanvas;
    public GameObject objectToActivate1;
    public GameObject objectToActivate2;
    public GameObject objectToActivate3;

    private void Start()
    {
        // Disable the Canvas on start
        buttonCanvas.gameObject.SetActive(false);

        // Find and assign click listeners to all buttons in the canvas
        Button[] buttons = buttonCanvas.GetComponentsInChildren<Button>();
        TMP_InputField[] textMeshProButtons = buttonCanvas.GetComponentsInChildren<TMP_InputField>();

        foreach (Button button in buttons)
        {
            button.onClick.AddListener(delegate { OnButtonClicked(button); });
        }

        foreach (TMP_InputField textMeshProButton in textMeshProButtons)
        {
            textMeshProButton.onEndEdit.AddListener(delegate { OnButtonClicked(null); });
        }
    }

    private void OnMouseDown()
    {
        // Toggle the Canvas when the object is clicked
        buttonCanvas.gameObject.SetActive(!buttonCanvas.gameObject.activeSelf);
    }

    public void OnButtonClicked(Button clickedButton)
    {
        Debug.Log("Button Clicked: " + (clickedButton != null ? clickedButton.name : "Unknown"));

        // Disable the object when any button is clicked
        gameObject.SetActive(false);

        // Activate the corresponding object based on the button clicked
        if (clickedButton != null)
        {
            if (clickedButton.name == "Button1" && objectToActivate1 != null)
            {
                objectToActivate1.SetActive(true);
                Debug.Log("Object1 Activated");
            }
            else if (clickedButton.name == "Button2" && objectToActivate2 != null)
            {
                objectToActivate2.SetActive(true);
                Debug.Log("Object2 Activated");
            }
            else if (clickedButton.name == "Button3" && objectToActivate3 != null)
            {
                objectToActivate3.SetActive(true);
                Debug.Log("Object3 Activated");
            }
        }
    }
}