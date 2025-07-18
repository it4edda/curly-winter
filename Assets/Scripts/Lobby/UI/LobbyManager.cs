using Unity.Netcode;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{
    #region manager stuff og
    [Header("UI References")]
    [SerializeField] private Button[] colorButtons;
    [SerializeField] private Button[] classButtons;

    private PlayerCustomization localPlayerCustomization;
 
    private void Start()
    {
        // Wait for local player to spawn
        NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
        
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
    }

    private void OnClientConnected(ulong clientId)
    {
        if (clientId == NetworkManager.Singleton.LocalClientId)
        {
            localPlayerCustomization = NetworkManager.Singleton.LocalClient.PlayerObject
                .GetComponent<PlayerCustomization>();
        }
    }

    private void OnColorSelected(int colorIndex)
    {
        localPlayerCustomization?.SelectColor(colorIndex);
    }

    private void OnClassSelected(PlayerClass playerClass)
    {
        localPlayerCustomization?.SelectClass(playerClass);
    }

    private void OnDestroy()
    {
        if (NetworkManager.Singleton != null)
        {
            NetworkManager.Singleton.OnClientConnectedCallback -= OnClientConnected;
        }
    }
    #endregion
    #region Visuals
    [FormerlySerializedAs("anim")]
    [Header("Visuals")]
    [SerializeField] private Animator HostAnim;
    [SerializeField] Animator LeaveAnim;
    public void HostVisuals(bool isHosting)
    {
        HostAnim.SetBool("IsHosting", isHosting);
        HostAnim.SetTrigger("Active");
        //if is hosting / show hosting and hide joining
        //else hide hosting and show joinging
    }
    public void InLobbyVisuals(bool inLobby)
    {
        LeaveAnim.SetBool("In", inLobby);
        LeaveAnim.SetTrigger("Active");
    }
    #endregion
    
    
    
    
}