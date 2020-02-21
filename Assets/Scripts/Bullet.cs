using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15f;
    private Rigidbody2D bulletBody;
    public int damage = 20;

    // Start is called before the first frame update
    void Start()
    {
        bulletBody = gameObject.GetComponent<Rigidbody2D>();
        bulletBody.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();

        if (enemy != null)
        {

            enemy.TageDamage(damage);
        }

        Destroy(gameObject);
    }

}
