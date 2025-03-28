using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptBotonesMainMenu : MonoBehaviour
{
    public void Cinematica()
    {
        SceneManager.LoadScene(2);
    }
    public void Jugar()
    {
        SceneManager.LoadScene(3);
    }

    public void SalirJuego()
    {
        Application.Quit();
    }

}
