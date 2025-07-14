using System;
using Unity.Mathematics;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    [SerializeField] Animator title;
    [SerializeField] GameObject anyKey;
    [SerializeField] Animator listParent;
    bool menuOpen = true;
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            
            menuOpen = !menuOpen;
            anyKey.SetActive(menuOpen);
            title.SetTrigger(menuOpen ? "Open" : "Close");
            listParent.SetTrigger(!menuOpen ? "Open" : "Close");
            //buttons appear
        }
    }
}
