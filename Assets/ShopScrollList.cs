using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class Item
{
    public string itemName;
   // public Sprite icon;
    public float id;
}

public class ShopScrollList : MonoBehaviour {

    public List<Item> itemList;
    public Transform contentPanel;
    public SimpleObjectPool buttonObjectPool;


    
    

    // Use this for initialization
    void Start () 
    {
        RefreshDisplay ();
    }

    void RefreshDisplay()
    {
        AddButtons ();
    }
    
    private void AddButtons()
    {
        for (int i = 0; i < itemList.Count; i++) 
        {
            Item item = itemList[i];
            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.SetParent(contentPanel);

            SampleButton sampleButton = newButton.GetComponent<SampleButton>();
            sampleButton.Setup(item,this);
        }
    }
}