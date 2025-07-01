using System;
using Unity.Netcode;
using UnityEngine;

public class PlayerAim : NetworkBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] Transform weapon;
    [SerializeField] Transform character;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (!IsOwner) return;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        Plane groundPlane = new Plane(Vector3.up, new Vector3(0, character.position.y, 0));

        if (groundPlane.Raycast(ray, out float enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            Vector3 direction = hitPoint - weapon.position;
            direction.y = 0;

            weapon.rotation = Quaternion.LookRotation(direction);
        }
    }
}

