using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class switchSprite : MonoBehaviour
{

    public Button myButton;
    public Sprite first;
    public Sprite second;
    private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        myButton.GetComponent<Button>();
    }

    public void changeSprite()
    {
        counter++;
        if (counter % 2 == 0)
        {
            myButton.image.overrideSprite = first;
        }
        else
        {
            myButton.image.overrideSprite = second;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
