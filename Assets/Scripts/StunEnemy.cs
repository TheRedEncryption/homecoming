using UnityEngine;
using UnityEngine.InputSystem;

public class StunEnemy : MonoBehaviour
{
    [SerializeField] private InputActionReference stunAction;
    [SerializeField] private float maxRange = 100f;

    private void OnEnable()
    {
        stunAction.action.Enable();
        stunAction.action.performed += OnClick;
    }

    private void OnDisable()
    {
        stunAction.action.performed -= OnClick;
        stunAction.action.Disable();
    }

    private void OnClick(InputAction.CallbackContext context)
    {
        Debug.Log("Click!");
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (Physics.Raycast(ray, out RaycastHit hit, maxRange))
        {
            Debug.Log("Hit!");
            if (hit.collider.CompareTag("Enemy"))
            {
                Debug.Log("Enemy!");
                if (hit.collider.TryGetComponent(out EnemyController enemy))
                {
                    Debug.Log("Component!");
                    enemy.GetStunned();
                }
            }
        }
    }
}
