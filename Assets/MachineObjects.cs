using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineObjects : MonoBehaviour
{
    public Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void AddForce(Vector2 force, ForceMode2D forceMode)
    {
        rb.AddForce(force, forceMode);
    }

    public void OnPickup()
    {

    }

    public void OnLetGo()
    {

    }
}
