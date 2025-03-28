using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLights : MonoBehaviour
{
    private bool Flickering = false;
    [SerializeField] private float timeDelay;
    void Update()
    {
     if (Flickering == false)
        {
            StartCoroutine(LightsFlicker());
        }   
    }
    IEnumerator LightsFlicker()
    {
        Flickering = true;
        this.gameObject.GetComponent<Light>().enabled = false;
        timeDelay = Random.Range(0.01f, 0.6f);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = true;
        timeDelay = Random.Range(0.01f, 0.6f);
        yield return new WaitForSeconds(timeDelay);
        Flickering = false;
    }
}
