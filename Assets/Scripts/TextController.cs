using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

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
    public string yesresponse = "";
    public string noresponse = "";
    [SerializeField] Text countdownText;

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
        message.text = "Can you see? ";
        sceneLight.intensity = contrastlevel;
    }

    public void yes()
    {
        contrastlevel -= 0.05f;
        clicked = 1;
        yesresponse = "yes";
        if (contrastlevel <= 0)
        {
            contrastlevel = 0;
        }
    }

    public void no()
    {
        noresponse = "no";
        contrastlevel += 0.05f;
        if (contrastlevel > 1)
        {
            contrastlevel = 1;
        }
    }

    //public void PickRandomFromList()
    //{
    //    //int num = Random.Range(1, 4);
    //    int num = 1;
    //    int num2 = 2;
    //    int num3 = 3;
    //    int num4 = 4;
    //    string[] students = new string[] { "Group " + num, "Group " + num2, "Group " + num3, "Group " + num4 };
    //    string randomName = students[Random.Range(0, students.Length)];
    //    largeText.text = randomName;

    //    if (randomName == "Group " + num)
    //    {
    //        GameObject.Find("ContrastText").SetActive(true);
    //        GameObject.Find("ContrastText2").SetActive(false);
    //        GameObject.Find("ContrastText3").SetActive(false);
    //        GameObject.Find("ContrastText4").SetActive(false);
    //    }
    //    else if (randomName == "Group " + num2)
    //    {
    //        GameObject.Find("ContrastText").SetActive(false);
    //        GameObject.Find("ContrastText2").SetActive(true);
    //        GameObject.Find("ContrastText3").SetActive(false);
    //        GameObject.Find("ContrastText4").SetActive(false);
    //    }
    //    else if (randomName == "Group " + num3)
    //    {
    //        GameObject.Find("ContrastText").SetActive(false);
    //        GameObject.Find("ContrastText2").SetActive(false);
    //        GameObject.Find("ContrastText3").SetActive(true);
    //        GameObject.Find("ContrastText4").SetActive(false);
    //    }
    //    else if (randomName == "Group " + num4)
    //    {
    //        GameObject.Find("ContrastText").SetActive(false);
    //        GameObject.Find("ContrastText2").SetActive(false);
    //        GameObject.Find("ContrastText3").SetActive(false);
    //        GameObject.Find("ContrastText4").SetActive(true);
    //    }
    //}

    IEnumerator Count()
    {
        currentTime -= 0.2f * Time.deltaTime;
        yield return new WaitForSeconds(1f);
        if (currentTime <= 0f)
        {
            //yield return new WaitForSeconds(1f);
            currentTime = 1;
            //PickRandomFromList();
            bright.spawnobjects();
            clicked = 0;
        }
        else if (clicked == 0f && currentTime <= 0)
        {
            no();
            currentTime = 1;
            bright.spawnobjects();
        }

        if (yesresponse != noresponse && noresponse == "no")
        {
            Debug.Log("Reversal ");
            yesresponse = "";
            noresponse = "";
        }
    }
}