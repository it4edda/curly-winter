using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerRegistry : NetworkBehaviour
{
    public static PlayerRegistry Instance { get; private set; }

    private Dictionary<ulong, PlayerSetup> players = new Dictionary<ulong, PlayerSetup>();
    private int nextPlayerNumber = 1;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void RegisterPlayer(PlayerSetup playerSetup)
    {
        if (!players.ContainsKey(playerSetup.OwnerClientId))
        {
            players.Add(playerSetup.OwnerClientId, playerSetup);
            playerSetup.SetPlayerNumber(nextPlayerNumber++);
        }
    }

    public void UnregisterPlayer(ulong clientId)
    {
        if (players.ContainsKey(clientId))
        {
            players.Remove(clientId);
        }
    }

    public PlayerSetup GetPlayer(ulong clientId)
    {
        return players.TryGetValue(clientId, out PlayerSetup player) ? player : null;
    }

    public Dictionary<ulong, PlayerSetup> GetAllPlayers()
    {
        return new Dictionary<ulong, PlayerSetup>(players);
    }

    public int GetPlayerCount()
    {
        return players.Count;
    }
}