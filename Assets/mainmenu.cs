using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainmenu : MonoBehaviour
{
    public InputField exField;
    public InputField ipField;
    public string exText;
    public string ipText;

    private static string ipAdress;
    private static string exhibitionID;

    public android_settings As;

    public void startScene()
    {
        exText = exField.text;
        ipText = ipField.text;

        android_settings.VREMAddress = ipText; //PRETTY lAME AS WELL
        android_settings.exhibitionIds[0] = exText;//PRETTY lAME AS WELL

        Debug.Log(As.SaveToString());

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        TextAsset json_setting = Resources.Load<TextAsset>("settings");
        As = android_settings.CreateFromJSON(json_setting.text);
    }

    // Update is called once per frame
    void Update()
    {
    }

   
}

[System.Serializable]
public class android_settings
{
    public bool StartInLobby;
    public static string VREMAddress;
    public bool SpotsEnabled;
    public bool LobbyFloorLogoEnabled;
    public bool LobbyCeilingLogoEnabled;
    public bool CeilingLogoEnabled;
    public bool PlaygroundEnabled;
    public bool RequestExhibitions;
    public static string[] exhibitionIds = new string[1];

    public static android_settings CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<android_settings>(jsonString);
    }

    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }
}