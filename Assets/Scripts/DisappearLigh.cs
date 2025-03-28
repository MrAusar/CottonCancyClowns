using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DisappearLigh : MonoBehaviour
{
    [SerializeField] private GameObject luz;
    [SerializeField] private float timeDelay;
    [SerializeField] private AudioSource lightfail;
    public void Turnoff()
    {
        StartCoroutine(turnoff());
    }
    IEnumerator turnoff()
    {
        //luz.SetActive(false);
        lightfail.Play();
        timeDelay = Random.Range(0.01f, 0.6f);
        yield return new WaitForSeconds(timeDelay);
       // luz.SetActive(true);
    }
}
