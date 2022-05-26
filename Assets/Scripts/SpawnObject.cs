using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    private float MinX, MaxX, MinY, MaxY;
    private Vector2 pos;
    public GameObject[] myGameObectToRespawn;

    // Start is called before the first frame update
    public void Start()
    {
        SetMinAndMax();
        SpawnObj();
    }

    private void SetMinAndMax()
    {
        Vector2 Bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));

        MinX = -Bounds.x;
        MaxX = Bounds.x;
        MinY = -Bounds.y;
        MaxY = Bounds.y;
    }

    private void SpawnObj()
    {
        int NumberOfObj = UnityEngine.Random.Range(0, myGameObectToRespawn.Length);
        pos = new Vector2(UnityEngine.Random.Range(MinX, MaxX), UnityEngine.Random.Range(MinY, MaxY));
        GameObject obj = Instantiate(myGameObectToRespawn[NumberOfObj], pos, Quaternion.identity);
        obj.transform.parent = transform;
    }

}
