using System;
using UnityEngine;
using Unity.Netcode;

public class PlayerSpawner : MonoBehaviour
{
    // int amount of players in server
    [SerializeField, Range(0,4)] int  playerCount = 0; //MAX 4
    [SerializeField] GameObject playerPrefab;
    [SerializeField] PlayerRegistry registry;
    
    //for each player spawn a player ( i )
    // assign i for the players ownership (first value in the for loop) for each player in lobby
    
    // do this after generating the level, / map
    //the player prefab starts running forward on spawn, so make a object that keeps them from running back again ?
    private void Start()
    {
        registry = FindObjectOfType<PlayerRegistry>();
        //playerCount = registry.
    }

    public void SpawnPlayers()
    {
        if (playerCount < 0)
        {
            Debug.Log("something is wrong");
            return;
        }
        for (int i = 0; i < playerCount; i++)
        {
            var a = Instantiate(playerPrefab);
            //ulong the player id
            //MAKE A SCRIPTABLE OBJECT FOR THE PLAYERS INFO
        }
    }
}
