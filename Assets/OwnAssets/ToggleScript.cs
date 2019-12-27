using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    
    [HideInInspector] public bool Pressed;


    public Image toggleButton;
    public Sprite first;
    public Sprite second;

    private int count = 1;
    // Start is called before the first frame update
    void Start()
    {
        toggleButton.GetComponent<Image>().sprite = first;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
        count++;
        if (count % 2 == 0)
        {
            toggleButton.GetComponent<Image>().sprite = second;
        }

        if (count % 2 == 1)
        {
            toggleButton.GetComponent<Image>().sprite = first;
        }
    }
}
