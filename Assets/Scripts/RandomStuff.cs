using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomStuff : MonoBehaviour
{
    public Text largeText;

    public void BtnAction()
    {
        PickRandomNumber(6);
    }

    public void BtnAction2()
    {
        PickRandomFromList();
    }

    private void PickRandomNumber(int maxint)
    {
        int randomNum = Random.Range(1, maxint + 1);
        largeText.text = randomNum.ToString();
    }

    private void PickRandomFromList()
    {
        //int num = Random.Range(1, 4);
        int num = 1;
        int num2 = 2;
        int num3 = 3;
        int num4 = 4;
        string[] students = new string[] { "Group " + num, "Group " + num2, "Group " + num3, "Group " + num4};
        string randomName = students[Random.Range(0, students.Length)];
        largeText.text = randomName;
    }

}
