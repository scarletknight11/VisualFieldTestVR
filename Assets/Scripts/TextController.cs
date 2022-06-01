using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{

    public Light sceneLight;
    public Text contrast;
    public Text contrast2;
    public Text contrast3;
    public Text contrast4;
    public Text message;
    public Text simulationover;
    public GameObject messaging;
    public GameObject sim;
    public GameObject button;
    public GameObject light;
    public float contrastlevel = 1.0f;
    public float contrastlevel2 = 1.0f;
    public float contrastlevel3 = 1.0f;
    public float contrastlevel4 = 1.0f;
    public ComputeBrightness bright;
    public Text largeText;
    public float currentTime = 0f;
    float startimgTime = 1f;
    public float clicked;
    public string lastresponse = "yes";
    public string newresponse;
    //public float[] reversals;
 
    [SerializeField] Text countdownText;
    [SerializeField] Text reversaltext;

    void Start()
    {
        sceneLight.intensity = contrastlevel;
        currentTime = startimgTime;
        //PickRandomFromList();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Count());
        contrast.text = "Contrast Level: " + contrastlevel;
        contrast2.text = "Contrast Level: " + contrastlevel2;
        contrast3.text = "Contrast Level: " + contrastlevel3;
        contrast4.text = "Contrast Level: " + contrastlevel4;
        message.text = "Can you see? ";
        sceneLight.intensity = contrastlevel;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            contrastlevel -= 0.05f;
            clicked = 1;
            lastresponse = "yes";
            if (contrastlevel <= 0)
            {
                contrastlevel = 0;
            }
        }
    }

    public void yes()
    {
        contrastlevel -= 0.05f;
        clicked = 1;
        newresponse = "yes";
        if (contrastlevel <= 0)
        {
            contrastlevel = 0;
        }
    }

    public void no()
    {
        contrastlevel += 0.05f;
        newresponse = "no";

        if (contrastlevel > 1)
        {
            contrastlevel = 1;
        }
    }

    public void PickRandomFromList()
    {
        int num = 1;
        int num2 = 2;
        int num3 = 3;
        int num4 = 4;
        string[] groups = new string[] { "Group " + num, "Group " + num2, "Group " + num3, "Group " + num4 };
        string randomgroups = groups[Random.Range(0, groups.Length)];
        largeText.text = randomgroups;

        if (randomgroups == "Group " + num)
        {
            GameObject.Find("ContrastText").SetActive(true);
            contrast.text = "Contrast Level: " + contrastlevel;
            GameObject.Find("ContrastText2").SetActive(false);
            GameObject.Find("ContrastText3").SetActive(false);
            GameObject.Find("ContrastText4").SetActive(false);
        }
        else if (randomgroups == "Group " + num2)
        {
            GameObject.Find("ContrastText").SetActive(false);
            GameObject.Find("ContrastText2").SetActive(true);
            contrast2.text = "Contrast Level: " + contrastlevel2;
            GameObject.Find("ContrastText3").SetActive(false);
            GameObject.Find("ContrastText4").SetActive(false);
        }
        else if (randomgroups == "Group " + num3)
        {
            GameObject.Find("ContrastText").SetActive(false);
            GameObject.Find("ContrastText2").SetActive(false);
            GameObject.Find("ContrastText3").SetActive(true);
            contrast3.text = "Contrast Level: " + contrastlevel3;
            GameObject.Find("ContrastText4").SetActive(false);
        }
        else if (randomgroups == "Group " + num4)
        {
            GameObject.Find("ContrastText").SetActive(false);
            GameObject.Find("ContrastText2").SetActive(false);
            GameObject.Find("ContrastText3").SetActive(false);
            GameObject.Find("ContrastText4").SetActive(true);
            contrast4.text = "Contrast Level: " + contrastlevel4;
        }
    }

    IEnumerator Count()
    {
        currentTime -= 0.2f * Time.deltaTime;
        yield return new WaitForSeconds(1f);
        if (currentTime <= 0f)
        {
            currentTime = 1;
            //PickRandomFromList();
            bright.spawnobjects();
            clicked = 0;
        } else if (clicked == 0f && currentTime <= 0.005167351f)
        {
            //Debug.Log("NO");
            //newresponse = "no";
            no();
            currentTime = 1;
            bright.spawnobjects();
        }

        if (newresponse == "yes" || newresponse == "no")
        {
            if (newresponse != lastresponse)
            {
                lastresponse = newresponse;
                Debug.Log("Reversal ");
            }
        }
    }
}