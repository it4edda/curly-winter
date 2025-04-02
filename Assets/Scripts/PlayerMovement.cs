using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] Rigidbody rb;
    [SerializeField] Animator anim;
    void Update()
    {
        rb.AddForce(Vector3.right * speed);
    }
}
