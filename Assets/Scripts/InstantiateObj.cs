using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class InstantiateObj : MonoBehaviour
{
    //public ARRaycastManager arRaycastManager_act;

    //private List<ARRaycastHit> raycastHitList = new List<ARRaycastHit>();

    public GameObject NewObj;

    public ARPlane ARPlaneManager;

    public ARRaycastHit RaycastingElement;

    GameObject Spawned;
    //Vector3 Hitposition = raycastHitList[0].pose.position;

    public void spawnobj()
    {
        Destroy(Spawned);
        Spawned = Instantiate(NewObj, RaycastingElement.trackable.transform);
    }


    //private string DropOntoFloor((object CurrentlySelected, Vector3 hitPosition) p)
    //{
        //throw new System.NotImplementedException();
    //}

    //private void PlaceInstanceWithOffset((object CurrentlySelected, Vector3 hitPosition) p)
    //{
        //throw new System.NotImplementedException();
    //}
}
