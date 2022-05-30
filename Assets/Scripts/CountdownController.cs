using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownController : MonoBehaviour {

    public float currentTime = 0f;
    float startimgTime = 1f;

    [SerializeField] Text countdownText;

    // Start is called before the first frame update
     void Start()
     {
        currentTime = startimgTime;
     }

     void Update()
     {
        StartCoroutine(Count());
     }
     
     IEnumerator Count()
     {
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");
=======
        currentTime -= 0.1f * Time.deltaTime;
        //countdownText.text = currentTime.ToString("0");
>>>>>>> Stashed changes
=======
        currentTime -= 0.1f * Time.deltaTime;
        //countdownText.text = currentTime.ToString("0");
>>>>>>> Stashed changes
        if (currentTime <= 0)
        {
            currentTime = 0;
        }
        yield return new WaitForSeconds(1);
     }

    public void click()
    {
        Invoke("clickable", 1f);
    }

    public void clickable()
    {
        currentTime = 1;
    }
<<<<<<< Updated upstream
<<<<<<< Updated upstream
}
=======
}
>>>>>>> Stashed changes
=======
}
>>>>>>> Stashed changes
