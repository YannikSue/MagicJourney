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
    private void Awake()
    {
        
    }
    void Start()
    {
        Camera camera = Camera.main;
        float halfHeigth = camera.orthographicSize;
        halfWidth = camera.aspect * halfHeigth;
        transform.position = player.position + offset;
        Debug.Log("CameraPos: " + transform.position.ToString());
        Debug.Log("PlayerPos: " + player.position);

    }

    void LateUpdate()
    {
        smoothCamera();
    }

    void smoothCamera()
    {
        Vector3 tmpVec = player.position + offset;
        if ((player.position.x >= edgeOfWorld.position.x + halfWidth) && (player.position.x <= edgeOfWorld2.position.x - halfWidth))
        {
            transform.position = Vector3.Lerp(transform.position, player.position + offset, smoothingSpeed);
            Debug.Log("Camera lerps");

        }
    }
}
