using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class Node : MonoBehaviour
{
    public Transform camaraPosition;
    public List<Node> reachableNodes = new List<Node>();

    [HideInInspector]
    public Collider col;

    private void Awake()
    {
        col = GetComponent<Collider>();
        col.enabled = false;
    }

    private void OnMouseDown()
    {
        Arrive();
    }

    public virtual void Arrive()
    {
        if(GameManager.ins.currentNode != null) 
        {
            GameManager.ins.currentNode.Leave();
        }
        

        // Activar current node
        GameManager.ins.currentNode = this;

        //Mover la camara

        GameManager.ins.camRig.AlignTo(camaraPosition);
        

        //Apagar colliders
        if (col != null)
        {
            col.enabled = false;
        }

        //Prender colliders visibles
        SetReachablesNodes(true);
    }

    public virtual void Leave()
    {
        //Apagar colliders visibles
        SetReachablesNodes(false);
    }

    public void SetReachablesNodes(bool set)
    {
        foreach (Node node in reachableNodes)
        {
            if (node.col != null)
            {
                if (node.GetComponent<PreRequisitos>() && node.GetComponent<PreRequisitos>().nodeAccess )
                {
                    if (node.GetComponent<PreRequisitos>().Complete)
                    {
                        node.col.enabled = set;
                    }
                }

                else
                {
                    node.col.enabled = set;
                }

                
            }
        }
    }
}
