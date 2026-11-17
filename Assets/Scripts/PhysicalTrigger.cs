using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class PhysicalTrigger : MonoBehaviour
{
    [SerializeField] private string requiredTag = "Player";
    [SerializeField] private bool triggerOnce = false;
    public UnityEvent onTrigger;
    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggerOnce && hasTriggered) return;

        if (other.CompareTag(requiredTag))
        {
            hasTriggered = true;
            onTrigger?.Invoke();

            if (triggerOnce)
            {
                GetComponent<Collider>().enabled = false;
            }
        }
    }
}