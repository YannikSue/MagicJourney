using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayer;
    public int meleeDamage = 20;
    // Update is called once per frame
    


    public void Attack()
    {
        Collider2D hitPlayer = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayer);

        if (hitPlayer)
        {
            hitPlayer.GetComponent<Player>().TakeDamage(meleeDamage);
            Debug.Log("Hit Player");
        }

    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    }
}
