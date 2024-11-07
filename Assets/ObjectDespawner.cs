using MA.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDespawner : MonoBehaviour
{

    public VoidEvent despawnEvent;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Magnetic")
        {
            despawnEvent.Raise();
            Destroy(other.gameObject);
        }
    }
}
