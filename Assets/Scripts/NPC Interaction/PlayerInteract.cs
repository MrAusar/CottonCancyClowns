using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            float interactRange = 10f;
            Collider[] colliderArray = Physics.OverlapSphere (transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                Debug.Log(collider);
            }
        }
    }
}
