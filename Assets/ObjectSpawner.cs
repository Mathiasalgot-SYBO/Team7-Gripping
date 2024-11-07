using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    //public Rigidbody2D prefab;

    [ContextMenu("TestSpawn")]
    public void SpawnObject(Rigidbody2D prefab)
    {
        float force = Random.Range(2f, 4f);
        Instantiate(prefab,transform.position, Quaternion.identity).AddForce(-transform.right* force,ForceMode2D.Impulse);
    }
}
