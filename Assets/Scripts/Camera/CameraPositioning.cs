using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CameraPositioning : MonoBehaviour
{
    private bool closeEnough = false;
    [SerializeField] private float tempSpeed;
    [SerializeField] Vector3 newPosition;

    private void Start()
    {
        closeEnough = true;
    }

    public void MoveCamera(Vector3 newPosition, Quaternion newRotation)
    {
        this.newPosition = newPosition;
        closeEnough = false;
    }

    private void Update()
    {
        if(closeEnough) return;
        var HereIAm = Vector3.Lerp(transform.position, newPosition, tempSpeed * Time.deltaTime);
        transform.position = HereIAm;
        if (Vector3.Distance(HereIAm, newPosition)< 1) closeEnough = true;
    }
    
    //if another coroutine is called, stop the last noe / overwrite
}
