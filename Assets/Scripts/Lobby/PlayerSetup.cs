using UnityEngine;
using Unity.Netcode;
using UnityEngine.EventSystems;

public class PlayerSetup : NetworkBehaviour
{
    private NetworkVariable<int> playerNumber = new NetworkVariable<int>(0);
    private NetworkVariable<PlayerClass> playerClass = new NetworkVariable<PlayerClass>(PlayerClass.Tank);

    public int PlayerNumber => playerNumber.Value;
    public PlayerClass PlayerClass => playerClass.Value;

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        Debug.Log("1");
        if (IsServer)
        {
            PlayerRegistry.Instance.RegisterPlayer(this);
        }

        playerNumber.OnValueChanged += OnPlayerNumberChanged;
        playerClass.OnValueChanged += OnPlayerClassChanged;

        if (IsOwner)
        {
            // Initialize with lobby manager settings
            var lobbyManager = FindObjectOfType<LobbyManager>();
            if (lobbyManager != null)
            {
                playerClass.Value = lobbyManager.GetSelectedClass();
            }
        }
    }

    public override void OnNetworkDespawn()
    {
        if (IsServer)
        {
            PlayerRegistry.Instance.UnregisterPlayer(OwnerClientId);
        }

        playerNumber.OnValueChanged -= OnPlayerNumberChanged;
        playerClass.OnValueChanged -= OnPlayerClassChanged;
    }

    public void SetPlayerNumber(int number)
    {
        if (IsServer)
        {
            playerNumber.Value = number;
        }
    }

    private void OnPlayerNumberChanged(int oldValue, int newValue)
    {
        Debug.Log($"Player {OwnerClientId} is now player number {newValue}");
    }

    private void OnPlayerClassChanged(PlayerClass oldValue, PlayerClass newValue)
    {
        Debug.Log($"Player {OwnerClientId} changed class to {newValue}");
    }
}