using System;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStickScript : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{

    private Image circleImg;
    private Image padImg;
    private Vector3 inputVector;
    
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector3.zero;
        padImg.rectTransform.anchoredPosition = Vector3.zero;
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        Vector2 pos = Vector2.zero;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(circleImg.rectTransform, 
                                                                    eventData.position, 
                                                                    eventData.pressEventCamera,
                                                                    out pos))
        {
            pos.x = (pos.x / circleImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / circleImg.rectTransform.sizeDelta.y);
            
            inputVector = new Vector3(pos.x * 2 + 1, 0, pos.y * 2 - 1);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;
            
            padImg.rectTransform.anchoredPosition = new Vector3(inputVector.x * (circleImg.rectTransform.sizeDelta.x / 3),
                inputVector.z * (circleImg.rectTransform.sizeDelta.y / 3));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        circleImg = GetComponent<Image>();
        padImg = transform.GetChild(0).GetComponent<Image>();
    }

    public float Horizontal()
    {
        if (inputVector.x != 0)
        {
            return inputVector.x;
        }
        else
        {
            return Input.GetAxis("Horizontal");
        }
    }
    
    public float Vertical()
    {
        if (inputVector.z != 0)
        {
            return inputVector.z;
        }
        else
        {
            return Input.GetAxis("Vertical");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //move(new Vector3(Input.GetAxis("Horizontal"),0f,Input.GetAxis("Vertical")));


    }
}
