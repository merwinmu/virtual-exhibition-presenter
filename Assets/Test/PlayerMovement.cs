using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static CharacterController control;

    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        control = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
       // float x = SimpleInput.GetAxis("Horizontal");
      //float z = SimpleInput.GetAxis("Vertical");

      float x = merwintouch.direction.x;
      float z = merwintouch.direction.z;
        

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
