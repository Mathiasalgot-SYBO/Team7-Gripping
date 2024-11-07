using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawController : MonoBehaviour
{
    public Transform clawDesiredPoint;
    public float moveSpeed = 2;
    public Vector2 xLimits,yLimits;
    public void MoveMagnet(Vector2 movement)
    {
        clawDesiredPoint.position += ((Vector3)movement/1024f) * moveSpeed;
        clawDesiredPoint.position = new Vector3(Mathf.Clamp(clawDesiredPoint.position.x, xLimits.x, xLimits.y),
            Mathf.Clamp(clawDesiredPoint.position.y, yLimits.x, yLimits.y), 0);
    }

    public void EnableMagnet(bool enable)
    {

    }
}
