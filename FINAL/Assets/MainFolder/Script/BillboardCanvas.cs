using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardCanvas : MonoBehaviour
{
    public Camera mainCamera;  

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = FindFirstObjectByType<Camera>(); 
        }
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward,
                         mainCamera.transform.rotation * Vector3.up);
    }
}
