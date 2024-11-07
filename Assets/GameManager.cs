using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timer;
    public TMP_Text timerField, pointsField;
    public int currentPoints;

    private void Update()
    {
        timer -= Time.deltaTime;
        var ts = TimeSpan.FromSeconds(timer);
        timerField.text = string.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);
    }

    public void ScorePoints(int points)
    {
        currentPoints += points;
        pointsField.text = currentPoints.ToString();

    }
}
