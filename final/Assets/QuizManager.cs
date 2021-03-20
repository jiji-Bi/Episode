using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public GameObject QuizPanel;
    public GameObject GoPanel;



  

    public Text QuestionTxt;
    public Text ScoreTxt ;
    public int score;
    public int wrongAnswers ;
    public Text Result;
    ////public Color Correctcolor ;
    //public Color Wrongcolor;
    //public Color Normalcolor;


    int totalQuestions = 0;
    

    private void Start()
    {
        GoPanel.SetActive(false);
        totalQuestions = QnA.Count;
        generateQuestion();
    }
    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }
   
    void GameOver()
    {
        QuizPanel.SetActive(false);
        GoPanel.SetActive(true);
        if (score > totalQuestions / 2)
        {
            ScoreTxt.text = "Your Score is : " + score + "/" + totalQuestions;
            Result.text = "YOU WON  !  ";
        }
        else
        {
            ScoreTxt.text = "Your Score is : " + score + "/" + totalQuestions;
            Result.text = "YOU LOST  ! ";
        }

        
    }



    public void correct()
    {
        score +=1; 
        QnA.RemoveAt(currentQuestion);
        generateQuestion();

    }
    public void wrong()
    {
        // wrong answer 
        wrongAnswers +=1;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }
  
   

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {



            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];
            
            if(QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;



            }
            else
            {
                options[i].GetComponent<AnswerScript>().isCorrect = false;


            }


        }
    }

    void generateQuestion()
    {
        if(QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            GameOver(); 
        }
       

    }
}
