using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer : MonoBehaviour
{
    public bool iscorrect = false;
    public GameManagers gameman;
    //public GameObject QuestionPanal;
    public GameObject quizpanal;
    public GameObject TryAgainPanal;
    public GameObject LevelComplete;
    
    public void Answers()
    {
        if (iscorrect)
        {
            Debug.Log("Correct Answer");
            quizpanal.SetActive(false);
            LevelComplete.SetActive(true);
        }
        else
        {
            Debug.Log("Wrong Answer");
            TryAgainPanal.SetActive(true);
            quizpanal.SetActive(false);

        }
    }
}
