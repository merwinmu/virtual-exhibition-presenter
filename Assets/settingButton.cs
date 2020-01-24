using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settingButton : MonoBehaviour
{
    public Button settingsButton;
    public Sprite firstSetting;
    public Sprite secondSetting;
    private int counter = 0; 

    public Image menu;
    // Start is called before the first frame update
    void Start()
    {
        menu.gameObject.SetActive(false);
        //settingsButton = GetComponentInChildren<Button>();
    }

    public void OnClickSettingButton()
    {
        counter++;
        if (counter % 2 == 1)
        {
            menu.gameObject.SetActive(true);
            settingsButton.image.overrideSprite = secondSetting;
        }

        if (counter % 2 == 0)
        {
            menu.gameObject.SetActive(false);
            settingsButton.image.overrideSprite = firstSetting;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
