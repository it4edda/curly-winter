using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Orbment : MonoBehaviour
{
    [SerializeField] List<Quarts> equipedQuarts = new();
    [SerializeField] List<ElementalProperties> currentProperties = new();

    void Start()
    {
        ElementalValueCheck();
    }

    void ElementalValueCheck()
    {
        Debug.Log("Started");
        foreach (ElementalProperties elementalProperty in equipedQuarts.SelectMany(quarts => quarts.elementalPropertiesList))
        {
            Debug.Log("middle");
            bool isInList = false;

            for (var i = 0; i < currentProperties.Count; i++)
            {
                ElementalProperties currentProperty = currentProperties[i];
                if (currentProperty.elements == elementalProperty.elements)
                {
                    isInList = true;
                    currentProperty.numberOfElement += elementalProperty.numberOfElement;
                    currentProperties[i] = currentProperty;
                }
            }

            if (!isInList)
            {
                currentProperties.Add(elementalProperty);
            }
        }
        ArtsCheck();
    }

    void ArtsCheck()
    {
        
    }
}
[Serializable]
public struct ElementalProperties
{
    public Elements elements;
    public int numberOfElement;
}

[Serializable]
public enum Elements
{
    Earth,
    Watter,
    Fire,
    Air
}