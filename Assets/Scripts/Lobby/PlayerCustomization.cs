using UnityEngine;
using Unity.Netcode;

public class PlayerCustomization : NetworkBehaviour
{
    [SerializeField] private SpriteRenderer playerRenderer;
    [SerializeField] private GameObject[] classModels; // Assign models in order: Tank, Sword, Mage, Priest
    [SerializeField] private Color[] availableColors; // Assign in inspector

    private NetworkVariable<Color> playerColor = new NetworkVariable<Color>(Color.white);
    private NetworkVariable<PlayerClass> playerClass = new NetworkVariable<PlayerClass>(PlayerClass.Tank);

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        
        playerColor.OnValueChanged += OnColorChanged;
        playerClass.OnValueChanged += OnClassChanged;

        // Apply initial values
        UpdateVisuals(playerColor.Value, playerClass.Value);

        if (IsOwner)
        {
            // Set initial random color
            UpdateColor(availableColors[Random.Range(0, availableColors.Length)]);
        }
    }

    // Called by UI buttons
    public void SelectColor(int colorIndex)
    {
        if (IsOwner && colorIndex >= 0 && colorIndex < availableColors.Length)
        {
            UpdateColor(availableColors[colorIndex]);
        }
    }

    // Called by UI buttons
    public void SelectClass(PlayerClass newClass)
    {
        if (IsOwner)
        {
            UpdateClass(newClass);
        }
    }

    private void UpdateColor(Color newColor)
    {
        if (IsOwner)
        {
            playerColor.Value = newColor;
        }
    }

    private void UpdateClass(PlayerClass newClass)
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

    private void UpdateVisuals(Color color, PlayerClass pClass)
    {
        //Debug.Log(color + "this is the color");
        playerRenderer.color = color;
        // Activate the appropriate class model
        for (int i = 0; i < classModels.Length; i++)
        {
            classModels[i].SetActive(i == (int)pClass);
        }
    }
}
public enum PlayerClass
{
    Tank,
    Sword,
    Mage,
    Priest
}