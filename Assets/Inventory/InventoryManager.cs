using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public GameObject[] miniIconObject;
    public int index = 0;

    // Speed of the animation (adjust as needed)
    public float animationSpeed = 2.0f;
    private Icon SelectedIcon;
    private int selectedIndex = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EnableMiniIconObject(bool enable, Sprite image, ObjectInteraction obj)
    {
        miniIconObject[index].GetComponent<Icon>().setIcon(image);
        miniIconObject[index].SetActive(enable);
        miniIconObject[index].GetComponent<Icon>().index = index;
        miniIconObject[index].GetComponent<Icon>().objectRef = obj;
        SelectOne(index);
        index++;
        Debug.Log("index" + index);
    }
    public void SelectOne(int i)
    {
        foreach (var item in miniIconObject)
        {
            item.GetComponent<Icon>().selected = false;
        }
        SelectedIcon = miniIconObject[i].GetComponent<Icon>();
        SelectedIcon.selected = true;
        selectedIndex = i;
        Debug.Log("Selected " + i);

    }
   /* public void RemoveItem()
    {
        if (index > 0)
        {
            // Shift items to the left
            for (int i = 0; i < index - 1; i++)
            {
                RectTransform rectTransform = miniIconObject[i].GetComponent<RectTransform>();
                RectTransform nextRectTransform = miniIconObject[i + 1].GetComponent<RectTransform>();

                // Shift the position to the left
                rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, nextRectTransform.anchoredPosition, Time.deltaTime * animationSpeed);
            }

            // Disable the last miniIconObject
            miniIconObject[index - 1].SetActive(false);
            
            // Decrement the index to point to the next available slot
            index--;
        }
    }
   */
    public void dropItem()
    {
       if(index > 0 && selectedIndex >= 0)
        {
         miniIconObject[selectedIndex].SetActive(false);
                SelectedIcon.objectRef.DropObject();
                SelectedIcon.selected = false;     
      
                index--;
                Debug.Log("index" + index);

            selectedIndex = -1;
        }
       
    }

}