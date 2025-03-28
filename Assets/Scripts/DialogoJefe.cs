using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class DialogoJefe : MonoBehaviour
{
    public Prop prop;

    [SerializeField] private string[] lineasDialogo;
    [SerializeField] private GameObject panelDialogo;
    [SerializeField] private TMP_Text textoDialogo;

    public GameObject botonEstacion;
    public GameObject jefe;
    public GameObject Tiempo;


    private bool dialogoActivo;
    private int dialogoIndex;
    private void Update()
    {
        Deact();
    }

    private void OnMouseDown()
    {
            if (!dialogoActivo)
            {
                InicioDialogo();
            }

            else if (textoDialogo.text == lineasDialogo[dialogoIndex])
            {
                SiguienteDialogo(); 
            }
    }

    private void InicioDialogo()
    {

        GameManager.ins.currentNode.SetReachablesNodes(false);

        dialogoActivo = true;
        panelDialogo.SetActive(true);

        dialogoIndex = 0;

        textoDialogo.text = lineasDialogo[dialogoIndex];
    }
     
    private void SiguienteDialogo()
    {
        dialogoIndex++;
        if (dialogoIndex < lineasDialogo.Length)
        {
            textoDialogo.text = lineasDialogo[dialogoIndex];
        }

        else
        {
            dialogoActivo = false;
            panelDialogo.SetActive(false);
        }

       
    }

    private void Deact()
    {
        if (dialogoActivo == false && Input.GetKeyUp(KeyCode.Escape))
        {
            StartCoroutine(Desaparecer());
        }
    }

    IEnumerator Desaparecer()
    {
        yield return new WaitForSeconds(0.55f);
        botonEstacion.SetActive(true);
        jefe.SetActive(false);
     
    }
}
