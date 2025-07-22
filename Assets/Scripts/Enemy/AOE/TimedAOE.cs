using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TimedAOE : MonoBehaviour
{
    [Header("MAKE SURE THE ENEMY CAN REACT TO THE AOE")]
    [SerializeField] private float timer;
    [SerializeField] TMP_Text display;
    [SerializeField] ParticleSystem activatedParticles;
    [SerializeField] Collider collider;

    private void Update()
    {
        timer -= Time.deltaTime;
        display.text = Mathf.RoundToInt(timer).ToString();
        if (timer <= 0)
        {
            Debug.Log("THERES A LOT TO FIX HERE, CHECK COMMENTS ");
            activatedParticles.Play();
            collider.enabled = true;
            
            //on trigger enter whatever

            //KILL THE AOE OBJECT HAHAHAHA
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("I think you took damage :D, shit player");
    }
}

//MAKE TIMER MORE DYNAMIC (<2 sec visa 1 decimal, <1 sec visa 2 decimal typ)

//DOUBLE-CHECK THE LAYERS IN UNITY SETTINGS
//MAKE SURE THE AOE ONLY INTERACTS WITH THE PLAYER


//MAke a new script "BossAttackPattern" or something that spawns in objects such as this one in a position every x time whatever.
//Liknande till vi gjorde i cardinal
