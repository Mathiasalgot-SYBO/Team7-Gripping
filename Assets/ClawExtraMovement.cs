using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawExtraMovement : MonoBehaviour
{
    public Transform parent;

    public float angleLimits;
    public float moveSpeed = 1;


    public void Update()
    {
        if(Vector2.Distance(transform.position, parent.position) > 2)
        {
            transform.position = Vector3.Lerp(transform.position ,parent.position + (transform.position - parent.position).normalized * 2, Time.deltaTime * 8);
        }


    }

    public void AddDownwardForce(Vector2 movement)
    {
        movement.x = 0;
        movement.y = Mathf.Clamp(movement.y, -1000, 0);
        transform.position += ((Vector3)movement / 1024f) * moveSpeed;
    }
}
