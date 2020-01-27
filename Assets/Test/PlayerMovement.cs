using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public static CharacterController control;
    float x;
    float z;
    private Vector3 move;

    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        control = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Application.platform != RuntimePlatform.Android)
        {
            x = Input.GetAxis("Horizontal") * speed;
            z = Input.GetAxis("Vertical") * speed;

            if (Input.GetKey("escape"))
            {
                Application.Quit();
            }

        }
        else
        {
             x = JoyStickScript.direction.x;
             z = JoyStickScript.direction.z;
        }
        
        move = transform.right * x + transform.forward * z;
        move.y = 0;
        control.Move(move * speed * Time.deltaTime);

    }

    public static void Teleport(Vector3 pos)
    {
        control.enabled = false;
        control.transform.position = pos;
        control.enabled = true;
    }
}

