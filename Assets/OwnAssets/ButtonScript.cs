using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class ButtonScript : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    [HideInInspector] public bool Pressed;

    public Image button;
    
    // Start is called before the first frame update
    void Start()
    {
        button.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
    }
}