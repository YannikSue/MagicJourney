using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform player;
    public float smoothSpeed = 0.25f;
    public Vector3 offset;


    void LateUpdate()
    {
        transform.position = player.position + offset;
    }
}
