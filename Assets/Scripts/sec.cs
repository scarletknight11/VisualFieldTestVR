using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sec : MonoBehaviour {

    public float currentTime = 0f;
    float startimgTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startimgTime;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Count());
    }

    IEnumerator Count()
    {
        currentTime -= 0.1f * Time.deltaTime;
        yield return new WaitForSeconds(1);
        if (currentTime <= 0)
        {
            currentTime = 0;
        }
    }
}
