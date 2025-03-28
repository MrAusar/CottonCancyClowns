using UnityEngine;

public class ArrowKey : MonoBehaviour
{
    public KeyCode assignedKeyCode; // Assign the corresponding arrow key in the Inspector.
    private ArrowKeyGenerator arrowKeyGenerator; // Reference to the ArrowKeyGenerator.
  //  public bool canGetInput=false;
  private bool hasBeenPressed = false;
    private void Start()
    {
        arrowKeyGenerator = FindObjectOfType<ArrowKeyGenerator>();
      //  arrowKeyGenerator.RegisterArrowKey(this);
    }
    

    private void LateUpdate() // NO SE USA
    {
      /* if (!hasBeenPressed && Input.GetKeyDown(assignedKeyCode) )
        {
            arrowKeyGenerator.HandleArrowKeyInput(assignedKeyCode, this.gameObject);
            
            hasBeenPressed = true;
            Debug.Log(assignedKeyCode);
        }*/
    }
}