using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coordinates : MonoBehaviour {

    public Text X;
    public Text Y;
    public GameObject sphere;
    Vector3 pos;

    // Start is called before the first frame update
    void Awake()
    {
        X = GetComponent<Text>();
        pos = sphere.transform.position;
        sphere.transform.position = new Vector3(pos.x, pos.y, pos.z);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(sphere.transform.position);
    }
}
