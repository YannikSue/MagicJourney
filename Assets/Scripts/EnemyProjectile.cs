using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    public float speed = 5f;
    private Rigidbody2D rb;
    private GameObject player;


    void Start()
    {
        player = GameObject.FindWithTag("Player");

        //formel für Flugbahn
        //Grad = arctan(y/x + Mathf.sqr("y²/(x²+1))
        float x = player.transform.position.x;
        float y = player.transform.position.y;
        float erg = x / y + Mathf.Sqrt(Mathf.Pow(y, 2) / (Mathf.Pow(x, 2) + 1));
        float launchAngle = Mathf.Atan(erg) * Mathf.Rad2Deg + 90;
        //"Launchspeed fehlt"
        //Vectorberechnung fehlt Vector2 arrowDirection = new Vector2(Mathf.cos(launchAngle), Mathf.sin(launchAngle));

        float launchSpeed = Mathf.Sqrt(Mathf.Pow(x,2) + Mathf.Pow(y,2));
        float Theta = Mathf.Atan(y / x) + 90;
        Vector2 launchVector = new Vector2(Mathf.Cos(Theta), Mathf.Sin(Theta));

        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(launchVector * speed, ForceMode2D.Impulse);
    }

    
}
