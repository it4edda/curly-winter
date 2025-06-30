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
        }
    }

    public void UnregisterPlayer(ulong clientId)
    {
        players.Remove(clientId);
    }

    public int GetNextPlayerNumber()
    {
        return nextPlayerNumber++;
    }

    public PlayerSetup GetPlayer(ulong clientId)
    {
        return players.TryGetValue(clientId, out PlayerSetup player) ? player : null;
    }
}