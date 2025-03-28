using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CounterSceneTransition1 : MonoBehaviour
{
    [SerializeField] Animator transitionAnim;

    // Specify the name of the scene you want to load for counter range 1-
    public string sceneToLoad4to5;

    public string sceneToLoad0to3;


    public void LoadScene()
    {
        StartCoroutine(AnimEnding());
    }

    public void CheckCounterAndLoadScene()
    {
        StartCoroutine(AnimEnding());

    }

    IEnumerator AnimEnding()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);

        // Access the PistaSave singleton instance
        PistaSave1 pistaSave = PistaSave1.Instance;

        // Check if the counter is between 1 and 3 (inclusive)
        if (pistaSave.Counter >= 4 && pistaSave.Counter <= 5)
        {
            // Load the specified scene for counter range 1-3
            SceneManager.LoadScene(sceneToLoad4to5);
        }
        // Check if the counter is between 4 and 6 (inclusive)
        else if (pistaSave.Counter >= 0 && pistaSave.Counter <= 3)
        {
            // Load the specified scene for counter range 4-6
            SceneManager.LoadScene(sceneToLoad0to3);
        }

        transitionAnim.SetTrigger("Start");
    }
}