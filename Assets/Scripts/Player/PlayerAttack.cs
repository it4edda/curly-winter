using System;
using System.Linq.Expressions;
using Unity.Mathematics;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] AttackType type;
    [Header("Melee")]
    [SerializeField] GameObject slashObject;
    [Header("Mage")]
    [SerializeField] ParticleSystem magicMissile;
    [SerializeField] GameObject attractPoint;
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.L))
        switch (type)
        {
            case AttackType.melee: Attack();
                break;
            default: 
                break;
        }
    }
    void Attack()
    {
        slashObject.SetActive(true);
    }
    void MagicMissile()
    {
        magicMissile.Play();
        Instantiate(attractPoint, Input.mousePosition, quaternion.identity);
    }
}

enum AttackType
{
    melee, mage, 
}