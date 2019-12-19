using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlButton : MonoBehaviour
{
    
    private static bool InteractionButton;

    public void OnClickInteractionButton()
    {
        InteractionButton = gyroControl.GetInteractionButton();
        Button T_Button = GetComponentInChildren<Button>();
        Text T_Text = T_Button.GetComponentInChildren<Text>();

        if (!InteractionButton)
        {
            gyroControl.SetInteractionButton(true);
            T_Text.text = "GYRO MODE";
        }
        else
        {
            gyroControl.SetInteractionButton(false);
            T_Text.text = "TOUCH MODE";
        }
        
    }
    
}
