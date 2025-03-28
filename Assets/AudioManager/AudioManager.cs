using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // audio source
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    //audio clip

    public AudioClip recibirOrden;
    public AudioClip crearAlgodon;
    public AudioClip entregarOrdenBien;
    public AudioClip entregarOrdenMal;
    public AudioClip seleccionarAzucar;
    public AudioClip limpiar;
    public AudioClip pistaPeriodico;
    public AudioClip llamar;

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }


}
