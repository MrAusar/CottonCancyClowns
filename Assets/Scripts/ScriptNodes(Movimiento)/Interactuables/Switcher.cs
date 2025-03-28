using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : Interactable
{
    public bool state;

    // Event SetUp
    public delegate void OnStateChange();
    public event OnStateChange change;


    public override void Interact()
    {
        state =! state;

        if (change != null)
        {
            change();
        }
    }

}
