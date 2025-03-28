using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botn3D : MonoBehaviour
{
    public int Color;

    AlgodonesEZ refAlgodones;

    public AudioManager refAudio;


    private void Start()
    {
        refAlgodones = FindObjectOfType<AlgodonesEZ>();
    }
    private void OnMouseDown()
    {
        switch (Color)
        {
            //0 azul, 1 morado, 2 rosa
            case 0:
                refAlgodones.CambiarTexturaAzul();
                refAudio.PlaySFX(refAudio.seleccionarAzucar);
                break;

            case 1:
                refAlgodones.CambiarTexturaMorada();
                refAudio.PlaySFX(refAudio.seleccionarAzucar);
                break;
            case 2:
                refAlgodones.CambiarTexturaRosa();
                refAudio.PlaySFX(refAudio.seleccionarAzucar);
                break;
        }
    }

}