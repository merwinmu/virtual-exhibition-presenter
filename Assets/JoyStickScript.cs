using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoyStickScript : MonoBehaviour,IDragHandler,IPointerUpHandler,IPointerDownHandler
{
    [Header("Tweaks")] [SerializeField] private float joystickVisualDistance = 50;
    [Header("Logic")] private Image joystick;
    private Image container;
    public static Vector3 direction;
    public GameObject InfoWindow;

    public Vector3 Direction
    {
        get { return direction; }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            var imgs = GetComponentsInChildren<Image>();
            container = imgs[0];
            joystick = imgs[1];
            StartCoroutine(RemoveAfterSeconds(1, InfoWindow));
        }
        else
        {
            GameObject joy = GameObject.FindGameObjectWithTag("joy");
            joy.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrag(PointerEventData ped)
    {
        Vector2 pos = Vector2.zero;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(container.rectTransform, ped.position,
            ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x / container.rectTransform.sizeDelta.x);
            pos.y = (pos.y / container.rectTransform.sizeDelta.y);
            
            Vector2 refpivot = new Vector2(0.5f,0.5f);
            Vector2 p = container.rectTransform.pivot;
            pos.x += p.x - 0.5f;
            pos.y += p.y - 0.5f;

            float x = Mathf.Clamp(pos.x, -1, 1);
            float y = Mathf.Clamp(pos.y, -1, 1);
            
            direction = new Vector3(x,0,y);
            Debug.Log(direction);
            
            joystick.rectTransform.anchoredPosition  = new Vector3(x*joystickVisualDistance,y*joystickVisualDistance);

        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        direction = default(Vector3);
        joystick.rectTransform.anchoredPosition = default(Vector3);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }
    
    IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
    {
        obj.gameObject.SetActive(true);
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);
    }
}
