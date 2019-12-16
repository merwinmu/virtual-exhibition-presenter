
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainmenu : MonoBehaviour
{
    public InputField exField;
    public InputField ipField;
    public string exText;
    public string ipText;

    private  string ipAdress;
    private  string exhibitionID;

    public android_settings As;

    private static string DEFAULT_IP = "http://10.34.58.45:9876/" ;
    private static string DEFAULT_ID = "5dc999c707aa7b0f23a335ec";

    public void startScene()
    {
        exText = exField.text;
        ipText = ipField.text;
  if (exText.Equals("") && ipText.Equals(""))
        {
            android_settings.exhibitionIds[0] = DEFAULT_ID;
            android_settings.VREMAddress = DEFAULT_IP;
            
        }
        else
        {
            android_settings.VREMAddress = ipText; //PRETTY lAME AS WELL
            android_settings.exhibitionIds[0] = exText;//PRETTY lAME AS WELL
        }
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