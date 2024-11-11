using MA.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoxScript : MonoBehaviour
{
    public string bonusType;
    public Image typeImage;

    public int baseScore = 0;
    public int bonusScore = 100;
    public float bonusScoreMul = 2;
    private int bonusCounter;

    public TMP_Text bonusCounterField;
    public IntEvent scoreEvent;

    public VoidEvent objectCountEvent;

    public GameObject starsParticles;
    public ScoreDisplay scoreDisplay;

    public void InitBox(string bonus, Sprite sprite)
    {
        bonusType = bonus;
        typeImage.sprite = sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Magnetic")
        {
            if(collision.GetComponent<MachineObjects>().type == bonusType)
            {
                bonusCounter++;
                bonusCounterField.text = bonusCounter.ToString();
                int score = Mathf.RoundToInt(bonusScore * bonusCounter);
                if (collision.GetComponent<MachineObjects>().gold)
                {
                    bonusCounter++;
                    score *= 2;
                }
                scoreEvent.Raise(score);
                Destroy(Instantiate(starsParticles, collision.transform.position, Quaternion.identity), 2);
                Instantiate(scoreDisplay, collision.transform.position, Quaternion.identity).Init(score);
            }
            else
            {
                scoreEvent.Raise(baseScore);
            }


           
            Destroy(collision.gameObject);
            objectCountEvent.Raise();
        }
    }
}
