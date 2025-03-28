using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Clientes : MonoBehaviour
{
    public ContadorOrdenes Contador;
    public Animator anim;

    public GameObject[] clientes;
    public int clienteActivo = 0;

    private void Start()
    {
        if (clientes.Length > 0)
        {
            EnabledCurrentObject();
        }
    }

    private void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (Contador.contadorOrdenes < 1) 
        {
            Contador.contadorOrdenes++;
            anim.SetTrigger("Abajo");
            StartCoroutine(SiguienteCliente());  
        }
        else
        {
            anim.SetTrigger("Arriba");
        }
    }

    IEnumerator SiguienteCliente()
    {
        yield return new WaitForSeconds(1f);
        anim.SetTrigger("Arriba");

        DisableCurrentObject();

        // Move to the next index (circular, so it goes back to 0 if it exceeds the array length).
        clienteActivo = (clienteActivo + 1) % clientes.Length;

        // Enable the next GameObject.
        EnabledCurrentObject();
    }

    void EnabledCurrentObject()
    {
        if (clienteActivo < clientes.Length && clienteActivo >= 0) 
        {
            clientes[clienteActivo].SetActive(true);
        }
    }
    
    void DisableCurrentObject()
    {
        if (clienteActivo < clientes.Length && clienteActivo >= 0) 
        {
            clientes[clienteActivo].SetActive(false);
        }
    }
}
