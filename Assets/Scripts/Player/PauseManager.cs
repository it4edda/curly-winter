using UnityEngine;
using Unity.Netcode;

public class NetworkPauseManager : NetworkBehaviour
{
    private static NetworkPauseManager _instance;
    public static NetworkPauseManager Instance 
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<NetworkPauseManager>();
                
                if (_instance == null)
                {
                    Debug.LogError("No NetworkPauseManager found in scene! Please add one to your network prefabs.");
                }
            }
            return _instance;
        }
    }

    private NetworkVariable<bool> _isPaused = new NetworkVariable<bool>(false);
    public bool IsPaused => _isPaused.Value;

    [SerializeField] private GameObject _pauseUI;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        _instance = this;
        
        // Don't destroy as it's now a network object
        // NetworkManager will handle its lifecycle
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        
        _isPaused.OnValueChanged += OnPauseStateChanged;
        
        // Initialize UI state
        if (_pauseUI != null)
        {
            _pauseUI.SetActive(_isPaused.Value);
        }
    }

    private void OnPauseStateChanged(bool previous, bool current)
    {
        Time.timeScale = current ? 0f : 1f;
        
        if (_pauseUI != null)
        {
            _pauseUI.SetActive(current);
        }
    }

    [ServerRpc(RequireOwnership = false)]
    public void TogglePauseServerRpc(ServerRpcParams rpcParams = default)
    {
        _isPaused.Value = !_isPaused.Value;
    }

    public void RequestTogglePause()
    {
        if (IsServer)
        {
            // Host can directly modify
            _isPaused.Value = !_isPaused.Value;
        }
        else
        {
            // Clients send request to server
            TogglePauseServerRpc();
        }
    }
}