using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    [SerializeField] Animator transitionAnim;

    // Specify the name of the scene you want to load
    public string sceneToLoad;

    // Function to be called when the button is clicked
    public void LoadScene()
    {
        StartCoroutine(AnimLoad());
    }

    IEnumerator AnimLoad()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(sceneToLoad);
        transitionAnim.SetTrigger("Start");
    }

}