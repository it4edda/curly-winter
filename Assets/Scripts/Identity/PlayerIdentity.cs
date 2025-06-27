using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerIdentity", menuName = "Scriptable Objects/PlayerIdentity")]
public class PlayerIdentity : ScriptableObject
{
    public Color color;
    public ChosenClass chosenClass; 
}
public enum ChosenClass
{
    Magician, Ranger, Monk, Rogue, Priest, Summoner
}
//GIVE PLAYER ITS OWN COLOR AND LET THEM CHOSE CLASS