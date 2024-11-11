using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    //public Rigidbody2D prefab;
    public Material goldMat;

    [ContextMenu("TestSpawn")]
    public void SpawnObject(MachineObjects prefab, bool gold)
    {
        float force = Random.Range(2f, 4f);
        MachineObjects temp = Instantiate(prefab,transform.position, Quaternion.identity);
        temp.AddForce(-transform.right * force, ForceMode2D.Impulse);

        if (!gold)
            return;

        temp.r.material = goldMat;
        temp.gold = true;
        temp.transform.localScale = new Vector3(1.7f, 1.7f, 1.7f);
    }
}
