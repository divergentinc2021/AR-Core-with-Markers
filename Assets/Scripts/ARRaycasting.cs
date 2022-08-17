using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class ARRaycasting : MonoBehaviour
{

    public ARRaycastManager arRaycastManager;

    private List<ARRaycastHit> raycastHitList = new List<ARRaycastHit>();

    public Text Infotext;

    public GameObject prefab;

    public GameObject ARPlaneManager;

    public GameObject InitialPrefab;

    GameObject Spawnpoint;
    //GameObject CurrentlySelected { get; private set; }
    GameObject CurrentlySelected;
    private void Start()
    {
        Spawnpoint = Instantiate(InitialPrefab, ARPlaneManager.transform);
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount < 1)
        {
            return;
        }


        if (arRaycastManager.Raycast(Input.GetTouch(0).position, raycastHitList, TrackableType.AllTypes))
        {
            Vector3 hitPosition = raycastHitList[0].pose.position;

            switch (Input.GetTouch(0).phase)
            {
                case TouchPhase.Began:
                    Destroy(Spawnpoint);
                    Destroy(Infotext);
                    Destroy(CurrentlySelected);
                    CurrentlySelected = Instantiate(prefab, hitPosition, Quaternion.identity, null);
                    break;

                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    PlaceInstanceWithOffset((CurrentlySelected, hitPosition));
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    StartCoroutine(DropOntoFloor((CurrentlySelected, hitPosition)));
                    break;
            
            }
        }
    }

    private string DropOntoFloor((object CurrentlySelected, Vector3 hitPosition) p)
    {
        throw new System.NotImplementedException();
    }

    private void PlaceInstanceWithOffset((object CurrentlySelected, Vector3 hitPosition) p)
    {
        throw new System.NotImplementedException();
    }
}
