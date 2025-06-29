using System;
using System.Linq.Expressions;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] AttackType type;
    [SerializeField] GameObject slashObject;
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
}

enum AttackType
{
    melee, mage, 
}