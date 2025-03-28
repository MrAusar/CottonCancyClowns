using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventosDia1 : MonoBehaviour
{

    public AdvanceTime advanceTime;
    public AnimDialogo animDialogo;

    public GameObject botonLimpiar;
    public GameObject botonFinDia;

    public GameObject timer;


    public GameObject reiniciarDia;
    public GameObject pasarDia;
    public CheckManDay2 refContador;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MensajeJefe();
    }

    void MensajeJefe()
    {
        if (advanceTime.timeHours == advanceTime.timeLimit)
        {
            if (refContador.contadorAlgodones < 20)
            {
                reiniciarDia.SetActive(true);
                Debug.Log("ReinciciaDia");
            }
            else if (refContador.contadorAlgodones >= 20)
            {
                pasarDia.SetActive(true);
            }
        }
    }

    public void Timer()
    {
        timer.SetActive(true);
    }



    IEnumerator BotonLimpiar()
    {
        yield return new WaitForSeconds(7f);
        botonLimpiar.SetActive(true);
    }

    public void boton()
    {
        botonFinDia.SetActive(true);
    }

    public void SiguienteDia()
    {
        SceneManager.LoadScene(4);
    }
}
