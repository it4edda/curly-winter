using UnityEngine;
using Unity.Netcode;

public class PlayerCustomization : NetworkBehaviour
{
    public static PlayerCustomization Instance { get; private set; }

    [SerializeField] private Renderer playerRenderer;
    [SerializeField] private GameObject[] classModels; // Assign models in order: Tank, Sword, Mage, Priest

    private NetworkVariable<Color> playerColor = new NetworkVariable<Color>(Color.white);
    private NetworkVariable<PlayerClass> playerClass = new NetworkVariable<PlayerClass>(PlayerClass.Tank);

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
                Debug.Log("2");
        playerColor.OnValueChanged += OnColorChanged;
        playerClass.OnValueChanged += OnClassChanged;

        if (IsOwner)
        {
            // Initialize with default values
            var lobbyManager = FindObjectOfType<LobbyManager>();
            if (lobbyManager != null)
            {
                playerColor.Value = lobbyManager.GetSelectedColor();
                playerClass.Value = lobbyManager.GetSelectedClass();
            }
        }

        // Apply initial values
        UpdateVisuals(playerColor.Value, playerClass.Value);
    }

    public void UpdateColor(Color newColor)
    {
        if (IsOwner)
        {
            playerColor.Value = newColor;
        }
    }

    public void UpdateClass(PlayerClass newClass)
    {
        if (IsOwner)
        {
            playerClass.Value = newClass;
        }
    }

    private void OnColorChanged(Color oldColor, Color newColor)
    {
        UpdateVisuals(newColor, playerClass.Value);
    }

    private void OnClassChanged(PlayerClass oldClass, PlayerClass newClass)
    {
        UpdateVisuals(playerColor.Value, newClass);
    }

    private void UpdateVisuals(Color color, PlayerClass playerClass)
    {
        playerRenderer.material.color = color;
        
        // Activate the appropriate class model
        for (int i = 0; i < classModels.Length; i++)
        {
            classModels[i].SetActive(i == (int)playerClass);
        }
    }
}