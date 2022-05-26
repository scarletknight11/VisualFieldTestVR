using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCircle : MonoBehaviour {

    public GameObject circlePrefab;

    public Vector3 center;
    public Vector3 size;


    // Update is called once per frame
    void Update()
    {
        //Raycast and Hit2D detecting
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 MousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(MousePos2D, Vector2.zero);
        
        if (hit.collider != null)
        {
            if(hit.collider.tag == "Enemy Circle")
            {
                if(Input.GetMouseButtonDown(0))
                {
                    SpawnNextCircle();
                }
            }
        }
    }

    private void SpawnNextCircle()
    {
        //Random Spawning in dedicated position
        Vector3 pos = center + new Vector3(UnityEngine.Random.Range(-size.x / 2, size.x / 2),
            UnityEngine.Random.Range(size.y / 2, size.y / 2),
            0);

        Instantiate(circlePrefab, pos, Quaternion.identity);

        Destroy(gameObject);
    }
}
