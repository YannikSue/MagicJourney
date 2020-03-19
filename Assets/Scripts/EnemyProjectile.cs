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
        rb = gameObject.GetComponent<Rigidbody2D>();

        //Distance between Player and Firepoint
        float x = Vector2.Distance(player.transform.position, transform.position);

        //height of firepoint
        float h = Mathf.Abs(transform.position.y);

        //angle required to find Theta
        float phi = Mathf.Atan2(x, h) * Mathf.Rad2Deg;

        //gravity
        float g = Mathf.Abs(Physics2D.gravity.y);

        //calculates the initial speed to hit at max range
        float initialSpeed = Mathf.Sqrt((g * Mathf.Pow(x, 2)) / x * Mathf.Sin(2 * 45));
        Debug.Log("InitialSpeed: " + initialSpeed);

        //intermediate result for arcos
        float intResult = ((g * Mathf.Pow(x, 2) / initialSpeed) - h) / Mathf.Sqrt(Mathf.Pow(h, 2) + Mathf.Pow(x, 2));

        //launchangle theta
        float theta = (Mathf.Acos(intResult) * Mathf.Rad2Deg + phi) / 2 + 90;

        //convert degree to radiant 
        theta *= Mathf.Deg2Rad;

        //launchvector 
        Vector2 launchVector = new Vector2(Mathf.Cos(theta), Mathf.Sin(theta));

        //actually launches that shit
        if (launchVector.x != float.NaN && launchVector.y != float.NaN)
            rb.AddForce(launchVector * initialSpeed, ForceMode2D.Impulse);


    }
}
