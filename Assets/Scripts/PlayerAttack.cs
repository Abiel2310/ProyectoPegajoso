using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 1f;     // rango del golpe
    public float attackRate = 1f;      // golpes por segundo
    private float nextAttackTime = 0f;

    public Transform attackPoint;      // un empty GameObject donde sale el ataque
    public LayerMask enemyLayers;      // qué capas son atacables

    private CharacterStats stats;

    void Start()
    {
        stats = GetComponent<CharacterStats>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0)) // click izquierdo para atacar
        {
            if (Time.time >= nextAttackTime)
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

        RotateAttackPointTowardsMouse();
    }

    void Attack()
    {
        // Detectar enemigos en el área de ataque
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            CharacterStats enemyStats = enemy.GetComponent<CharacterStats>();
            if (enemyStats != null)
            {
                enemyStats.TakeDamage(stats.attackDamage);
            }
        }
    }

    void RotateAttackPointTowardsMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - transform.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        attackPoint.rotation = Quaternion.Euler(0, 0, angle);
    }

    // Para ver el área de ataque en el editor
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
