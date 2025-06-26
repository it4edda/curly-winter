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
        Debug.Log("Started");
        foreach (ElementalProperties elementalProperties in equipedQuarts.SelectMany(quarts => quarts.elementalPropertiesList))
        {
            Debug.Log("middle");
            for (var i = 0; i < currentProperties.Count; i++)
            {
                ElementalProperties currentProperty = currentProperties[i];
                if (currentProperty.elements == elementalProperties.elements)
                {
                    currentProperty.numberOfElement += elementalProperties.numberOfElement;
                    currentProperties[i] = currentProperty;
                }
                else
                {
                    currentProperties.Add(elementalProperties);
                }
            }
        }
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