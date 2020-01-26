using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        
        InteractionButton = InteractionControlScript.GetInteractionButton();
        T_Button = GetComponentInChildren<Button>();
        T_Text = T_Button.GetComponentInChildren<Text>();

        if (!InteractionButton)
        {
            InteractionControlScript.SetInteractionButton(true);
            T_Text.text = "GM";
            T_Text.transform.position = new Vector3(1998, 1056, 0);
            T_Button.image.overrideSprite = first;

        }
        else
        {
            InteractionControlScript.SetInteractionButton(false);
            T_Text.text = "TM";
            T_Button.image.overrideSprite = second;
            T_Text.transform.position = new Vector3(1919, 1056, 0);
        }
    }

    
    public void YourFunction()
    {
        if (InteractionButton )
        {
            StartCoroutine(RemoveAfterSeconds(1, InfoWindow));
        }
    }
 
    IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
    {
        obj.gameObject.SetActive(true);
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);
    }
    
}
