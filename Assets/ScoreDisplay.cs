using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{

    public TMP_Text scoreField;
    public void Init(string score)
    {
        scoreField.text = score;
        scoreField.gameObject.SetActive(true);
        Destroy(this.gameObject, 2);
    }
}
