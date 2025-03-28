using System.Collections;
using System.Collections.Generic;
//using UnityEditor.PackageManager;
using UnityEngine;

public class ClientesArray : MonoBehaviour
{

    ContadorOrdenes contadorClase;
    Clientes clientesClase;

    // Start is called before the first frame update
    void Start()
    {
        if (clientesClase.clientes.Length > 0)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnabledCurrentObject()
    {
        if (clientesClase.clienteActivo < clientesClase.clientes.Length && clientesClase.clienteActivo >= 0)
        {
            clientesClase.clientes[clientesClase.clienteActivo].SetActive(true);
        }
    }

    void DisableCurrentObject()
    {
        if (clientesClase.clienteActivo < clientesClase.clientes.Length && clientesClase.clienteActivo >= 0)
        {
            clientesClase.clientes[clientesClase.clienteActivo].SetActive(false);
        }
    }
}
