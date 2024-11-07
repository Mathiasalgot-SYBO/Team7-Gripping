using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorLight : MonoBehaviour
{
    public Material offMat, onMat, dropMat;
    private Renderer render;

    private bool dropHeightReached;
    private bool lightEnabled;

    private void Awake()
    {
        render = GetComponent<Renderer>();
    }


    public void EnableIndicator(bool enable)
    {
        if (enable)
        {
            if (dropHeightReached)
            {
                render.material = dropMat;
                
            }
            else
            {
                render.material = onMat;
            }

            lightEnabled = true;
            return;
        }

        render.material = offMat;
        lightEnabled = false;
    }

    public void UpdateDropHeight(bool reached)
    {
        dropHeightReached = reached;

        if (reached && lightEnabled)
        {
            render.material = dropMat;
            return;
        }

        if (!reached)
        {
            if (lightEnabled)
            {
                render.material = onMat;
            }
            else
            {
                render.material = offMat;
            }
        }
    }
}
