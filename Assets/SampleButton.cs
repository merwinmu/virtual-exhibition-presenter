using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SampleButton : MonoBehaviour
{
    public Button buttonComponent;
    public Text nameLabel;
    public Vector3 entry;
    public int id;
    public Vector3 lastPosition;
    public static List<roomTeleportationPos> roomEntryPoints = new List<roomTeleportationPos>();


    private float OFFSET_X = 12;
    private float CONSTANT_Z = 1.8f;
    private float CONSTANT_Y = 1.3f;
    


    // public Image iconImage;

    // Use this for initialization
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(HandleClick);
        // buttonComponent.onClick.AddListener (HandleClick);
    }

    public void Setup(int id, Vector3 pos)
    {
        nameLabel = GetComponentInChildren<Text>();
        nameLabel.text = "RoomID: " + id;
        this.id = id;
        CalculateTeleportPos(pos);
        roomEntryPoints.Add(new roomTeleportationPos(id,entry));
        PlayerMovement.roomID = id;

    }

    public void CalculateTeleportPos(Vector3 position)
    {
        entry = position;
        entry.x = position.x * OFFSET_X;
        entry.z = CONSTANT_Z;
        entry.y = CONSTANT_Y;
        lastPosition = entry;
    }

    public void HandleClick()
    {
        Debug.Log(entry.ToString());
        PlayerMovement.Teleport(lastPosition);
        PlayerMovement.roomID = id;
    }
    
     

  
}
public class roomTeleportationPos
{
     public int id;
     public Vector3 currentPos;
   public  roomTeleportationPos(int id, Vector3 currentPos)
    {
        this.id = id;
        this.currentPos = currentPos;
    }
   
}

