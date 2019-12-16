using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {


    }

    private void PrintName(GameObject go)
    {

    }

    // Update is called once per frame
    void Update()
    {
        
   
    if(Input.GetMouseButtonDown(0))
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform !=null)
            {
                Debug.Log(hit.transform.gameObject);
            }
        }
    }
    }
}
