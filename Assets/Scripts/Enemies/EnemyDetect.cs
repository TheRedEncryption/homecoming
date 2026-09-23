using UnityEngine;

public class EnemyDetect : MonoBehaviour
{
    public bool playerDetected;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            playerDetected = true;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            playerDetected = false;
    }
}
