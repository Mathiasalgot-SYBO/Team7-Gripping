using MA.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawController : MonoBehaviour
{
    public Transform clawDesiredPoint;
    public float moveSpeed = 2;
    public float downwardSpeedMultiplier;
    public Vector2 xLimits,yLimits;
    public float safeDropHeight;
    private bool dropHeightReached;

    public BoolEvent dropHeightEvent;
    public void MoveMagnet(Vector2 movement)
    {
        Vector3 frameMovement = ((Vector3)movement / 1024f) * moveSpeed;
        float downwardDot = Mathf.Clamp01(Vector2.Dot(movement, Vector2.down))*downwardSpeedMultiplier + 1;

        clawDesiredPoint.position += frameMovement * downwardDot ;
        clawDesiredPoint.position = new Vector3(Mathf.Clamp(clawDesiredPoint.position.x, xLimits.x, xLimits.y),
            Mathf.Clamp(clawDesiredPoint.position.y, yLimits.x, yLimits.y), 0);

        if (dropHeightReached)
        {
            if(clawDesiredPoint.position.y < safeDropHeight)
            {
                //No Longer at safe drop height
                dropHeightReached = false;
                dropHeightEvent.Raise(false);
            }
        }
        else
        {
            if(clawDesiredPoint.position.y > safeDropHeight)
            {
                //Drop Height reached
                dropHeightReached = true;
                dropHeightEvent.Raise(true);

            }
        }
    }

    public void EnableMagnet(bool enable)
    {

    }
}
