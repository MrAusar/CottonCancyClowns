using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdvanceTime : MonoBehaviour
{
    [SerializeField] private int startingTime;
    [SerializeField] private float timeUntilHourChange;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] public int timeLimit;

    [NonSerialized] public int timeHours;

    private bool isTimeLimitReached = false;

    public CheckManDay2 refContador;
    public void Start()
    {
        timeHours = startingTime;

        StartCoroutine(AdvanceHourOverTime());
    }

    public void Update()
    {
        if (!isTimeLimitReached)
        {
            timeText.text = timeHours + ":00 PM";
        }
    }

    public IEnumerator AdvanceHourOverTime()
    {
        yield return new WaitForSecondsRealtime(timeUntilHourChange);

        if (timeHours == 12)
        {
            timeHours = 1;
        }
        else
        {
            timeHours++;
        }

        if (timeHours < timeLimit)
        {
            StartCoroutine(AdvanceHourOverTime());
        }

        else
        {
            // The time limit has been reached. Wait for 3 seconds and then hide the text.
            yield return new WaitForSeconds(3f);
            timeText.gameObject.SetActive(false);
            isTimeLimitReached = true;

            if(refContador.contadorAlgodones < 20)
            {
                Debug.Log("ReinciciaDia");
            }
        }
    }
}