using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static CharacterController control;
    public JoyStickScript joystick;

    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        control = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = joystick.Horizontal();
        float z = joystick.Vertical();
        

        Vector3 move = transform.right * x + transform.forward * z;
        control.Move(move * speed * Time.deltaTime);
        
        //Debug.Log(control.transform.position);
    }

    public static void Teleport(Vector3 pos)
    {
        control.enabled = false;
        control.transform.position = pos;
        control.enabled = true;
    }
}
