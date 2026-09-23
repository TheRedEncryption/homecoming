using Unity.VisualScripting;
using UnityEngine;

public class GroundEnemyMovement : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 2f;

    [SerializeField] public Transform leftPoint;
    [SerializeField]    public Transform rightPoint;

    [SerializeField] public Transform player;

    [SerializeField] public EnemyDetect detect;

    private bool movingRight = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (detect != null && detect.playerDetected)
        {
            //Chase The Player
            ChasePlayer();

        }
        else
        {
            Patrol();
        }
    }

    private void ChasePlayer()
    {
        Vector2 targetPosition = new Vector2(player.position.x, transform.position.y);

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed *Time.deltaTime);
    }

    void Patrol()
    {
        Transform targetPoint = movingRight ? leftPoint : rightPoint;

        Vector2 targetPosition = new Vector2(targetPoint.position.x,transform.position.y);

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Mathf.Abs(transform.position.x - targetPoint.position.x) < 0.1f)
        {
            movingRight = !movingRight;
        }
    }  
}
