using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineObjects : MonoBehaviour
{
    public string type;
    public Rigidbody2D rb;
    public Renderer r;
    public bool gold;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        r = GetComponent<Renderer>();
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
