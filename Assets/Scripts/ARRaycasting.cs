using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.Events;

public class ARRaycasting : MonoBehaviour
{
    public int fingerID;

    public ARRaycastManager arRaycastManager;

    private List<ARRaycastHit> raycastHitList = new List<ARRaycastHit>();

    public GameObject AnchorPlacement;

    public ARPlane ARPlaneManager;

    public GameObject Infotext;

    //declare event types to listen to
    public UnityEvent onBegan;
    public UnityEvent onStationary;
    public UnityEvent onMoved;
    public UnityEvent onEnded;
    public UnityEvent onCancelled;

    GameObject AnchorObj;

    // Update is called once per frame
    void Update()
    {
        detecttouch();
        Anchordetect();
    }

    public void Anchordetect()
    {
        if (Input.touchCount < 1)
        {
            AnchorObj = Instantiate(AnchorPlacement, ARPlaneManager.transform);
            return;
        }
    }

    public void detecttouch()
    {
        int touchCount = Input.touchCount;


        for (int i = 0; i < touchCount; i++)
        {
            if (Input.GetTouch(i).fingerId == fingerID)
            {
                Destroy(Infotext);
                Destroy(AnchorObj);
                arRaycastManager.Raycast(Input.GetTouch(i).position, raycastHitList, TrackableType.AllTypes);
                //Debug.Log("Getting Touch Finger ID");
                Vector3 hitposition = raycastHitList[i].pose.position;
                ProcessPhase(Input.GetTouch(i).phase);
                //print(MovingObject.transform.position);
            }
        }

    }

    public void ProcessPhase(TouchPhase phase)
    {
            switch (phase)
            {
                case TouchPhase.Began:
                    onBegan.Invoke();
                    break;
                case TouchPhase.Stationary:
                    onStationary.Invoke();
                    break;
                case TouchPhase.Moved:
                    onMoved.Invoke();
                    break;
                case TouchPhase.Ended:
                    onEnded.Invoke();
                    break;
                case TouchPhase.Canceled:
                    onCancelled.Invoke();
                    break;
            }
    }



}
