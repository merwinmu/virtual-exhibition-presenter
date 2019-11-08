using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirtualJoyStick : MonoBehaviour
{
    private Vector3 direction;
    private Vector3 touchPosition;
    private Rigidbody2D joy;
    private float moveSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        joy = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            direction = (touchPosition - transform.position);
            joy.velocity = new Vector2(direction.x, direction.y) * moveSpeed;

            if (touch.phase == TouchPhase.Ended)
                joy.velocity = Vector2.zero;
        }
    }
}