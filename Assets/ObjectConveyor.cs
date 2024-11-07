using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectConveyor : MonoBehaviour
{
    public float speed;
    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.GetComponent<Rigidbody2D>().MovePosition((Vector2)collision.transform.position + Vector2.right * speed * Time.deltaTime);
    }
}
