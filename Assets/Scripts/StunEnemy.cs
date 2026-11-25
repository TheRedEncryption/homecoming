using UnityEngine;
using UnityEngine.InputSystem;

public class StunEnemy : MonoBehaviour
{
    [SerializeField] private InputActionReference stunAction;

    private void OnEnable()
    {
        stunAction.action.performed += OnToggle;
    }

    private void OnDisable()
    {
        stunAction.action.performed -= OnToggle;
    }

    private void OnToggle(InputAction.CallbackContext context)
    {
        // TODO: remember to implement stunning
    }
}
