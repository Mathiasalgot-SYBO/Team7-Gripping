using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawController : MonoBehaviour
{
    public Transform clawDesiredPoint;
    public float moveSpeed = 2;
    public void MoveMagnet(Vector2 movement)
    {
        clawDesiredPoint.position += ((Vector3)movement/1024f) * moveSpeed;
    }

    public void EnableMagnet(bool enable)
    {

    }
}
