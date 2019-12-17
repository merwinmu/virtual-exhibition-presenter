using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SampleButton : MonoBehaviour {
    
    public Button buttonComponent;
    public Text nameLabel;
    public Vector3 entry;

    private float OFFSET_X = 12;
    private float CONSTANT_Z = 1.8f;
    private float CONSTANT_Y = 0.11f;
    
    // public Image iconImage;

    // Use this for initialization
    void Start () 
    {
        GetComponent<Button>().onClick.AddListener(HandleClick);
       // buttonComponent.onClick.AddListener (HandleClick);
    }

    public void Setup(int id, Vector3 pos)
    {
        nameLabel = GetComponentInChildren<Text>();
        nameLabel.text = "RoomID: "+ id;

        CalculateTeleportPos(pos);
    }

    public void CalculateTeleportPos(Vector3 position)
    {
        entry = position;
        entry.x = position.x * OFFSET_X;
        entry.z = CONSTANT_Z;
        entry.y = CONSTANT_Y;
    }

    public void HandleClick()
    {
        Debug.Log(entry.ToString());
        PlayerMovement.Teleport(entry);
    }
}