using System;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] float topSpeed;
    [SerializeField] Rigidbody rb;
    [SerializeField] Animator anim;
    Vector2 moveVal;
    Vector3 forceToApply;

    void Start()
    {
        rb.maxLinearVelocity = topSpeed;
    }

    void FixedUpdate()
    {
        if (!IsOwner) return;
        rb.AddForce(forceToApply * speed, ForceMode.Impulse);
    }

    public void Move(InputAction.CallbackContext InputContext)
    {
        if (!IsOwner) return;
        moveVal = InputContext.ReadValue<Vector2>();
       
        forceToApply = new Vector3(moveVal.x, 0, moveVal.y);
    }
}
