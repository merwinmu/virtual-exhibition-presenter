using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController control;
    public JoyStickFaris joystick;

    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //float x = Input.GetAxis("Horizontal");
        //float z = Input.GetAxis("Vertical");
        float x = joystick.Horizontal();
        float z = joystick.Vertical();


        Vector3 move = transform.right * x + transform.forward * z;
        control.Move(move * speed * Time.deltaTime);
    }
}
