using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public Transform attackPoint;
    public GameObject arrow;
    
    public float attackRange = 0.5f;
    public LayerMask playerLayer;
    public int meleeDamage = 20;
    // Update is called once per frame
    


    public void Attack()
    {
        Collider2D hitPlayer = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayer);

        if (hitPlayer)
        {
            Player player = hitPlayer.GetComponent<Player>();
            if (player != null)
                player.TakeDamage(meleeDamage);

            Debug.Log("Hit Player");
        }

    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    }


    public void ShootArrow()
    {
        Debug.Log("Tryíng to shoot the player!");
        Instantiate(arrow, transform.position, transform.rotation);
    }
}
