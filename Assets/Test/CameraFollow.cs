using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    public float distanceFromPlayer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookOnPlayer = player.position - transform.position;
        transform.forward = lookOnPlayer.normalized;

        Vector3 playerLastPos = player.position - lookOnPlayer.normalized * distanceFromPlayer;
        playerLastPos.y = player.position.y + distanceFromPlayer / 2; 
        transform.position = playerLastPos;

    }
}
