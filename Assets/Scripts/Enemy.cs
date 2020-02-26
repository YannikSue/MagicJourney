using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;
    public EnemyBehavior behavior;
    public float moveSpeed = 3f;
    public GameObject target;


    private bool facingRight = true;
    private float timePassed;
    private int direction = 1;


    public enum EnemyBehavior
    {
        idle,
        patrolling,
        attacking
    }

    void Awake()
    {
        behavior = EnemyBehavior.idle;
    }

    void Update()
    {
        timePassed += Time.deltaTime;
        

        CheckForPlayer();

        if (timePassed >= Time.deltaTime * 10)
        {
            Behavior();
            timePassed = 0;
        }
    }

    public void TageDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Behavior()
    {

        switch (behavior)
        {
            case EnemyBehavior.idle: Move(); break;
            case EnemyBehavior.patrolling: break;
            case EnemyBehavior.attacking: break;

            default: break;
        }

    }


    public void Move()
    {

        transform.Translate(Vector2.right * Time.deltaTime);

    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    public void Die()
    {
        Destroy(gameObject);
    }

    public void CheckForPlayer()
    {
        Vector3 offset = new Vector3(0.5f, 0, 0);
        RaycastHit2D playerInSight = Physics2D.Raycast(transform.position + offset, Vector2.right, 0.5f);

        //Debug.DrawRay(transform.position + offset, Vector2.right, Color.green);

        if (playerInSight.collider != null && playerInSight.collider.CompareTag("Player"))
        {

            Debug.Log("FOUND PLAYER! ATTACK!");
            behavior = EnemyBehavior.attacking;


        }
    }
}
