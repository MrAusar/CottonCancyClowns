using UnityEngine;
using TMPro;

public class ObjectHover : MonoBehaviour
{
    public TextMeshProUGUI percentageText;
    private int currentPercentage = 100;
    private bool hasSubtracted = false;
    private bool canRefill = true; // New variable to control refilling
    public float increaseSpeed = 5.0f;

    private ObjectManager objectManager;

    public void DecreasePercentage()
    {
        // Implement your logic to decrease the percentage here
        if (!hasSubtracted && currentPercentage > 0)
        {
            SubtractPercentage(20);
            hasSubtracted = true;

            if (gameObject.CompareTag("Refill"))
            {
                objectManager.FirstObjectLostPercentage();
            }
        }
    }



    private void Start()
    {
        if (percentageText == null)
        {
            Debug.LogError("Percentage Text not assigned!");
        }
        else
        {
            percentageText.text = $"{currentPercentage}%";
            percentageText.gameObject.SetActive(false);
        }


        objectManager = FindObjectOfType<ObjectManager>();
    }

    private void OnMouseOver()
    {
        if (gameObject.CompareTag("Refill"))
        {
            percentageText.gameObject.SetActive(false);
        }
        else
        {
            percentageText.text = $"{currentPercentage}%";
            percentageText.gameObject.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        percentageText.gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (currentPercentage >= 0 && currentPercentage <= 19)
        {
            return;
        }

        if (!hasSubtracted && currentPercentage > 0)
        {
            SubtractPercentage(20);
            hasSubtracted = true;

            if (gameObject.CompareTag("Refill"))
            {
                // Notify the manager that the first object lost percentage
                objectManager.FirstObjectLostPercentage();
            }
        }
    }

    private void OnMouseUp()
    {
        hasSubtracted = false;
    }

    private void FixedUpdate()
    {
        // Allow "R" key increase only for objects that are allowed to refill
        if (canRefill && Input.GetKey(KeyCode.R) && currentPercentage < 100)
        {
            IncreasePercentage(increaseSpeed * Time.deltaTime);
        }
    }

    private void IncreasePercentage(float incrementAmount)
    {
        currentPercentage += Mathf.RoundToInt(incrementAmount);
        currentPercentage = Mathf.Min(currentPercentage, 100);

        if (!gameObject.CompareTag("Refill"))
        {
            percentageText.text = $"{currentPercentage}%";
        }
    }

    public void SetCanRefill(bool value)
    {
        canRefill = value;
    }

    public void SubtractPercentage(int amount)
    {
        currentPercentage -= amount;
        currentPercentage = Mathf.Max(currentPercentage, 0);

        if (!gameObject.CompareTag("Refill"))
        {
            percentageText.text = $"{currentPercentage}%";
        }
    }
}