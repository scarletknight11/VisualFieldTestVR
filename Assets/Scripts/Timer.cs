using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Timer : MonoBehaviour {

    [SerializeField] private Image uiFill;
    [SerializeField] private Text uiText;

    public int duration;
    private int remainingDuration;
    private bool Pause;

    // Start is called before the first frame update
    private void Start()
    {
        Being(duration);
    }

    private void Being(int Second)
    {
        remainingDuration = Second;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while(remainingDuration >= 0)
        {
            if (!Pause)
            {
                uiText.text = $"{remainingDuration / 60:00} : {remainingDuration % 60:00}";
                uiFill.fillAmount = Mathf.InverseLerp(0, duration, remainingDuration);
                remainingDuration--;
                yield return new WaitForSeconds(1f);

            }
            yield return null;
        }
        OnEnd();
    }
   
    private void OnEnd()
    {
        //End Time
        print("End");
    }
}