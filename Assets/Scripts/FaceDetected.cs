using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine;

public class FaceDetected : MonoBehaviour
{
    ARFaceManager aRFaceManager;
    public GameObject startButton;

    private void OnEnable()
    {

        aRFaceManager = GetComponent<ARFaceManager>();
        aRFaceManager.facesChanged += FacesChanged;
    }

    private void OnDisable()
    {
        aRFaceManager.facesChanged -= FacesChanged;
    }

    void FacesChanged(ARFacesChangedEventArgs aRFacesChangedEventArgs)
    {
        if(aRFacesChangedEventArgs.updated != null && aRFacesChangedEventArgs.updated.Count>0)
        {
            startButton.SetActive(true);
        }
        if(aRFacesChangedEventArgs.removed.Count>0)
        {
            startButton.SetActive(false);
        }
    }
}
