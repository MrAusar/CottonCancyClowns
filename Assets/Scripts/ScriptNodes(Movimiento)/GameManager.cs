using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager ins;

    public IVCanvas ivCanvas;

    public Node startingNode;

    public CamaraRig camRig;

    public InventoryDisplay invDisplay;


    [HideInInspector]
    public Node currentNode;

    public Item itemHeld;


    private void Awake()
    {
        ins = this; 
        ivCanvas.gameObject.SetActive(false);
    }

    private void Start()
    {
        startingNode.Arrive();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape) && currentNode.GetComponent<Prop>() != null)
        {
            if (ivCanvas.gameObject.activeInHierarchy)
            {
                ivCanvas.Close();
                return;
            }
            currentNode.GetComponent<Prop>().loc.Arrive();
        }
    }
}
