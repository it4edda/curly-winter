using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable] [CreateAssetMenu(menuName = "Quart")]
public class Quarts : ScriptableObject
{
    public List<ElementalProperties> elementalPropertiesList = new();
}
