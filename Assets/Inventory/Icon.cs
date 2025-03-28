using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Icon : MonoBehaviour
{
    [SerializeField] Image iconImage;
    public bool selected = false;
    public int index;
    private Button btn;
    public ObjectInteraction objectRef; 

    private void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(Click);
    }

    public void setIcon(Sprite sprite)
    {
        iconImage.sprite = sprite;
    }
    public void Click()
    {
        InventoryManager.instance.SelectOne(index);
        
    }
   

}
