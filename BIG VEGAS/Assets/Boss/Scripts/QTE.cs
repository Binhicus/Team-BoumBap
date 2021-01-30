using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTE : MonoBehaviour
{
    public GameObject displayBox;
    public GameObject passBox;
    public int QTE_Gen;
    public int waitingForKey;
    public int correctKey;
    public int countingDown;
    public int score = 0;
    public int debut = 0;

    void Update()
    {
        if (debut == 0)
        {
            StartCoroutine(Wait());
        }
        if (debut == 1)
        {

        if(waitingForKey == 0)
        {
            debut = 1;
            QTE_Gen = Random.Range(1, 4);
            countingDown = 1;
            StartCoroutine(CountDown());

            if(QTE_Gen == 1)
            {
                waitingForKey = 1;
                displayBox.GetComponent<Text>().text = "E";
            }

            if (QTE_Gen == 2)
            {
                waitingForKey = 1;
                displayBox.GetComponent<Text>().text = "R";
            }

            if (QTE_Gen == 3)
            {
                waitingForKey = 1;
                displayBox.GetComponent<Text>().text = "T";
            }
        }

        if(QTE_Gen == 1)
        {
            if(Input.anyKeyDown)
            {
                if(Input.GetButtonDown("EKey"))
                {
                    correctKey = 1;
                    StartCoroutine(KeyPressing());
                    score++;
                }
                else
                {
                    correctKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }

        if (QTE_Gen == 2)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetButtonDown("RKey"))
                {
                    correctKey = 1;
                    StartCoroutine(KeyPressing());
                    score++;
                }
                else
                {
                    correctKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }

        if (QTE_Gen == 3)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetButtonDown("TKey"))
                {
                    correctKey = 1;
                    StartCoroutine(KeyPressing());
                    score++;
                }
                else
                {
                    correctKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }

             if(score == 20)
             {
                  StartCoroutine(Win());
             }
        }
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        debut++;
    }

    IEnumerator KeyPressing()
    {
        QTE_Gen = 4;
        if(correctKey == 1)
        {
            countingDown = 2;
            passBox.GetComponent<Text>().text = "FABULOUS!";
            yield return new WaitForSeconds(0.75f);
            correctKey = 0;
            passBox.GetComponent<Text>().text = "";
            displayBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(0.75f);
            waitingForKey = 0;
            countingDown = 1;
        }

        if (correctKey == 2)
        {
            countingDown = 2;
            passBox.GetComponent<Text>().text = "FAIL...";
            yield return new WaitForSeconds(2f);
            correctKey = 0;
            passBox.GetComponent<Text>().text = "LOSER!";
        }
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(3.5f);
        if(countingDown == 1)
        {
            QTE_Gen = 4;
            countingDown = 2;
            passBox.GetComponent<Text>().text = "FAIL...";
            yield return new WaitForSeconds(1.5f);
            correctKey = 0;
            passBox.GetComponent<Text>().text = "";
            displayBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(1.5f);
            waitingForKey = 0;
            countingDown = 1;
            score--;
        }
    }

    IEnumerator Win()
    {
        if(score == 20)
        {
            countingDown = 2;
            yield return new WaitForSeconds(2f);
            correctKey = 0;
            passBox.GetComponent<Text>().text = "ROCKSTAR!";
            score = 0;
        }
    }
}
