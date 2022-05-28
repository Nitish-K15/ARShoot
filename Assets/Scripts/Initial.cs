using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine;

public class Initial : MonoBehaviour
{
    public GameObject startPanel;

    ARFaceManager aRFaceManager;

    private void Start()
    {
        aRFaceManager = GetComponent<ARFaceManager>();
        startPanel.SetActive(false);
    }

    private void OnEnable()
    {
        aRFaceManager.facesChanged += FacesChanged;
    }

    private void OnDisable()
    {
        aRFaceManager.facesChanged -= FacesChanged;
    }

    void FacesChanged(ARFacesChangedEventArgs aRFacesChangedEventArgs)
    {
        if(aRFacesChangedEventArgs.updated != null && aRFacesChangedEventArgs.updated.Count == 1)
        {
            startPanel.SetActive(true);
        }
    }
}
