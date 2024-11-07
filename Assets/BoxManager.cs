using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BoxManager : MonoBehaviour
{
    public Transform boxPrefab;

    public List<Box> boxes = new List<Box>();
    public AnimationCurve speedCurve;

    public Vector2 boxToFrom;
    public Vector2 boxYZLevel;
    public float timeScale = 0.1f;

    public BonusType[] bonusTypes;

    private void Start()
    {
        SpawnBox();
    }

    private void Update()
    {
        timeScale += Time.deltaTime * 0.0004f;

        for (int i = 0; i < boxes.Count; i++)
        {
            boxes[i].time += Time.deltaTime * timeScale;
            boxes[i].t.position = new Vector3(Mathf.Lerp(boxToFrom.x, boxToFrom.y, speedCurve.Evaluate(boxes[i].time)), boxYZLevel.x, boxYZLevel.y);

            if (boxes[i].time > 0.7f && !boxes[i].spawnNewBox)
            {
                SpawnBox();
                boxes[i].spawnNewBox = true;
            }

            if (boxes[i].time >= 1f)
            {
                Destroy(boxes[i].t.gameObject);
                boxes.RemoveAt(i);
            }
        }
    }

    public void SpawnBox()
    {
        Transform tempTransform = Instantiate(boxPrefab, new Vector3(boxToFrom.x, boxYZLevel.x, boxYZLevel.y), Quaternion.identity);
        BonusType bonusType = bonusTypes[Random.Range(0, bonusTypes.Length)];
        tempTransform.GetComponentInChildren<BoxScript>().InitBox(bonusType.typeName, bonusType.typeSprite);
        boxes.Add(new Box(tempTransform));

    }

}


public class Box
{
    public Transform t;
    public float time;
    public bool spawnNewBox = false;

    public Box(Transform transform)
    {
        this.t = transform;
        this.time = 0;
        this.spawnNewBox = false;
    }
}
[System.Serializable]
public class BonusType
{
    public string typeName;
    public Sprite typeSprite;
}
