using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Netcode;

[RequireComponent(typeof(NetworkObject))]
public class AdvancedPlayerInput : NetworkBehaviour
{
    [Header("Input Actions")]
    [SerializeField] private InputActionReference pauseAction;

    private void OnEnable()
    {
        if (pauseAction != null && IsOwner)
        {
            pauseAction.action.Enable();
            pauseAction.action.performed += OnPausePerformed;
        }
    }

    private void OnDisable()
    {
        if (pauseAction != null && IsOwner)
        {
            pauseAction.action.performed -= OnPausePerformed;
        }
    }

    private void OnPausePerformed(InputAction.CallbackContext context)
    {
        if (!IsOwner) return;
        
        NetworkPauseManager.Instance?.RequestTogglePause();
    }
}