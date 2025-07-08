using System;
using System.Collections;
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
    [SerializeField] bool moveOnStart = true;
    
    void Start()
    {
        rb.maxLinearVelocity = topSpeed;
        if (moveOnStart) StartCoroutine(MoveForSeconds(1f));
    }
    
    IEnumerator MoveForSeconds(float duration)
    {
        float timer = 0f;
        while (timer < duration)
        {
            rb.AddForce(Vector3.forward * speed, ForceMode.Force);
            timer += Time.deltaTime;
            yield return null;
        }
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
