using System;
using System.Collections.Generic;
using UnityEngine;

public class ArtManager : MonoBehaviour
{
    public static ArtManager Instance;
    public List<Art> allArts = new();

    void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }
}
