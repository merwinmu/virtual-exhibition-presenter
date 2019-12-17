using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SampleButton : MonoBehaviour {

    public Button buttonComponent;
    public Text nameLabel;
    
    private Text buttoname;
   // public Image iconImage;
    public float id;
    
    private Item item;
    private ShopScrollList scrollList;

    // Use this for initialization
    void Start () 
    {
        buttonComponent.onClick.AddListener (HandleClick);
    }

    public void Setup(Item currentItem, ShopScrollList currentScrolllist)
    {
        item = currentItem;
        nameLabel.text = item.itemName;
        id = item.id;
        scrollList = currentScrolllist;
    }

    public void HandleClick()
    {
        Debug.Log("Clicked");
    }
}