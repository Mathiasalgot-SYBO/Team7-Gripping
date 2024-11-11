using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{

    public TMP_Text scoreField;
    public Transform scaler;
    public void Init(int score)
    {
        scoreField.text = "+" + score.ToString();
        scaler.localScale = Vector3.one + new Vector3(score * 0.5f * 0.001f, score * 0.5f * 0.001f, score * 0.5f * 0.001f);
        scoreField.gameObject.SetActive(true);
        Destroy(this.gameObject, 2);

    }
}
