using UnityEngine;
using Unity.Netcode;

public class PlayerSetup : NetworkBehaviour
{
    private NetworkVariable<int> playerNumber = new NetworkVariable<int>(0);

    public int PlayerNumber => playerNumber.Value;

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        
        if (IsServer)
        {
            playerNumber.Value = PlayerRegistry.Instance.GetNextPlayerNumber();
            PlayerRegistry.Instance.RegisterPlayer(this);
        }
    }

    public override void OnNetworkDespawn()
    {
        if (IsServer)
        {
            PlayerRegistry.Instance.UnregisterPlayer(OwnerClientId);
        }
    }
}