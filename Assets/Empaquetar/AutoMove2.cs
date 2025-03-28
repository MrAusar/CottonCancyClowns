using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class AutoMove2 : MonoBehaviour
{
    private bool counterReachedTen = false;


    public float speed = 2f; // Adjust the speed as needed
    public float distance = 5f; // Adjust the distance as needed
    public Canvas canvasToTurnOff; // Reference to the Canvas component
    public ArrowGood arrowGood;


    private int direction = 1; // 1 for right, -1 for left
    private float initialPosition;
    private bool isMoving = true; // Flag to control movement
    private bool shouldCheckColliders = false; // Flag to control collider checking

    private int arrowYesCounter = 0; // Counter for "ArrowYes" collisions

    void Start()
    {
        // Store the initial position of the object
        initialPosition = transform.position.x;

        arrowGood = FindObjectOfType<ArrowGood>();

    }

    void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector3.right * speed * direction * Time.deltaTime);

            if (Mathf.Abs(transform.position.x - initialPosition) > distance)
            {
                direction *= -1;
            }
        }

        // Check if the counter has reached 10 before executing the action
        if (arrowYesCounter >= 10 && !counterReachedTen)
        {
            Debug.Log("Counter reached 10. Do something here.");
            // Optionally, you can stop the movement or perform other action

            // Set the flag to true to indicate that the action has been executed
            counterReachedTen = true;
        }

    }

    // Call this method when you want to check colliders
    public void CheckColliders()
    {
        // Check which colliders the object is currently touching
        Collider2D[] colliders = new Collider2D[5]; // Adjust the size based on your requirements
        ContactFilter2D contactFilter = new ContactFilter2D();
        int colliderCount = Physics2D.OverlapCollider(GetComponent<Collider2D>(), contactFilter, colliders);

        // Log or process the colliders
        for (int i = 0; i < colliderCount; i++)
        {
            // Check the tag of the collider and perform actions accordingly
            if (colliders[i].tag == "ArrowYes")
            {
                Debug.Log("Object is touching ArrowYes");
                arrowYesCounter++;
                // Call the method in the ArrowCounter script to increase the counter
                if (arrowGood != null)
                {
                    arrowGood.IncreaseArrowYesCounter();
                }


                // Check if the counter reaches 10
                if (arrowYesCounter >= 10)
                {
                    Debug.Log("Counter reached 10. Do something here.");
                    // Optionally, you can stop the movement or perform other action
                }
            }
            else if (colliders[i].tag == "NuhUh" || colliders[i].tag == "Nope")
            {
                Debug.Log("Object is touching NuhUh or Nope");
                TurnOffCanvas();
                arrowYesCounter = 0;
            }
        }
    }

    public void ToggleMovement()
    {
        isMoving = !isMoving;
        shouldCheckColliders = !isMoving;
    }

    public void SetSpeed(float newSpeed)
    {
        // Set the speed to the specified valu
        speed = newSpeed;
    }

    public void TurnOffCanvas()
    {
        // Turn off the entire canvas in the Hierarchy
        if (canvasToTurnOff != null)
        {
            canvasToTurnOff.gameObject.SetActive(false);

            // Reset the counter and speed
            if (arrowGood != null)
            {
                arrowGood.ResetCounter();
                SetSpeed(arrowGood.BaseSpeed);
            }

            // Reset the object's position to the initial positio
            transform.position = new Vector3(initialPosition, transform.position.y, transform.position.z);

            // Resume movement
            isMoving = true;

            // Reset the flag for counter reaching 10
            counterReachedTen = false;
        }
    }
}