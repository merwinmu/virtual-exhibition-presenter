using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportButton : MonoBehaviour
{

    public GameObject myprefab;

    // Start is called before the first frame update
    void Start()
    {
        myprefab.transform.SetParent(transform.parent, false);
        Instantiate(myprefab,new Vector3(0,0,0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
