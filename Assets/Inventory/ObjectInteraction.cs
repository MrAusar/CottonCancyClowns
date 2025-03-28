using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public Sprite icon;

    private void OnMouseDown()
    {
        CollectObject();
       
    }

    private void CollectObject()
    {
        // Disable the object's renderer
        //GetComponent<Renderer>().enabled = false;
        gameObject.SetActive(false);

        // Enable the mini icon GameObject immediately
        InventoryManager.instance.EnableMiniIconObject(true,icon, this);
       

    }
    public void DropObject()
    {
        Debug.Log("drop");
        // GetComponent<Renderer>().enabled = true;
        gameObject.SetActive(true);
    }

    private void EnableRenderer()
    {
        // Enable the object's renderer after a delay
       // GetComponent<Renderer>().enabled = true;

        // Disable the mini icon GameObject after a delay
        InventoryManager.instance.EnableMiniIconObject(false,icon,this);
        Destroy(this.gameObject);

    }
}