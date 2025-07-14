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
        if (Input.anyKeyDown && menuOpen)
        {
            TitleTrigger(true);
            /*menuOpen = !menuOpen;
            anyKey.SetActive(menuOpen);
            title.SetTrigger(menuOpen ? "Open" : "Close");
            listParent.SetTrigger(!menuOpen ? "Open" : "Close");
            *///buttons appear
        }
    }
    public void TitleTrigger(bool a)
    {
        menuOpen = a;
        menuOpen = !menuOpen;
        anyKey.SetActive(menuOpen);
        title.SetTrigger(menuOpen ? "Open" : "Close");
        listParent.SetTrigger(!menuOpen ? "Open" : "Close");
    }
}
