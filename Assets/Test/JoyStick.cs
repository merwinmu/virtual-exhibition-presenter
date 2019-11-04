using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class JoyStick : MonoBehaviour
{
    public Transform player;
    public float speed = 5.0f;
    private bool touchStart = false;
    private Vector3 pointA;
    private Vector3 pointB;

    public Transform circle;
    public Transform outerCircle;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move(new Vector3(Input.GetAxis("Horizontal"),0f,Input.GetAxis("Vertical")));

       if (Input.GetMouseButtonDown(0))
       {
           pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Camera.main.transform.position.y, Input.mousePosition.z));

           circle.transform.position = pointA * -1;
           outerCircle.transform.position = pointA * -1;
           circle.GetComponent<SpriteRenderer>().enabled = true;
           outerCircle.GetComponent<SpriteRenderer>().enabled = true;
       }

       if (Input.GetMouseButton(0))
       {
           touchStart = true;
           pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Camera.main.transform.position.y, Input.mousePosition.z));
       }
       else
       {
           touchStart = false;
       }
    }

   private void FixedUpdate()
    {
        if (touchStart)
        {
            Vector3 offset = pointB - pointA;
            Vector3 direction = Vector3.ClampMagnitude(offset, 1.0f);
            move(direction * -1);
            
            circle.transform.position = new Vector3(pointA.x + direction.x, 0f, pointA.z + direction.z) * -1;
        }
        else
        {
            circle.GetComponent<SpriteRenderer>().enabled = false;
            outerCircle.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void move(Vector3 direction)
    {
        player.Translate(direction * speed * Time.deltaTime);
    }
}
