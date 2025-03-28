using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Animation : MonoBehaviour
{
    [SerializeField] Animator transitionAnim;
    [SerializeField] Canvas myCanvas; // Reference to your Canvas component

    // Called from Animation Event
    public void OnAnimationEnd()
    {
        myCanvas.enabled = false;
    }

    public void LoadAnim()
    {
        transitionAnim.SetTrigger("End");
    }
}