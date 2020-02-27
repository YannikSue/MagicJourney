using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFollowTarget : MonoBehaviour
{

    public Transform target;
    public Transform startPoint;
    public Transform endPoint;

    Vector3 velocity = Vector3.zero;

    public float smoothTime = .05f;


    public bool YMaxEnabled = false;
    public float YMaxValue = 0;

    public bool YMinEnabled = false;
    public float YMinValue = 0;

    public bool XMaxEnabled = false;
    public float XMaxValue = 0;

    public bool XMinEnabled = false;
    public float XMinValue = 0;

    private void Awake()
    {
        Camera camera = Camera.main;
        float halfHeigth = camera.orthographicSize;
        float halfWidth = camera.aspect * halfHeigth;
        XMaxValue = endPoint.position.x - halfWidth;
        XMinValue = startPoint.position.x + halfWidth;
        Debug.Log("XMin: " + XMinValue + ", XMAX: " + XMaxValue);
    }

    void Update()
    {
        Vector3 targetPos = target.position;



        if (YMinEnabled && YMaxEnabled)
            targetPos.y = Mathf.Clamp(target.position.y, YMinValue, YMaxValue);
        else if (YMinEnabled)
            targetPos.y = Mathf.Clamp(target.position.y, YMinValue, target.position.y);
        else if(YMaxEnabled)
            targetPos.y = Mathf.Clamp(target.position.y, target.position.y, YMaxValue);




        if (XMinEnabled && XMaxEnabled)
            targetPos.x = Mathf.Clamp(target.position.x, XMinValue, XMaxValue);
        //else if (XMinEnabled)
        //    targetPos.x = Mathf.Clamp(target.position.x, XMinValue, target.position.x);
        //else if (XMaxEnabled)
        //    targetPos.x = Mathf.Clamp(target.position.x, target.position.x, YMaxValue);

        targetPos.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }
}
