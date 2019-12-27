using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class gyroControl : MonoBehaviour
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
        public float dir = -1;
        
    
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
                ShowToast("No Gyrosope detected");
                InteractionButton = false;
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
                rotX -= deltaY * Time.deltaTime * rotSpeed * dir;
                rotY += deltaX * Time.deltaTime * rotSpeed * dir;
                rotX = Mathf.Clamp(rotX, -90f, 60f);
                transform.eulerAngles = new Vector3(rotX,rotY,0f);

            }
            else if(touch.phase == TouchPhase.Ended)
            {
                initTouch = new Touch();
            }
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
    
    
    private void ShowToast(string message)
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        if (unityActivity != null)
        {
            AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
            unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                AndroidJavaObject toastObject = toastClass.CallStatic<AndroidJavaObject>("makeText", unityActivity, message, 0);
                toastObject.Call("show");
            }));
        }
    }
}
