using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToCursor : MonoBehaviour
{
    private Vector3 mousePosition;
    private Vector3 object_pos;
    public float speed = 5f;
    private float angle;

    void Update()
    {
        //mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ////mousePosition.z = .z; //The distance between the camera and object
        //object_pos = transform.position;
        //mousePosition.x = mousePosition.x - object_pos.x;
        //mousePosition.y = mousePosition.y - object_pos.y;
        //angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed);

    }



}
