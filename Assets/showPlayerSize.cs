using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showPlayerSize : MonoBehaviour
{
   
    private float sliderValue;
    public GameObject FirstPerson;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    
    // Update is called once per frame
    void Update()
    {
       
    }

    public void updateHeight()
    {
        sliderValue = slider.value;
        Vector3 temp = FirstPerson.transform.position;
        temp.y = sliderValue;
        FirstPerson.transform.position = temp;
    }
}
