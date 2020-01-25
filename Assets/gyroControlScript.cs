using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class gyroControlScript : MonoBehaviour
{
    private static bool InteractionButton;
    private bool gyroEnabled;
    private Gyroscope gyro;

    private GameObject cameraContainer;
    private Quaternion rot;
    
    private Touch initTouch = new Touch();
        
    
        private float rotX = 0f;
        private float rotY = 0f;
        private Vector3 origRot;
    
        public float rotSpeed = 0.5f;
        public static float dir = -1;


        public float SpeedH = 5f;
     public float SpeedV = 5f;
 
     private float yaw = 0f;
     private float pitch = 0f;
     private float minPitch = -30f;
     private float maxPitch = 90f;
        
     
    
// Start is called before the first frame update
    void Start()
    {
         origRot = transform.eulerAngles;
         rotX = origRot.x;
         rotY = origRot.y;
         
        cameraContainer = new GameObject("Camera Container");
        cameraContainer.transform.position = transform.position;
        transform.SetParent(cameraContainer.transform);
        gyroEnabled = EnableGyro();
        InteractionButton = false;
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
            {
                gyro = Input.gyro;
                gyro.enabled = true;

                cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
                rot = new Quaternion(0,0,1,0);
                return true;
            }
        return false;
        
    }
    

    // Update is called once per frame
    void Update()
    {

        if (Application.platform != RuntimePlatform.Android)
        {
            mouse();
        }

        else
        {
            if (!InteractionButton)
            {
                swiper();
            }
            else
            {
                if (gyroEnabled)
                {
                    transform.localRotation = gyro.attitude * rot;
                }
                else
                {
                    InteractionButton = false;
                }
            }
        }
      
    }

    void swiper()
    {
        foreach (Touch touch in Input.touches)
        {
            int pointerID = touch.fingerId;

            if (EventSystem.current.IsPointerOverGameObject(pointerID))
            {
                return;
            }
            
            if (touch.phase == TouchPhase.Began)
            {
                initTouch = touch;
            }
            else if (touch.phase==TouchPhase.Moved)
            {
                //swipping
                float deltaX = initTouch.position.x - touch.position.x;
                float deltaY = initTouch.position.y - touch.position.y;
                pitch -= deltaY * Time.deltaTime * rotSpeed * dir;
                yaw += deltaX * Time.deltaTime * rotSpeed * dir;
                pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
                transform.eulerAngles = new Vector3(pitch,yaw,0f);
                
             

            }
            else if(touch.phase == TouchPhase.Ended)
            {
                initTouch = new Touch();
            }
        }
    }


    void mouse()
    {
        {
            yaw += Input.GetAxis("Mouse X") * SpeedH;
            pitch -= Input.GetAxis("Mouse Y") * SpeedV;
            pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
            transform.eulerAngles = new Vector3(pitch, yaw, 0f);
        }
    }


    public static bool GetInteractionButton()
    {
        return InteractionButton;
    }

    public static void SetInteractionButton(bool flag)
    {
        InteractionButton = flag;
    }
}
