using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArrowCounter : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    private int arrowYesCounter = 0;
    private int maxCounter = 10;
    public float baseSpeed = 2.0f; // Initialize with the desired value
    public float speedIncreaseFactor = 0.5f; // Adjust as needed

    public RawImage spookyImage;
    public RawImage black;

    public int first=0;

    public AudioSource blackout;
    public AudioClip freezeSound;
    public AudioSource bgm;
    public float freezeDuration = 2f; // Duration to freeze the screen in seconds
    private float timeCounter = 0f;
    private bool isFrozen = false;

    public float BaseSpeed
    {
        get { return baseSpeed; }
    }

    void Start()
    {
        first = 0;
        black.enabled = false;
        spookyImage.enabled = false;

        // Set the initial speed of the arrow
        AutoMove autoMoveScript = GetComponent<AutoMove>();
        if (autoMoveScript != null)
        {
            autoMoveScript.SetSpeed(baseSpeed);
        }
    }

    public void IncreaseArrowYesCounter()
    {
        arrowYesCounter++;

        // Ensure the counter does not exceed the maximum value
        arrowYesCounter = Mathf.Clamp(arrowYesCounter, 0, maxCounter);

        // Update the TextMeshProUGUI text
        counterText.text = arrowYesCounter + " / " + maxCounter;

        // Check if the counter has reached 10 before adjusting the speed
        if (arrowYesCounter >= maxCounter)
        {
            if (!isFrozen)
            {
                Debug.Log("Counter reached 10. Freezing screen for 3 seconds.");
                bgm.Pause();
                first ++;
                if (first == 1)
                {
                    StartCoroutine("Blackout");
                    black.enabled = true;
                    blackout.Play();
                }
            }
        }
        else
        {
            // Adjust the speed based on the counter and speedIncreaseFactor
            float newSpeed = baseSpeed + arrowYesCounter * speedIncreaseFactor;

            // Log the new speed to check if it's being calculated correctly
            Debug.Log("New Speed: " + newSpeed);

            // Apply the new speed to the arrow
            AutoMove autoMoveScript = GetComponent<AutoMove>();
            if (autoMoveScript != null)
            {
                autoMoveScript.SetSpeed(newSpeed);
            }
        }
    }
    private void Update()
    {
        if (first == 2)
        {
            black.enabled = false;
            if (!isFrozen)
            {
                if (GetComponent<AudioSource>() != null && freezeSound != null)
                {
                    GetComponent<AudioSource>().PlayOneShot(freezeSound);
                }

                // Enable the spookyImage after playing the sound
                Debug.Log("Componentgot");
                spookyImage.enabled = true;

                // Start freezing coroutine
                StartCoroutine(FreezeScreen());
            }
        }
    }

    public void ResetCounter()
    {
        arrowYesCounter = 0;
        counterText.text = arrowYesCounter + " / " + maxCounter;
    }
    IEnumerator FreezeScreen()
    {
        isFrozen = true;
        Time.timeScale = 0f; // Set time scale to 0 to freeze the screen

        // Play the freeze sound (assuming you have an AudioSource component attached to the same GameObject)


        // Wait for the specified duration (6 seconds in this case)
        yield return new WaitForSecondsRealtime(freezeDuration);

        // Unfreeze the screen
        Time.timeScale = 1f;
        isFrozen = false;

        // Transition to the specified scene
        TransitionToScene("MainMenuV2Final");
    }
    IEnumerator Blackout()
    {
        yield return new WaitForSecondsRealtime(4f);
        first ++;
    }


    void TransitionToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}