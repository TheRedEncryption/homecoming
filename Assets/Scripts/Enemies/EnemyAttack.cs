using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]public int damage = 1;
    [SerializeField]public float attackCooldown = 1f;

    [Header("Attack Detection")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private LayerMask playerLayer;

    private float lastAttackTime = 0f;

    void Update()
    {
        if (attackPoint == null)
            return;

        Collider2D player = Physics2D.OverlapCircle(attackPoint.position,attackRange,playerLayer);

        if (player != null && Time.time >= lastAttackTime + attackCooldown)
        {
            lastAttackTime = Time.time;

            PlayerHealth health = player.GetComponentInParent<PlayerHealth>();

            if (health != null )
            {
                health.TakeDamage(damage, transform.position);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

