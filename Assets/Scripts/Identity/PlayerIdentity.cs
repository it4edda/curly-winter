using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerIdentity", menuName = "Scriptable Objects/PlayerIdentity")]
public class PlayerIdentity : ScriptableObject
{
    public bool hasSelected = false;
    public Color color;
    public ChosenClass chosenClass; 
}
public enum ChosenClass
{
    Magician, Priest, Tank, Swordsman
    //summoner? Ranger? subclasses ????
}
//GIVE PLAYER ITS OWN COLOR AND LET THEM CHOSE CLASS