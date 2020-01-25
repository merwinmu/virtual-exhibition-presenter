using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollButtonClick : MonoBehaviour
{
    private int counter = 0;

    public Button scrollButton;
    public Sprite firstScroll;
    public Sprite secondScroll;

    public GameObject scrollBar;
    // Start is called before the first frame update
    void Start()
    {
        scrollBar.gameObject.SetActive(false);
    }
    
    public void OnClickScrollButton()
    {
        counter++;
        if (counter % 2 == 1)
        {
            scrollBar.gameObject.SetActive(true);
            scrollButton.image.overrideSprite = secondScroll;
        }

        if (counter % 2 == 0)
        {
            scrollBar.gameObject.SetActive(false);
            scrollButton.image.overrideSprite = firstScroll;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
