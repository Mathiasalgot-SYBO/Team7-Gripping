using MA.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxScript : MonoBehaviour
{
    public string bonusType;
    public Image typeImage;

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
                scoreEvent.Raise(500);
                Destroy(Instantiate(starsParticles, collision.transform.position, Quaternion.identity), 2);
            }
            else
            {
                scoreEvent.Raise(100);
            }


           
            Destroy(collision.gameObject);
            objectCountEvent.Raise();
        }
    }
}
