using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticFIeld : MonoBehaviour
{
    public float magnetStrenght;
    public List<MachineObjects> objectsInRange = new List<MachineObjects>();
    public bool attractObjects;

    private int dropObjectsLayer;

    public float dropZOffset = 1;
    public bool dropHeightReached = false;

    private void Start()
    {dropObjectsLayer = LayerMask.NameToLayer("Packing/Object");

    }

    private void Update()
    {
        if (!attractObjects)
            return;

        foreach (MachineObjects rb in objectsInRange)
        {
            Vector2 direction = (transform.position - rb.transform.position);
            float distance = Mathf.Clamp(Mathf.Abs(Vector2.Distance(rb.transform.position, transform.position) - 3),0.5f,3);
            rb.AddForce(direction.normalized * distance * magnetStrenght * Time.deltaTime, ForceMode2D.Force);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Magnetic")
            return;


        MachineObjects thisObject = collision.GetComponent<MachineObjects>();
        objectsInRange.Add(thisObject);
        thisObject.OnPickup();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != "Magnetic")
            return;

        MachineObjects thisObject = collision.GetComponent<MachineObjects>();
        objectsInRange.Remove(thisObject);
        thisObject.OnLetGo();

        OnRelease(collision.gameObject);
        
        
    }



    public void EnableMagnet(bool enable)
    {
        attractObjects = enable;

        if (enable)
            return;

        for (int i = objectsInRange.Count-1; i >= 0; i--)
        {
            OnRelease(objectsInRange[i].gameObject);
            //objectsInRange[i].gameObject.SetActive(false);
        }
    }

    public void OnRelease(GameObject gameObject)
    {
        if (transform.position.y > 6.5f)
        {
            gameObject.gameObject.layer = dropObjectsLayer;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y,-dropZOffset);
        }
    }

    public void UpdateDropHeight(bool reached)
    {
        dropHeightReached = reached;
    }
}
