using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistaSave1 : MonoBehaviour
{
    private static PistaSave1 _instance;

    public static PistaSave1 Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PistaSave1>();

                if (_instance == null)
                {
                    GameObject singleton = new GameObject(typeof(PistaSave1).Name);
                    _instance = singleton.AddComponent<PistaSave1>();
                }
            }

            return _instance;
        }
    }

    private int counter = 0;

    public int Counter
    {
        get { return counter; }
    }

    public void IncrementCounter()
    {
        counter++;
        Debug.Log("Counter: " + counter);
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Add any other variables or methods you need here
}
