using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform edgeOfWorld;
    public Transform edgeOfWorld2;
    public Transform player;
    public float smoothingSpeed;
    public Vector3 offset;

    private float halfWidth;

    void Start()
    {
        Camera camera = Camera.main;
        float halfHeigth = camera.orthographicSize;
        halfWidth = camera.aspect * halfHeigth;


    }

    void LateUpdate()
    {
        Vector3 tmpVec = player.position + offset;
        if ((player.position.x >= edgeOfWorld.position.x + halfWidth) && (player.position.x <= edgeOfWorld2.position.x - halfWidth))
        {

            //while (transform.position != tmpVec)
            //{
            //    transform.position = Vector3.Lerp(tmpVec, transform.position, 0, 0001);
            //}

            transform.position = Vector3.Lerp(transform.position, player.position + offset, smoothingSpeed);
            //Vector3.Lerp(transform.position, player.position + offset, smoothingSpeed);
        }

    }
}
