using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonControlle : MonoBehaviour
{
    [Range(10f,100f)] 
    public float mouseSensivitiy = 70f;
    float horizontal;
    float vertical;
    float mouseX;
    float mouseY;
    Quaternion deltaRotation;
    Vector3 deltaPosition;
    
    Rigidbody rbody;

    void GetInputs(){
    mouseX = Input.GetAxis("Mouse X");
    mouseY = Input.GetAxis("Mouse Y");
    horizontal = Input.GetAxis("Horizontal");
    vertical = Input.GetAxis("Vertical");
    Input.GetButton("Jump");
     
    
        }
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    GetInputs();
    }
    private void FixedUpdate(){
    deltaRotation = Quaternion.Euler(Vector3.up * mouseX * Time.deltaTime);
    rbody.MoveRotation(rbody.rotation * deltaRotation);
   
    }
    
}
