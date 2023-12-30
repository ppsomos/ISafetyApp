using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fillmanager : MonoBehaviour
{
   public Fillquestions[] questions;
	public static List<Fillquestions> unansweredQuestions;

	private Fillquestions currentQuestion;
	[SerializeField]
	private Text factText;
	public Text userinput;
	public List<string> answer = new List<string>();

    public void Start()
	{
		if (unansweredQuestions == null || unansweredQuestions.Count == 0)
		{
			unansweredQuestions = questions.ToList<Fillquestions>();
		}

		SetCurrentQuestion();

	}
	void SetCurrentQuestion()
	{
		int randomQuestionsIndex = Random.Range(0, unansweredQuestions.Count);
		currentQuestion = questions[randomQuestionsIndex];
		factText.text = currentQuestion.fact;
	}
	IEnumerator transtiontonextquestion()
    {
        yield return new WaitForSeconds(1f);
		unansweredQuestions.Remove(currentQuestion);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
	public void correctansweer()
	{
        for (int i = 0; i < answer.Count; i++)
            {
			if (userinput.text.ToLower() == answer[i])
			{
                Debug.Log("right");

                StartCoroutine(transtiontonextquestion());	
			}
            else
            {
                Debug.Log("wrong");

                StartCoroutine(transtiontonextquestion());	
			}
		}
	}
}
