using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreRequisitos : MonoBehaviour
{
    // si es true checar el objeto
    public bool requireItem;

    //si requireItem es true checar el collector 
    public Collector checkCollector;

    // Revisa si el switch esta activado
    public Switcher watchSwitcher;

    //si el switch esta activado bloquear acceso
    public bool nodeAccess;

    //Checar que se cumple el requisito
    public bool Complete
    {
        get {
            if (!requireItem)
            {
                return watchSwitcher.state;
            }

            else
            {
                return GameManager.ins.itemHeld.itemName == checkCollector.myItem.itemName;
            }
            
            }
    }

}
