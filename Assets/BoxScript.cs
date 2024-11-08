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
                bonusCounterField.text = "x" + bonusCounter.ToString();
                scoreEvent.Raise(Mathf.RoundToInt(bonusScore * Mathf.Pow(bonusCounter,2)));
                Destroy(Instantiate(starsParticles, collision.transform.position, Quaternion.identity), 2);
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
