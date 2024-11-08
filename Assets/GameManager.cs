using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timer;
    public TMP_Text timerField, pointsField, finalScoreField;
    public int currentPoints;
    public GameObject finalCanvas;
    public InputManager inputManager;

    private bool gameStopped;

    private void Awake()
    {
        Application.targetFrameRate = 100;
    }

    private void Update()
    {
        if (gameStopped)
            return;

        timer -= Time.deltaTime;
        var ts = TimeSpan.FromSeconds(timer);
        timerField.text = string.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);

        if(timer <= 0)
        {
            finalScoreField.text = currentPoints.ToString();
            gameStopped = true;
            timer = 0;
            timerField.text = "00:00";
            finalCanvas.SetActive(true);
            inputManager.EndGame();
        }
    }

    public void ScorePoints(int points)
    {
        if (gameStopped)
            return;

        currentPoints += points;
        pointsField.text = currentPoints.ToString();

    }
}
