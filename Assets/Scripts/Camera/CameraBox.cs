using System;
using Unity.Mathematics;
using UnityEngine;

public class CameraBox : MonoBehaviour
{
    [SerializeField] Vector3 myCommandPosition;
    private void OnTriggerEnter(Collider other)
    {
        var a = Camera.main.GetComponent<CameraPositioning>();
        a.MoveCamera(myCommandPosition, quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(myCommandPosition, 2);
    }
}
