﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    PlayerHealth A;
    public bool isCorrect = false;
    public QuizManager quizManager;
    public Color startColor;

    private void Start()
    {
        //*startColor = GetComponent<Image>().color;
    }



    public void Answer()
    {
        if(isCorrect)
        {
            Sucess.SucessInstance.Audio.PlayOneShot(Sucess.SucessInstance.Click);
            GetComponent<Image>().color = Color.green;
            Debug.Log("Correct Answer");
            quizManager.correct();

            A.Update();


        }
        else
        {
            Fail.FailInstance.Audio.PlayOneShot(Fail.FailInstance.Click);
            GetComponent<Image>().color = Color.red;
            Debug.Log("Wrong Answer");
            quizManager.wrong();

            A.Update();


        }
    }

}
