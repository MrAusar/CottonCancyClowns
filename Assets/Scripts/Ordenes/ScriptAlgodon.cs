using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//using static Unity.VisualScripting.Metadata;

public class ScriptAlgodon : MonoBehaviour
{

    public Material algodonMat;
    public Texture2D texturaAlgodon;
    public GameObject FormaActual;

    public int nombreForma;


    [SerializeField] private GameObject[] Children;
    [SerializeField] private Texture2D[] TexturasNormal; 
    [SerializeField] private Texture2D[] TexturasGato; 
    [SerializeField] private Texture2D[] TexturasConejo; 
    [SerializeField] private Texture2D[] TexturasPayaso;

    public EstructuraAlgodon InstanciaEstructura;
    

    private void Start()
    {

    }
    public void CambiarTextura(int Forma, int Color)
    {
        switch (Forma)
        {
            case 0: //Normal
                algodonMat = FormaActual.GetComponent<MeshRenderer>().material;
                algodonMat.SetTexture("_Base_Color_Texture", TexturasNormal[Color]);
                break;
            case 1: //Payaso
                algodonMat = FormaActual.GetComponent<MeshRenderer>().material;
                algodonMat.SetTexture("_Base_Color_Texture", TexturasPayaso[Color]);
                break;
            case 2: //Conejo
                algodonMat = FormaActual.GetComponent<MeshRenderer>().material;
                algodonMat.SetTexture("_Base_Color_Texture", TexturasConejo[Color]);
                break;
            case 3: //Gato
                algodonMat = FormaActual.GetComponent<MeshRenderer>().material;
                algodonMat.SetTexture("_Base_Color_Texture", TexturasGato[Color]);
                break;

        }
        /*algodonMat = GetComponent<Material>();
        algodonMat.SetTexture("_Base_Color_Texture", nuevaTextura);
        texturaAlgodon = nuevaTextura;*/

        InstanciaEstructura.colorAlgodon = Color;
    }

    public void CambiarForma(int index)
    {
        foreach(GameObject Child in Children)
        {
            Child.gameObject.SetActive(false);
        }
        Children[index].SetActive(true);
        
        FormaActual = Children[index];

        InstanciaEstructura.formaAlgodon = index;
    }
}
