using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable] [CreateAssetMenu(menuName = "Art")]
public class Art : ScriptableObject
{
    public List<ElementalProperties> ElementalRequirements = new();
}
