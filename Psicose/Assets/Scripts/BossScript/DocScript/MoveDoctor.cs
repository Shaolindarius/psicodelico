using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDoctor : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private float visionRadius;
    [SerializeField] private LayerMask visionLayerMask;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] public float minAttackRange;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color areaColor;
    [SerializeField] private Color lineColor;
    [SerializeField] private float punchRadius;
    [SerializeField] private Transform arms;
    [SerializeField] public int punchDamage;


    public PlayerManager plManager;
    public Animator anim;

    private bool isAttacking = false;
    private float attackTimer = 0.0f;
    private float attackCooldownTimer = 0.0f;
    public float attackDuration = 2.0f;
    public float attackCooldown = 5.0f;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        CheckForTarget();
        if (target != null)
        {
            MoveToTarget();

            float distanceToTarget = Vector2.Distance(transform.position, target.position);
            if (distanceToTarget <= minAttackRange && !isAttacking && attackCooldownTimer <= 0)
            {
                PerformAttack();
            }
        }
        else
        {
            StopMoving();
        }

        // Decrement timers
        if (attackCooldownTimer > 0)
        {
            attackCooldownTimer -= Time.deltaTime;
            if (attackCooldownTimer < 0)
            {
                attackCooldownTimer = 0;
            }
        }

        if (isAttacking)
        {
            attackTimer += Time.deltaTime;

            if (attackTimer >= attackDuration)
            {
                FinishAttack();
            }
        }
    }

    private void CheckForTarget()
    {
        Collider2D col = Physics2D.OverlapCircle(transform.position, visionRadius, visionLayerMask);
        if (col != null)
        {
            if (col.CompareTag("Player"))
            {
                target = col.transform;
            }
            else
            {
                target = null;
            }
        }
        else
        {
            target = null;
        }
    }

    private void MoveToTarget()
    {
        float distToTarget = Vector2.Distance(transform.position, target.position);
        if (distToTarget >= minAttackRange)
        {
            Vector2 dir = target.position - transform.position;
            dir = dir.normalized;
            rb.velocity = (moveSpeed * dir);

            if (rb.velocity.x > 0)
            {
                spriteRenderer.flipX = true;
            }
        }
        else
        {
            StopMoving();
        }
    }

    private void StopMoving()
    {
        rb.velocity = Vector2.zero;
    }

    private void PerformAttack()
    {
        Collider2D collision = Physics2D.OverlapCircle(arms.position, punchRadius, visionLayerMask);
        if (collision != null)
        {
            Invoke("DealDamage", 2f);
        }

        isAttacking = true;
        attackTimer = 0.0f;
        attackCooldownTimer = attackCooldown;
    }

    private void FinishAttack()
    {
        plManager.TakeDamage(punchDamage);
        isAttacking = false;
    }

    private void DealDamage()
    {
        plManager.TakeDamage(punchDamage);
        isAttacking = false;
    }

    private void OnDrawGizmos()
    {
        // Draw gizmos for visualization
        Gizmos.color = areaColor;
        Gizmos.DrawWireSphere(transform.position, visionRadius);

        if (target != null)
        {
            Gizmos.color = lineColor;
            Gizmos.DrawLine(transform.position, target.position);
        }

        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(arms.position, punchRadius);
    }
}
