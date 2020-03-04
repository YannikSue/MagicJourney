using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject deathEffect;
    public GameObject target;
    public Animator animator;
    public Transform attackPoint;
    public bool isRanged = false;
    public float moveSpeed = 1f;
    public float patrolRange = 1f;
    public float aggressionLevel = 1f;
    public float nearDistance = 0.9f;
    public float stoppingDistance = 1f;
    public float attackSpeedValue = 2f;
    public int health = 100;
    public EnemyAttack attackScript;

    private bool facingRight = true;
    private bool startTimer = false;
    private bool attackTimer = false;
    private EnemyBehavior behavior;
    private float timer = 4f;
    private float attackSpeed = 10f;
    private Vector3 spot1;
    private Vector3 spot2;
    private Vector3 spawnPoint;

    private enum EnemyBehavior
    {
        idle,
        attack
    }

    void Start()
    {
        behavior = EnemyBehavior.idle;
        spawnPoint = transform.position;
        attackSpeed = attackSpeedValue;
        spot1 = new Vector3(transform.position.x + patrolRange, transform.position.y);
        spot2 = new Vector3(transform.position.x - patrolRange, transform.position.y);
    }
    void Update()
    {

        if (startTimer)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                behavior = EnemyBehavior.idle;
                timer = 4f;
                startTimer = false;
                if (transform.position.x < spawnPoint.x && !facingRight)
                    Flip();
                else if (transform.position.x > spawnPoint.x && facingRight)
                    Flip();

                //Debug.Log("Must have been the wind!");
            }
        }

        if (attackTimer)
        {
            attackSpeed -= Time.deltaTime;

            if(attackSpeed <= 0)
            {
                attackTimer = false;
                attackSpeed = attackSpeedValue;
            }
        }

        CheckForPlayer();
        Behavior();
    }

    public void TageDamage(int damage)
    {
        health -= damage;
        behavior = EnemyBehavior.attack;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Behavior()
    {
        switch (behavior)
        {
            case EnemyBehavior.idle: Move(); animator.SetFloat("Speed", moveSpeed); break;
            case EnemyBehavior.attack: Attack(); animator.SetFloat("Speed", moveSpeed); break;
            default: break;
        }

    }


    public void Move()
    {

        if (facingRight)
        {
            transform.position = Vector2.MoveTowards(transform.position, spot1, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, spot1) < 0.01f)
                Flip();
        }
        if (!facingRight)
        {
            transform.position = Vector2.MoveTowards(transform.position, spot2, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, spot2) < 0.01f)
                Flip();
        }


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

    void CheckForPlayer()
    {

        //Sichtfeld muss angepasst werden

        Vector3 offset;
        Vector2 rayDirection;

        if (facingRight)
        {
            offset = new Vector3(0.25f, 0, 0);
            rayDirection = Vector2.right;
        }
        else
        {
            offset = new Vector3(-0.25f, 0, 0);
            rayDirection = Vector2.left;
        }

        RaycastHit2D detectionRay = Physics2D.Raycast(transform.position + offset, rayDirection, 0.5f * aggressionLevel);


        if (detectionRay.collider != null && detectionRay.collider.CompareTag("Player"))
        {
           
            behavior = EnemyBehavior.attack;
        }
        else if (behavior == EnemyBehavior.attack)
        {
            startTimer = true;
        }
    }

    void Attack()
    {


        if (!isRanged)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);

            if (target.transform.position.x + 0.2f > transform.position.x && !facingRight)
                Flip();

            if (target.transform.position.x - 0.2f < transform.position.x && facingRight)
                Flip();

        }
        else
        {
            //shoot

            if (Vector2.Distance(transform.position, target.transform.position) < nearDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, -moveSpeed * Time.deltaTime);

            }
            else if (Vector2.Distance(transform.position, target.transform.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, target.transform.position) < stoppingDistance && Vector2.Distance(transform.position, target.transform.position) > nearDistance)
            {
                transform.position = transform.position;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        //needs counter to prevent killing the player in one second
        if (collision.CompareTag("Player") && !attackTimer)
        {
            Debug.Log("Hitting Player");
            attackScript.Attack();
            attackTimer = true;
        }
    }
}
