using System;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.Netcode;
using UnityEngine;

public class CharacterSelection : NetworkBehaviour
{
    /*
    [SerializeField] Transform viewedPlane;
    [SerializeField] private float speed;
    [SerializeField] List<SelectionInfo> rotations = new List<SelectionInfo>();
    private int maxIndex;
    private int currentIndex;
    Quaternion targetRotation;
    [Header("SFX"), SerializeField] AudioSource source;
    [SerializeField] AudioClip nudge;
    [SerializeField] AudioClip affirm;
    [SerializeField] AudioClip shatter;

    private void Start() => maxIndex = rotations.Count;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) Rotate(true);
        viewedPlane.rotation = Quaternion.Lerp(viewedPlane.rotation, targetRotation, Time.deltaTime * speed);
    }

    public void Rotate(bool right)
    {
        currentIndex = (currentIndex + (right ? 1 : -1) + maxIndex) % maxIndex;
        targetRotation = Quaternion.Euler(0, rotations[currentIndex].degrees, 0);
    }
    
    public void Affirm()
    {
        //https://www.youtube.com/watch?v=VGUs8bfGapA shatter animation, requires 3dsoftware prolly
        //select the one thats pointing downward
        //DO THROW AND SHATTER ANIMATION
        
[Serializable]
struct SelectionInfo
{
    public float degrees;
    public PlayerIdentity identity;
}
    }*/
    
    public void ChooseClass()
    {
        //switch (NetworkBehaviour.)
        {
            
        }
        //PlayerIdentity ident = 
        //ident.chosenClass = ChosenClass.Magician;
    }
}

