using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneTranMM : MonoBehaviour
{


    // Specify the name of the scene you want to load
    public string sceneToLoad;

    // Function to be called when the button is clicked
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}