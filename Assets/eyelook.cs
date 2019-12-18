using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyelook : MonoBehaviour
{
    
    private Vector2 mD;

    // Start is called before the first frame update
    void Start()
    {

    
}

    // Update is called once per frame
    void Update()
    {
        Vector2 mC = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        mD += mC;
    }
}
