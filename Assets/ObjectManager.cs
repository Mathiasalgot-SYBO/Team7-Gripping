using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public int currentObjectCount = 0;

    public int DesiredObjectCount = 25;

    public ObjectSpawner[] spawners;
    public MachineObjects[] prefabs;


    private void Awake()
    {
        TestCoroutine();
    }

    [ContextMenu("SpawnToMax")]
    public void TestCoroutine()
    {
        StartCoroutine(SpawnToMax());
    }
    public IEnumerator SpawnToMax()
    {
        while(currentObjectCount < DesiredObjectCount)
        {
            int spawner = Random.Range(0, spawners.Length);
            int prefab = Random.Range(0, prefabs.Length);

            int r = Random.Range(0, 15);

            spawners[spawner].SpawnObject(prefabs[prefab], r == 0);
            currentObjectCount++;

            yield return new WaitForSeconds(0.3f);
        }

        StopAllCoroutines();
    }

    public void DecreaseObjectCount()
    {
        currentObjectCount--;
    }

}
