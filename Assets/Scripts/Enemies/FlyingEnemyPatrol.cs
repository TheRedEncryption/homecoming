using UnityEngine;

public class FlyingEnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float speed = 2f;

    private int currentPointIndex = 0;

    void Update()
    {
        if (patrolPoints.Length == 0) return;

        Transform target = patrolPoints[currentPointIndex];
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // If reached point
        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
        }

        // Flip toward movement direction (optional)
        Vector3 scale = transform.localScale;
        scale.x = (target.position.x > transform.position.x) ? 1 : -1;
        transform.localScale = scale;
    }
}

