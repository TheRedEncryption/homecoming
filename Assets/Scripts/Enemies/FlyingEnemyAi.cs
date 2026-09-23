
using UnityEngine;

public class FlyingEnemyAI : MonoBehaviour
{
    public EnemyDetect detect;
    public Transform player;
    public float chaseSpeed = 3f;

    public FlyingEnemyPatrol patrol;  // so AI can pause patrol while chasing

    void Update()
    {
        if (detect.playerDetected)
        {
            // Move toward the player smoothly
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.position,
                chaseSpeed * Time.deltaTime
            );

            // Flip toward player
            Vector3 scale = transform.localScale;
            scale.x = (player.position.x > transform.position.x) ? 1 : -1;
            transform.localScale = scale;
        }
    }
}
