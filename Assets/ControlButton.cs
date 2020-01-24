using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ControlButton : MonoBehaviour {
    private static bool InteractionButton;
    public Sprite first;
    public Sprite second;
    public Button T_Button;
    public GameObject InfoWindow;
    private Text T_Text;

    private void Start()
    {
        InfoWindow.gameObject.SetActive(false);
    }

    public void OnClickInteractionButton()
    {
        
        InteractionButton = gyroControl.GetInteractionButton();
        T_Button = GetComponentInChildren<Button>();
        T_Text = T_Button.GetComponentInChildren<Text>();

        if (!InteractionButton)
        {
            gyroControl.SetInteractionButton(true);
            T_Text.text = "GM";
            T_Text.transform.position = new Vector3(1813, 1122, 0);
            T_Button.image.overrideSprite = first;

        }
        else
        {
            gyroControl.SetInteractionButton(false);
            T_Text.text = "TM";
            T_Button.image.overrideSprite = second;
            T_Text.transform.position = new Vector3(1736, 1122, 0);
        }
    }

    public void YourFunction()
    {
        if (T_Text.text == "TM")
        {
            StartCoroutine(RemoveAfterSeconds(3, InfoWindow));
        }
    }
 
    IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
    {
        obj.gameObject.SetActive(true);
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);
    }
    
}
