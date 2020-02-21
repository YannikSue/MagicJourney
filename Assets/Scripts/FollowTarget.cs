using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform edgeOfWorld;
    public Transform edgeOfWorld2;

    public Transform player;
    public float smoothSpeed = 0.25f;
    public Vector3 offset;
    private float horizontalMin;

    void Start()
    {
        Camera camera = Camera.main;
        float halfHeigth = camera.orthographicSize;
        float halfWidth = camera.aspect * halfHeigth;

        horizontalMin = halfWidth;
    }

    void LateUpdate()
    {
        if (transform.position.x - horizontalMin <= edgeOfWorld.position.x)
        {
            transform.position = transform.position;
        }
        else if(transform.position.x + horizontalMin >= edgeOfWorld2.position.x)
        {
            transform.position = transform.position;
        }
        else if(player.position.x >= edgeOfWorld.position.x + horizontalMin)
        {

            transform.position = player.position + offset;
        }
    }
}
