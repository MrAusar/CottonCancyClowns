using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{

    public GameObject menuPausa;

    // Start is called before the first frame update
    void Start()
    {
        menuPausa.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ContinuarJuego()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1f;
    }

    public void VolverMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ReiniciarDia() 
    {
        Time.timeScale = 1f;

        string escenaActual = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(escenaActual);
    }
}
