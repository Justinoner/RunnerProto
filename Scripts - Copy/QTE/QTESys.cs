using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTESys : MonoBehaviour
{
    [SerializeField]
    public GameObject DisplayBox;
    public GameObject PassBox;
    [SerializeField]
    public int QTEGen;
    public int WaitingForKey;
    public int CorrectKey;
    public int CountingDown;

    void Update()
    {
        if (WaitingForKey == 0)
        {
            QTEGen = 1;
            CountingDown = 1;
            StartCoroutine(CountDown ());

            if (QTEGen == 1)
            {
                WaitingForKey = 1;
                DisplayBox.GetComponent<Text>().text = "[M1]";
            }
        }
        if (QTEGen == 1)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetButtonDown("M1Key"))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());

                }

            }
        }

    }
    IEnumerator KeyPressing()
    {
        QTEGen = 1;
        if (CorrectKey == 1)
        {
            CountingDown = 2;
            PassBox.GetComponent<Text>().text = "Pass!";
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<Text>().text = "";
            DisplayBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(10f);
            WaitingForKey = 0;
            CountingDown = 1;
        }
    }
    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(2f);
        if (CountingDown == 1)
        {
            QTEGen = 1;
            CountingDown = 2;
            PassBox.GetComponent<Text>().text = "Fail!";
            yield return new WaitForSeconds(1f);
            CorrectKey = 0;
            PassBox.GetComponent<Text>().text = "";
            DisplayBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(10f);
            WaitingForKey = 0;
            CountingDown = 1;
        }
    }
}