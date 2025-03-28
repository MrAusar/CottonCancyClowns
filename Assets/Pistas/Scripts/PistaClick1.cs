using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistaClick1 : MonoBehaviour
{
    private int counter = 0;

    public AudioManager refAudio;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Pista"))
                {
                    // Increment the counter in the GameManager
                    PistaSave1.Instance.IncrementCounter();
                    refAudio.PlaySFX(refAudio.pistaPeriodico);

                    // Make the clicked object disappear
                    hit.collider.gameObject.SetActive(false);
                }
            }
        }

        void OnDestroy()
        {
            // Save the counter value to PlayerPrefs when the script is destroyed (e.g., when changing scenes)
            PlayerPrefs.SetInt("PistasCount", counter);
            PlayerPrefs.Save();
        }
    }
}