using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorLight : MonoBehaviour
{
    public Material offMat, onMat;
    private Renderer render;

    private void Awake()
    {
        render = GetComponent<Renderer>();
    }


    public void EnableIndicator(bool enable)
    {
        if (enable)
        {
            render.material = onMat;
            return;
        }

        render.material = offMat;
    }
}
