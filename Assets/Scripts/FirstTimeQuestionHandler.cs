using UnityEngine;
using UnityEngine.UI;

public class FirstTimeQuestionHandler : MonoBehaviour
{
    [SerializeField] GameData GData;
    [SerializeField] Text QuestionText;
    [SerializeField] Text Option_A_Text;
    [SerializeField] Text Option_B_Text;
    [SerializeField] Text Option_C_Text;
    [SerializeField] Text Option_D_Text;
    [SerializeField] Text Question_No_Text;
    [SerializeField] GameObject ResultPanal;
    public MainMenuTutorialHandler MainMenuTutorial;
    [SerializeField] GameObject RightDesisionText;
    [SerializeField] GameObject WrongDesisionText;
    [SerializeField] Text RightAnswer_Text;
    [SerializeField] Text WrongAnswer_Text;
    [SerializeField] Text Score_Text;
    [SerializeField] Text Suggested_Difficuilty_Text;
    [SerializeField] GameObject NextBtn;
    public GameObject FirstTimeQuestionPanal;
    [SerializeField] GameObject MainMenuPanal;
    [SerializeField] Button[] AnswerBtn;
    [SerializeField] int CurrentQuestion = 1;
    public LevelLoader DIf;
    // Start is called before the first frame update
    void Start()
    {
        //StartOffLineTutorial();
    }
    public void LoadQuestion()
    {
        QuestionText.text = GData.QuestionLanguage[GData.SelectedLanguage].Question[CurrentQuestion - 1].ToString();
        Option_A_Text.text = GData.QuestionLanguage[GData.SelectedLanguage].Option_A[CurrentQuestion - 1].ToString();
        Option_B_Text.text = GData.QuestionLanguage[GData.SelectedLanguage].Option_B[CurrentQuestion - 1].ToString();
        Option_C_Text.text = GData.QuestionLanguage[GData.SelectedLanguage].Option_C[CurrentQuestion - 1].ToString();
        Option_D_Text.text = GData.QuestionLanguage[GData.SelectedLanguage].Option_D[CurrentQuestion - 1].ToString();
        Question_No_Text.text = (CurrentQuestion + "/" + 10).ToString(); ;
        for (int i = 0; i < AnswerBtn.Length; i++)
        {
            AnswerBtn[i].enabled = true;
        }
        RightDesisionText.SetActive(false);
        WrongDesisionText.SetActive(false);
    }

    public void AnswerBtnClick(int Answer)
    {
        if (Answer == GData.QuestionLanguage[GData.SelectedLanguage].Right_Answer[CurrentQuestion - 1])
        {
            GData.RightAnswer++;
            RightDesisionText.SetActive(true);
        }
        else
        {
            GData.WrongAnswer++;
            WrongDesisionText.SetActive(true);
        }
        for (int i = 0; i < AnswerBtn.Length; i++)
        {
            AnswerBtn[i].enabled = false;
        }
        NextBtn.SetActive(true);
    }
    public void OnNextBtnClick()
    {
        NextBtn.SetActive(false);
        if (CurrentQuestion < 10)
        {
            CurrentQuestion++;
            LoadQuestion();
            //Debug.Log("Next" + CurrentQuestion);
        }
        else
        {
            PersistentDataManager.instance.SaveData();
            ResultPanal.SetActive(true);
            FirstTimeQuestionPanal.transform.GetChild(0).gameObject.SetActive(false);
            Result();
        }
    }
    public void Result()
    {
        Debug.Log("Result");
        WrongAnswer_Text.text = ": " + GData.WrongAnswer;
        RightAnswer_Text.text = ": " + GData.RightAnswer;
        Score_Text.text = ": " + GData.RightAnswer * 5;
        if (GData.RightAnswer >= 8)
        {
            switch (GData.SelectedLanguage)
            {
                case 0:
                    Suggested_Difficuilty_Text.text = "Your suggested difficulty level is Hard.This is your recommended difficulty level. You can always change it from the settings menu.";
                    break;
                case 1:
                    Suggested_Difficuilty_Text.text = " Το προτεινόμενο επίπεδο δυσκολίας είναι Σκληρά. Αυτό είναι το προτεινόμενο επίπεδο δυσκολίας. Μπορείτε πάντα να το αλλάξετε από το μενού ρυθμίσεων.";
                    break;
                case 2:
                    Suggested_Difficuilty_Text.text = " Sugerowany poziom trudności to Trudny. To jest zalecany poziom trudności. Zawsze możesz to zmienić w menu ustawień.";
                    break;
            }
            GData.DifficultyLevel = 2;
            PersistentDataManager.instance.SaveData();
        }
        else if (GData.RightAnswer >= 5 && GData.RightAnswer < 8)
        {
            switch (GData.SelectedLanguage)
            {
                case 0:
                    Suggested_Difficuilty_Text.text = "Your suggested difficulty level is Medium.This is your recommended difficulty level. You can always change it from the settings menu.";
                    break;
                case 1:
                    Suggested_Difficuilty_Text.text = " Το προτεινόμενο επίπεδο δυσκολίας είναι Μεσαίο. Αυτό είναι το προτεινόμενο επίπεδο δυσκολίας. Μπορείτε πάντα να το αλλάξετε από το μενού ρυθμίσεων.";
                    break;
                case 2:
                    Suggested_Difficuilty_Text.text = " Sugerowany poziom trudności to Średni. To jest zalecany poziom trudności. Zawsze możesz to zmienić w menu ustawień.";
                    break;
            }
            GData.DifficultyLevel = 1;
            PersistentDataManager.instance.SaveData();
        }
        else if (GData.RightAnswer < 5)
        {
            switch (GData.SelectedLanguage)
            {
                case 0:
                    Suggested_Difficuilty_Text.text = "Your suggested difficulty level is easy.This is your recommended difficulty level. You can always change it from the settings menu.";
                    break;
                case 1:
                    Suggested_Difficuilty_Text.text = " Το προτεινόμενο επίπεδο δυσκολίας είναι Ανετα. Αυτό είναι το προτεινόμενο επίπεδο δυσκολίας. Μπορείτε πάντα να το αλλάξετε από το μενού ρυθμίσεων.";
                    break;
                case 2:
                    Suggested_Difficuilty_Text.text = " Sugerowany poziom trudności to łatwy. To jest zalecany poziom trudności. Zawsze możesz to zmienić w menu ustawień.";
                    break;
            }
            GData.DifficultyLevel = 0;
            PersistentDataManager.instance.SaveData();
        }
        DIf.StartDifficultySetting();
    }
    public void OKBtnClcik()
    {
        StartOffLineTutorial();
        FirstTimeQuestionPanal.SetActive(false);
        MainMenuPanal.SetActive(true);
    }
    public void StartOffLineTutorial()
    {
        GData.StartTutorial = true;
        PersistentDataManager.instance.SaveData();
        MainMenuTutorial.gameObject.SetActive(true);
        MainMenuTutorial.transform.GetComponent<MainMenuTutorialHandler>().enabled = true;
       
    }
}
