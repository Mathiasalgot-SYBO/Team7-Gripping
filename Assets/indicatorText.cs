using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class indicatorText : MonoBehaviour
{
    public TMP_Text indicatorTextField;

    public string offText, onText, dropText;
    public Color offColor, onColor, dropColor;

    private bool dropHeightReached;
    private bool lightEnabled;

    private void Awake()
    {
   
    }


    public void EnableIndicator(bool enable)
    {
        if (enable)
        {
            if (dropHeightReached)
            {
                indicatorTextField.text = dropText;
                indicatorTextField.color = dropColor;

            }
            else
            {

                indicatorTextField.text = onText;
                indicatorTextField.color = onColor;
            }

            lightEnabled = true;
            return;
        }

        indicatorTextField.text = offText;
        indicatorTextField.color = offColor;
        lightEnabled = false;
    }

    public void UpdateDropHeight(bool reached)
    {
        dropHeightReached = reached;

        if (reached && lightEnabled)
        {
            indicatorTextField.text = dropText;
            indicatorTextField.color = dropColor;
            return;
        }

        if (!reached)
        {
            if (lightEnabled)
            {
                indicatorTextField.text = onText;
                indicatorTextField.color = onColor;
            }
            else
            {
                indicatorTextField.text = offText;
                indicatorTextField.color = offColor;
            }
        }
    }
}
