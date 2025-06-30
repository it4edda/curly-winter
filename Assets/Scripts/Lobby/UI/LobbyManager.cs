using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public enum PlayerClass
{
    Tank,
    Sword,
    Mage,
    Priest
}

public class LobbyManager : NetworkBehaviour
{
    [Header("UI References")]
    [SerializeField] private Button[] colorButtons;
    [SerializeField] private Button[] classButtons;

    [Header("Player Customization")]
    [SerializeField] private Color[] availableColors;
    
    private NetworkVariable<int> selectedColorIndex = new NetworkVariable<int>(0);
    private NetworkVariable<PlayerClass> selectedClass = new NetworkVariable<PlayerClass>(PlayerClass.Tank);

    private void Start()
    {
        if (IsHost)
        {
            // Host initial setup
            selectedColorIndex.Value = 0;
            selectedClass.Value = PlayerClass.Tank;
        }

        // Setup color buttons
        for (int i = 0; i < colorButtons.Length; i++)
        {
            int index = i;
            colorButtons[i].onClick.AddListener(() => OnColorSelected(index));
        }

        // Setup class buttons
        for (int i = 0; i < classButtons.Length; i++)
        {
            int index = i;
            classButtons[i].onClick.AddListener(() => OnClassSelected((PlayerClass)index));
        }

        // Subscribe to changes
        selectedColorIndex.OnValueChanged += OnColorChanged;
        selectedClass.OnValueChanged += OnClassChanged;
    }

    private void OnColorSelected(int colorIndex)
    {
        if (IsClient && IsOwner)
        {
            selectedColorIndex.Value = colorIndex;
        }
    }

    private void OnClassSelected(PlayerClass playerClass)
    {
        if (IsClient && IsOwner)
        {
            selectedClass.Value = playerClass;
        }
    }

    private void OnColorChanged(int oldValue, int newValue)
    {
        // Update visuals when color changes
        if (IsOwner)
        {
            PlayerCustomization.Instance?.UpdateColor(availableColors[newValue]);
        }
    }

    private void OnClassChanged(PlayerClass oldValue, PlayerClass newValue)
    {
        // Update visuals when class changes
        if (IsOwner)
        {
            PlayerCustomization.Instance?.UpdateClass(newValue);
        }
    }

    public Color GetSelectedColor()
    {
        return availableColors[selectedColorIndex.Value];
    }

    public PlayerClass GetSelectedClass()
    {
        return selectedClass.Value;
    }
}