
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BelgiumManager : MonoBehaviour
{
    [Header("True/False Data")]
    public TrueFalseData TFData;
    public TrueFalseData TFData_Greek;
    public TrueFalseData TFData_Polish;
    public GameData GData;
    [Header("MCQ Data")]
    public MCQData MCQSData;
    public MCQData MCQSData_Greek;
    public MCQData MCQSData_Polish;
    public PosterData Poster;
    public GameObject[] Room_Poster;
    public Image[] Canves_Room_Poster;
    /// <summary>
    /// Fake News Quizes Data
    /// </summary>
    /// 

    //public string[] TFQuestions;
    //public int[] TFAns;
    private const string TF_KEY = "TF";
    private const string MCQS_KEY = "MCQS";

    public Button TickButton1;
    public Button TickButton2;
    public Button TickButton3;

    public Button ResetButton;



    public Text CorrectAnswerText;
    public Text WrongAnswerText;



    public string[] historyQues;
    public int[] historyAns;
    public FindIndex[] HistoryAnsMcqs = new FindIndex[6];
    public static string historyFinalAnswer;
    //public static int historyQuizIndex;

    private Option[] histOp1 = new Option[6];
    private Option[] histOp2 = new Option[6];
    private Option[] histOp3 = new Option[6];



    public Text historyQuestonText;
    public Text[] historyOptionTexts;
    public TextMeshProUGUI historyScoreText;
    public GameObject historyCompleteImage;

    /// <summary>
    /// Geography Quiz Data
    /// </summary>
    /// 
    public int[] geographyAns;
    public FindIndex[] geographyAnsMcqs = new FindIndex[4];
    public string[] geographyQues;
    public static string geographyFinalAnswer;
    //public static int geographyQuizIndex;

    private Option[] geogOp1 = new Option[4];
    private Option[] geogOp2 = new Option[4];
    private Option[] geogOp3 = new Option[4];



    public Text geographyQuestonText;
    public Text[] geographyOptionTexts;
    public TextMeshProUGUI geographyScoreText;
    public GameObject geographyCompleteImage;


    /// <summary>
    /// Food Quiz Data
    /// </summary>
    /// 
    public int[] foodAns;
    public FindIndex[] foodAnsMcqs = new FindIndex[6];
    public string[] foodQues;
    public static string foodFinalAnswer;
    //public static int foodQuizIndex;

    private Option[] foodOp1 = new Option[6];
    private Option[] foodOp2 = new Option[6];
    private Option[] foodOp3 = new Option[6];


    public Text foodQuestonText;
    public Text[] foodOptionTexts;
    public TextMeshProUGUI foodScoreText;
    public GameObject foodCompleteImage;

    /// <summary>
    /// Culture Quiz Data
    /// </summary>
    /// 
    public int[] cultureAns;
    public FindIndex[] cultureAnsMcqs = new FindIndex[4];
    public string[] cultureQues;
    public static string cultureFinalAnswer;
    //public static int cultureQuizIndex;

    private Option[] culOp1 = new Option[4];
    private Option[] culOp2 = new Option[4];
    private Option[] culOp3 = new Option[4];


    public Text cultureQuestonText;
    public Text[] cultureOptionTexts;
    public TextMeshProUGUI cultureScoreText;
    public GameObject cultureCompleteImage;

    ///// <summary>
    ///// Language Quiz Data
    ///// </summary>
    ///// 
    //public string[] languageQues;
    //public static string languageFinalAnswer;
    //public static int languageyQuizIndex;

    //private Option[] langOp1 = new Option[5];
    //private Option[] langOp2 = new Option[5];
    //private Option[] langOp3 = new Option[5];
    //private Option[] langOp4 = new Option[5];

    //public Text languageQuestonText;
    //public Text[] languageOptionTexts;
    //public TextMeshProUGUI languageScoreText;
    //public GameObject languageCompleteImage;


    /// <summary>
    /// General Variables
    /// </summary>
    /// 
    enum answer { wrong, correct };
    public static int selectedCategory = 0;
    public GameObject quizPanel;
    public GameObject levelCompletePanel;
    public Text LevelCompleteText;
    [SerializeField] GameObject Background;
    public GameObject levelFailPanel;
    public GameObject cameraobj;

    public GameObject congratsPanel;
    public GameObject playerController;
    public GameObject playerControllerCanvas;
    public GameObject MainCanvas;
    private bool Ischaracter;

    public BoxCollider door2Col;
    public GameObject controller;

    public LoadManager loadingManager;
    public Button RemoveTextStyle;
    public Button quizHist;
    public Button quizGeo;
    public Button quizFood;
    public Button quizCult;
    public CountDown countDown;
    public Button ReadQuestion;
    public GameObject RoomCompleteParticleEffect;
    public TMP_Text ShowScore;
    public ParticleSystem Confetti1;
    public ParticleSystem Confetti2;
    void Start()
    {
        selectedCategory = 0;
        PlayerPrefs.SetString("SelectedManager", "BL");
        UpdateGameProgress();
        //RemoveTextStyle.onClick.RemoveAllListeners();
        //RemoveTextStyle.onClick.AddListener(RemoveTextStyleFunc);
      //  SetPoster();
    }
    private void Update()
    {
        if (!Ischaracter)
        {
            if (FindObjectOfType<CharacterController>())
            {
                Ischaracter = true;
                playerController = FindObjectOfType<CharacterController>().gameObject;
            }
        }

    }
    //public void SetPoster()
    //{
    //    int Sel = PlayerPrefs.GetInt("levelcurrent") - 1;
    //    for (int i = 0; i < Room_Poster.Length; i++)
    //    {
    //        Canves_Room_Poster[i].GetComponent<Image>().sprite = Poster.Room[Sel].PosterLanguage[GData.SelectedLanguage].Poster[i].Poster_Sprite;
    //        Room_Poster[i].GetComponent<SpriteRenderer>().sprite = Poster.Room[Sel].PosterLanguage[GData.SelectedLanguage].Poster[i].Poster_Sprite;
    //    }
    //}
    public void UpdateGameProgress()
    {
        OptionButtonHandle(true);
        if (!GameManager.Instance.IsMulti)
        {
            historyScoreText.text = PlayerPrefs.GetInt("BelgiumHist") + "/3";
            geographyScoreText.text = PlayerPrefs.GetInt("BelgiumGeo") + "/3";
            foodScoreText.text = PlayerPrefs.GetInt("BelgiumFood") + "/3";
            cultureScoreText.text = PlayerPrefs.GetInt("BelgiumCult") + "/3";
            //   languageScoreText.text = PlayerPrefs.GetInt("BelgiumLang") + "/3";
            if (PlayerPrefs.GetInt("BelgiumHist") >= 3)
            {
                quizHist.interactable = false;

                historyCompleteImage.SetActive(true);
            }
            if (PlayerPrefs.GetInt("BelgiumGeo") >= 3)
            {
                quizGeo.interactable = false;

                geographyCompleteImage.SetActive(true);
            }
            if (PlayerPrefs.GetInt("BelgiumFood") >= 3)
            {
                quizFood.interactable = false;
                foodCompleteImage.SetActive(true);
            }
            if (PlayerPrefs.GetInt("BelgiumCult") >= 3)
            {
                quizCult.interactable = false;
                cultureCompleteImage.SetActive(true);
            }

            if ((levelFailPanel.activeInHierarchy) || PlayerPrefs.GetInt("Level2") >= 4)
            {
                LevelFail();
            }
        }
        else
        {
            historyScoreText.text = GData.Room[1].HisQ[0].AnswerGiven + "/3";
            geographyScoreText.text = GData.Room[1].GeoQ[0].AnswerGiven + "/3";
            foodScoreText.text = GData.Room[1].FoodQ[0].AnswerGiven + "/3";
            cultureScoreText.text = GData.Room[1].CulQ[0].AnswerGiven + "/3";
            if (GData.Room[1].No_Of_Obj_Complete < 4)
            {
                if (GData.Room[1].HisQ[0].AnswerGiven >= GData.Room[1].HisQ[0].TotalQuestion)
                {
                    if (!GData.Room[1].HisQ[0].IsComplte)
                    {
                        GData.Room[1].HisQ[0].IsComplte = true;
                        GData.Room[1].No_Of_Obj_Complete++;
                        PersistentDataManager.instance.SaveData();
                        historyCompleteImage.SetActive(true);
                    }
                    else
                    {
                        ReadQuestion.interactable = false;
                    }
                }
                if (GData.Room[1].GeoQ[0].AnswerGiven >= GData.Room[1].GeoQ[0].TotalQuestion)
                {
                    if (!GData.Room[1].GeoQ[0].IsComplte)
                    {
                        GData.Room[1].GeoQ[0].IsComplte = true;
                        GData.Room[1].No_Of_Obj_Complete++;
                        PersistentDataManager.instance.SaveData();
                        geographyCompleteImage.SetActive(true);
                    }
                    else
                    {
                        ReadQuestion.interactable = false;
                    }
                }
                if (GData.Room[1].FoodQ[0].AnswerGiven >= GData.Room[1].FoodQ[0].TotalQuestion)
                {
                    if (!GData.Room[1].FoodQ[0].IsComplte)
                    {
                        GData.Room[1].FoodQ[0].IsComplte = true;
                        GData.Room[1].No_Of_Obj_Complete++;
                        PersistentDataManager.instance.SaveData();
                        foodCompleteImage.SetActive(true);
                    }
                    else
                    {
                        ReadQuestion.interactable = false;
                    }
                }
                if (GData.Room[1].CulQ[0].AnswerGiven >= GData.Room[1].CulQ[0].TotalQuestion)
                {
                    if (!GData.Room[1].CulQ[0].IsComplte)
                    {
                        GData.Room[1].CulQ[0].IsComplte = true;
                        GData.Room[1].No_Of_Obj_Complete++;
                        PersistentDataManager.instance.SaveData();
                        cultureCompleteImage.SetActive(true);
                    }
                    else
                    {
                        ReadQuestion.interactable = false;
                    }
                }

                if (GData.Room[1].No_Of_Obj_Complete == 4)
                {
                    GData.Player[GameManager.Instance.SelectedPlayer].IsComplete = true;
                    GData.Player[GameManager.Instance.SelectedPlayer].TimeTaken = GData.GameTime - PlayerPrefs.GetFloat("TimeRemaining");
                    PersistentDataManager.instance.SaveData();
                    //if (GameManager.Instance.SelectedPlayer < 1)
                    //{
                        //Debug.Log("22222");
                        CountDown.timerIsRunning = true;
                        RoomCompleteParticleEffect.SetActive(true);
                        //congratsPanel.SetActive(true);
                         //cultureCompleteImage.SetActive(false);
                    //    //playerController.SetActive(false);
                    //}
                    //else
                    //{
                    //    GameUIManager.Instance.OnCompetitionComplete();
                    //}
                }
            }
        }
    }
    public void LevelFail()
    {
        if (PlayerPrefs.GetInt("BMscore") >= 30)
        {
            RoomCompleteParticleEffect.SetActive(true);
        }
        else
        {
            levelFailPanel.SetActive(true);
            levelFailPanel.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
            Debug.Log(PlayerPrefs.GetInt("BMscore"));
            switch (GData.SelectedLanguage)
            {
                case 0:
                    ShowScore.text = $"Your Score is {PlayerPrefs.GetInt("BMscore")}" + "/60";
                    break;
                case 1:
                    ShowScore.text = $"Το σκορ σου είναι {PlayerPrefs.GetInt("BMscore")}" + "/60";
                    break;
                case 2:
                    ShowScore.text = $"Twój wynik to {PlayerPrefs.GetInt("BMscore")}" + "/60";
                    break;
            }
        }
    }
    public void CompleteRoom()
    {
        if (!GameManager.Instance.IsMulti)
        {
            PlayerPrefs.SetInt("levelunlocked", 0);
            if (GData.UnlockedLevel < 6)
            {
                GData.UnlockedLevel = 2;
            }
            PersistentDataManager.instance.SaveData();
            congratsPanel.SetActive(true);
            playerController.SetActive(false);
            playerControllerCanvas.SetActive(false);
            MainCanvas.SetActive(false);

            GameManagers.score = PlayerPrefs.GetInt("Score") + 12;


            PlayerPrefs.SetInt("Score", GameManagers.score);
            PlayerPrefs.Save();

            // Report a score of 100
            // EM_GameServicesConstants.Sample_Leaderboard is the generated name constant
            // of a leaderboard named "Sample Leaderboard"
           // GameServices.ReportScore(PlayerPrefs.GetInt("Score"), EM_GameServicesConstants.Leaderboard_Escape_Hero);

            countDown.timeRemaining = GData.GameTime;
            CountDown.timerIsRunning = true;
            PlayerPrefs.SetFloat("TimeRemaining", countDown.timeRemaining);
            PlayerPrefs.Save();


            PlayerPrefs.SetInt("Level2", 0);
            PlayerPrefs.SetInt("LevelM2", 1);
            PlayerPrefs.Save();
        }
        else
        {
            if (GameManager.Instance.SelectedPlayer == 0)
            {
                cultureCompleteImage.SetActive(false);
                //door1Col.isTrigger = true;
                congratsPanel.SetActive(true);
                playerController.SetActive(false);
                playerControllerCanvas.SetActive(false);
                MainCanvas.SetActive(false);
                congratsPanel.transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(false);
                congratsPanel.transform.GetChild(1).transform.GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                GameUIManager.Instance.OnCompetitionComplete();
            }
        }
    }

    #region History Quiz Data

    //****************** True False *************// 
    public void SetHistoryQuizData(int index) //USED
    {
        //onclicks added or removed
        TickButton1.onClick.RemoveAllListeners();
        TickButton1.onClick.AddListener(() => AnswerBtnClick(historyOptionTexts[0], TF_KEY, TickButton1));

        TickButton2.onClick.RemoveAllListeners();
        TickButton2.onClick.AddListener(() => AnswerBtnClick(historyOptionTexts[1], TF_KEY, TickButton2));

        ResetButton.onClick.RemoveAllListeners();
        ResetButton.onClick.AddListener(() => ResetQuestionaPanel(TF_KEY));

        TickButton3.gameObject.SetActive(false);

        selectedCategory = index;
        SetHistoryOptionData();
        //int temp = historyQuizIndex;

        //historyQuizIndex = Random.Range(0, historyQues.Length);

        //if (temp == historyQuizIndex)
        //{
        //    historyQuizIndex = Random.Range(0, historyQues.Length);
        //}

        ////Debug.Log(historyQuizIndex);

        historyQuestonText.text = historyQues[GData.BLhistoryQuizIndex];

        historyOptionTexts[0].text = histOp1[GData.BLhistoryQuizIndex].answer;
        historyOptionTexts[1].text = histOp2[GData.BLhistoryQuizIndex].answer;

        //setting style
        //SetTextStyle(historyOptionTexts[0], historyOptionTexts[1]);

        if (historyAns[GData.BLhistoryQuizIndex] == 0)
        {
            historyFinalAnswer = histOp1[GData.BLhistoryQuizIndex].answer;
        }
        else if (historyAns[GData.BLhistoryQuizIndex] == 1)
        {
            historyFinalAnswer = histOp2[GData.BLhistoryQuizIndex].answer;
        }

        //Debug.Log(historyFinalAnswer);
    }

    private void SetHistoryOptionData()
    {

        for (int i = 0; i < 6; i++)
        {
            historyQues = new string[6];
            historyQues[i] = "";

            historyAns = new int[6];
            historyAns[i] = 0;
        }



        for (int i = 0; i < histOp1.Length; i++)
        {
            histOp1[i] = new Option();
        }
        for (int i = 0; i < histOp2.Length; i++)
        {
            histOp2[i] = new Option();
        }

        switch (GData.SelectedLanguage)
        {
            case 0:
                for (int i = 0; i < 6; i++)
                {
                    historyQues[i] = TFData.questions[i];
                    historyAns[i] = TFData.answersIndex[i];

                    histOp1[i].answer = TFData.Op1[i];
                    histOp2[i].answer = TFData.Op2[i];

                }
                break;
            case 1:
                for (int i = 0; i < 6; i++)
                {
                    historyQues[i] = TFData_Greek.questions[i];
                    historyAns[i] = TFData_Greek.answersIndex[i];

                    histOp1[i].answer = TFData_Greek.Op1[i];
                    histOp2[i].answer = TFData_Greek.Op2[i];

                }
                break;
            case 2:
                for (int i = 0; i < 6; i++)
                {
                    historyQues[i] = TFData_Polish.questions[i];
                    historyAns[i] = TFData_Polish.answersIndex[i];

                    histOp1[i].answer = TFData_Polish.Op1[i];
                    histOp2[i].answer = TFData_Polish.Op2[i];

                }
                break;
        }


    }

    //****************** Mcqs *************// 
    public void SetHistoryQuizDataMCQS(int index) //Unused
    {
        //onclicks added or removed
        TickButton1.onClick.RemoveAllListeners();
        TickButton1.onClick.AddListener(() => AnswerBtnClick(historyOptionTexts[0], MCQS_KEY, TickButton1));

        TickButton2.onClick.RemoveAllListeners();
        TickButton2.onClick.AddListener(() => AnswerBtnClick(historyOptionTexts[1], MCQS_KEY, TickButton2));

        TickButton3.onClick.RemoveAllListeners();
        TickButton3.onClick.AddListener(() => AnswerBtnClick(historyOptionTexts[2], MCQS_KEY, TickButton3));

        ResetButton.onClick.RemoveAllListeners();
        ResetButton.onClick.AddListener(() => ResetQuestionaPanel(MCQS_KEY));

        TickButton3.gameObject.SetActive(true);

        selectedCategory = index;
        SetHistoryOptionDataMCQS();
        //int temp = historyQuizIndex;

        //historyQuizIndex = Random.Range(0, historyQues.Length);

        //if (temp == historyQuizIndex)
        //{
        //    historyQuizIndex = Random.Range(0, historyQues.Length);
        //}

        ////Debug.Log(historyQuizIndex);

        historyQuestonText.text = historyQues[GData.BLhistoryQuizIndex];

        historyOptionTexts[0].text = histOp1[GData.BLhistoryQuizIndex].answer;
        historyOptionTexts[1].text = histOp2[GData.BLhistoryQuizIndex].answer;
        historyOptionTexts[2].text = histOp3[GData.BLhistoryQuizIndex].answer;

        ////Debug.Log(HistoryAnsMcqs[historyQuizIndex].Index.Length);

        for (int i = 0; i < HistoryAnsMcqs[GData.BLhistoryQuizIndex].Index.Length; i++)
        {
            if (int.Parse(HistoryAnsMcqs[GData.BLhistoryQuizIndex].Index[i]) == 0)
            {
                TickButton1.GetComponent<Answer>().iscorrect = true;
            }
            if (int.Parse(HistoryAnsMcqs[GData.BLhistoryQuizIndex].Index[i]) == 1)
            {
                TickButton2.GetComponent<Answer>().iscorrect = true;
            }
            if (int.Parse(HistoryAnsMcqs[GData.BLhistoryQuizIndex].Index[i]) == 2)
            {
                TickButton3.GetComponent<Answer>().iscorrect = true;
            }
        }


        //if (historyAns[historyQuizIndex] == 0)
        //{
        //    historyFinalAnswer = histOp1[historyQuizIndex].answer;
        //}
        //else if (historyAns[historyQuizIndex] == 1)
        //{
        //    historyFinalAnswer = histOp2[historyQuizIndex].answer;
        //}
        //else if (historyAns[historyQuizIndex] == 2)
        //{
        //    historyFinalAnswer = histOp3[historyQuizIndex].answer;
        //}

        //Debug.Log(historyFinalAnswer);
    }

    private void SetHistoryOptionDataMCQS()
    {

        for (int i = 0; i < 3; i++)
        {
            historyQues = new string[3];
            historyQues[i] = "";

            historyAns = new int[3];
            historyAns[i] = 0;
        }



        for (int i = 0; i < histOp1.Length; i++)
        {
            histOp1[i] = new Option();
        }
        for (int i = 0; i < histOp2.Length; i++)
        {
            histOp2[i] = new Option();
        }
        for (int i = 0; i < histOp3.Length; i++)
        {
            histOp3[i] = new Option();
        }
        for (int i = 0; i < HistoryAnsMcqs.Length; i++)
        {
            HistoryAnsMcqs[i] = new FindIndex();
        }


        switch (GData.SelectedLanguage)
        {
            case 0:
                for (int i = 0; i < 3; i++)
                {
                    historyQues[i] = MCQSData.questions[i];
                    //historyAns[i] = MCQSData.answersIndex[i];
                    HistoryAnsMcqs[i].Index = MCQSData.answersIndex[i].Split(',');
                    ////Debug.Log(ans[0]);

                    histOp1[i].answer = MCQSData.Op1[i];
                    histOp2[i].answer = MCQSData.Op2[i];
                    histOp3[i].answer = MCQSData.Op3[i];
                }
                break;
            case 1:
                for (int i = 0; i < 3; i++)
                {
                    historyQues[i] = MCQSData_Greek.questions[i];
                    //historyAns[i] = MCQSData.answersIndex[i];
                    HistoryAnsMcqs[i].Index = MCQSData_Greek.answersIndex[i].Split(',');
                    ////Debug.Log(ans[0]);

                    histOp1[i].answer = MCQSData_Greek.Op1[i];
                    histOp2[i].answer = MCQSData_Greek.Op2[i];
                    histOp3[i].answer = MCQSData_Greek.Op3[i];
                }
                break;
            case 2:
                for (int i = 0; i < 3; i++)
                {
                    historyQues[i] = MCQSData_Polish.questions[i];
                    //historyAns[i] = MCQSData.answersIndex[i];
                    HistoryAnsMcqs[i].Index = MCQSData_Polish.answersIndex[i].Split(',');
                    ////Debug.Log(ans[0]);

                    histOp1[i].answer = MCQSData_Polish.Op1[i];
                    histOp2[i].answer = MCQSData_Polish.Op2[i];
                    histOp3[i].answer = MCQSData_Polish.Op3[i];
                }
                break;
        }

    }


    #endregion

    #region Geography Quiz Data
    //*************** TRUE False *************//
    public void SetGeographyQuizData(int index)
    {
        //onclicks added or removed
        TickButton1.onClick.RemoveAllListeners();
        TickButton1.onClick.AddListener(() => AnswerBtnClick(geographyOptionTexts[0], TF_KEY, TickButton1));

        TickButton2.onClick.RemoveAllListeners();
        TickButton2.onClick.AddListener(() => AnswerBtnClick(geographyOptionTexts[1], TF_KEY, TickButton2));

        ResetButton.onClick.RemoveAllListeners();
        ResetButton.onClick.AddListener(() => ResetQuestionaPanel(TF_KEY));

        TickButton3.gameObject.SetActive(false);

        selectedCategory = index;
        SetGeographyOptionData();

        //int temp = geographyQuizIndex;

        //geographyQuizIndex = Random.Range(0, geographyQues.Length);

        //if (temp == geographyQuizIndex)
        //{
        //    geographyQuizIndex = Random.Range(0, geographyQues.Length);
        //}

        ////Debug.Log(geographyQuizIndex);

        geographyQuestonText.text = geographyQues[GData.BLgeographyQuizIndex];

        geographyOptionTexts[0].text = geogOp1[GData.BLgeographyQuizIndex].answer;
        geographyOptionTexts[1].text = geogOp2[GData.BLgeographyQuizIndex].answer;

        //setting style
        //SetTextStyle(geographyOptionTexts[0], geographyOptionTexts[1]);

        if (geographyAns[GData.BLgeographyQuizIndex] == 0)
        {
            geographyFinalAnswer = geogOp1[GData.BLgeographyQuizIndex].answer;
        }
        else if (geographyAns[GData.BLgeographyQuizIndex] == 1)
        {
            geographyFinalAnswer = geogOp2[GData.BLgeographyQuizIndex].answer;
        }

        //Debug.Log(geographyFinalAnswer);
    }

    private void SetGeographyOptionData()
    {
        for (int i = 0; i < 3; i++)
        {
            geographyQues = new string[3];
            geographyQues[i] = "";

            geographyAns = new int[3];
            geographyAns[i] = 0;
        }



        for (int i = 0; i < geogOp1.Length; i++)
        {
            geogOp1[i] = new Option();
        }
        for (int i = 0; i < geogOp2.Length; i++)
        {
            geogOp2[i] = new Option();
        }


        //for (int i = 0; i < 3; i++)
        //{
        //    geographyQues[i] = TFData.questions[i + 3];
        //    geographyAns[i] = TFData.answersIndex[i + 3];

        //    geogOp1[i].answer = TFData.Op1[i + 3];
        //    geogOp2[i].answer = TFData.Op2[i + 3];
        //}
        switch (GData.SelectedLanguage)
        {
            case 0:
                for (int i = 0; i < 3; i++)
                {
                    geographyQues[i] = TFData.questions[i];
                    geographyAns[i] = TFData.answersIndex[i];

                    geogOp1[i].answer = TFData.Op1[i];
                    geogOp2[i].answer = TFData.Op2[i];

                }
                break;
            case 1:
                for (int i = 0; i < 3; i++)
                {
                    geographyQues[i] = TFData_Greek.questions[i];
                    geographyAns[i] = TFData_Greek.answersIndex[i];

                    geogOp1[i].answer = TFData_Greek.Op1[i];
                    geogOp2[i].answer = TFData_Greek.Op2[i];

                }
                break;
            case 2:
                for (int i = 0; i < 3; i++)
                {
                    geographyQues[i] = TFData_Polish.questions[i];
                    geographyAns[i] = TFData_Polish.answersIndex[i];

                    geogOp1[i].answer = TFData_Polish.Op1[i];
                    geogOp2[i].answer = TFData_Polish.Op2[i];

                }
                break;
        }

    }

    //************* MCQS ********************//
    public void SetGeographyQuizDataMCQS(int index)
    {
        //onclicks added or removed
        TickButton1.onClick.RemoveAllListeners();
        TickButton1.onClick.AddListener(() => AnswerBtnClick(geographyOptionTexts[0], MCQS_KEY, TickButton1));

        TickButton2.onClick.RemoveAllListeners();
        TickButton2.onClick.AddListener(() => AnswerBtnClick(geographyOptionTexts[1], MCQS_KEY, TickButton2));

        TickButton3.onClick.RemoveAllListeners();
        TickButton3.onClick.AddListener(() => AnswerBtnClick(geographyOptionTexts[2], MCQS_KEY, TickButton3));

        ResetButton.onClick.RemoveAllListeners();
        ResetButton.onClick.AddListener(() => ResetQuestionaPanel(MCQS_KEY));

        TickButton3.gameObject.SetActive(true);

        selectedCategory = index;
        SetGeographyOptionDataMCQS();

        //int temp = geographyQuizIndex;

        //geographyQuizIndex = Random.Range(0, geographyQues.Length);

        //if (temp == geographyQuizIndex)
        //{
        //    geographyQuizIndex = Random.Range(0, geographyQues.Length);
        //}

        ////Debug.Log(geographyQuizIndex);

        geographyQuestonText.text = geographyQues[GData.BLgeographyQuizIndex];

        geographyOptionTexts[0].text = geogOp1[GData.BLgeographyQuizIndex].answer;
        geographyOptionTexts[1].text = geogOp2[GData.BLgeographyQuizIndex].answer;
        geographyOptionTexts[2].text = geogOp3[GData.BLgeographyQuizIndex].answer;

        for (int i = 0; i < geographyAnsMcqs[GData.BLgeographyQuizIndex].Index.Length; i++)
        {
            if (int.Parse(geographyAnsMcqs[GData.BLgeographyQuizIndex].Index[i]) == 0)
            {
                TickButton1.GetComponent<Answer>().iscorrect = true;
            }
            if (int.Parse(geographyAnsMcqs[GData.BLgeographyQuizIndex].Index[i]) == 1)
            {
                TickButton2.GetComponent<Answer>().iscorrect = true;
            }
            if (int.Parse(geographyAnsMcqs[GData.BLgeographyQuizIndex].Index[i]) == 2)
            {
                TickButton3.GetComponent<Answer>().iscorrect = true;
            }
        }

        //if (geographyAns[geographyQuizIndex] == 0)
        //{
        //    geographyFinalAnswer = geogOp1[geographyQuizIndex].answer;
        //}
        //else if (geographyAns[geographyQuizIndex] == 1)
        //{
        //    geographyFinalAnswer = geogOp2[geographyQuizIndex].answer;
        //}
        //else if (geographyAns[geographyQuizIndex] == 2)
        //{
        //    geographyFinalAnswer = geogOp3[geographyQuizIndex].answer;
        //}

        //Debug.Log(geographyFinalAnswer);
    }

    private void SetGeographyOptionDataMCQS()
    {
        for (int i = 0; i < 4; i++)
        {
            geographyQues = new string[4];
            geographyQues[i] = "";

            geographyAns = new int[4];
            geographyAns[i] = 0;
        }


        for (int i = 0; i < geogOp1.Length; i++)
        {
            geogOp1[i] = new Option();
        }
        for (int i = 0; i < geogOp2.Length; i++)
        {
            geogOp2[i] = new Option();
        }
        for (int i = 0; i < geogOp3.Length; i++)
        {
            geogOp3[i] = new Option();
        }
        for (int i = 0; i < geographyAnsMcqs.Length; i++)
        {
            geographyAnsMcqs[i] = new FindIndex();
        }


        //for (int i = 0; i < 3; i++)
        //{
        //    geographyQues[i] = MCQSData.questions[i + 3];
        //    //geographyAns[i] = MCQSData.answersIndex[i];
        //    geographyAnsMcqs[i].Index = MCQSData.answersIndex[i + 3].Split(',');

        //    geogOp1[i].answer = MCQSData.Op1[i + 3];
        //    geogOp2[i].answer = MCQSData.Op2[i + 3];
        //    geogOp3[i].answer = MCQSData.Op3[i + 3];
        //}
        switch (GData.SelectedLanguage)
        {
            case 0:
                for (int i = 0; i < 4; i++)
                {
                    geographyQues[i] = MCQSData.questions[i];
                    //geographyAns[i] = MCQSData.answersIndex[i];
                    geographyAnsMcqs[i].Index = MCQSData.answersIndex[i].Split(',');

                    geogOp1[i].answer = MCQSData.Op1[i];
                    geogOp2[i].answer = MCQSData.Op2[i];
                    geogOp3[i].answer = MCQSData.Op3[i];
                }
                break;
            case 1:
                for (int i = 0; i < 4; i++)
                {
                    geographyQues[i] = MCQSData_Greek.questions[i];
                    //geographyAns[i] = MCQSData.answersIndex[i];
                    geographyAnsMcqs[i].Index = MCQSData_Greek.answersIndex[i].Split(',');

                    geogOp1[i].answer = MCQSData_Greek.Op1[i];
                    geogOp2[i].answer = MCQSData_Greek.Op2[i];
                    geogOp3[i].answer = MCQSData_Greek.Op3[i];
                }
                break;
            case 2:
                for (int i = 0; i < 4; i++)
                {
                    geographyQues[i] = MCQSData_Polish.questions[i];
                    //geographyAns[i] = MCQSData.answersIndex[i];
                    geographyAnsMcqs[i].Index = MCQSData_Polish.answersIndex[i].Split(',');

                    geogOp1[i].answer = MCQSData_Polish.Op1[i];
                    geogOp2[i].answer = MCQSData_Polish.Op2[i];
                    geogOp3[i].answer = MCQSData_Polish.Op3[i];
                }
                break;
        }

    }

    #endregion

    #region Food Quiz Data
    //*************** TRUE False *************//
    public void SetFoodQuizData(int index) //used
    {
        //onclicks added or removed
        TickButton1.onClick.RemoveAllListeners();
        TickButton1.onClick.AddListener(() => AnswerBtnClick(foodOptionTexts[0], TF_KEY, TickButton1));

        TickButton2.onClick.RemoveAllListeners();
        TickButton2.onClick.AddListener(() => AnswerBtnClick(foodOptionTexts[1], TF_KEY, TickButton2));

        ResetButton.onClick.RemoveAllListeners();
        ResetButton.onClick.AddListener(() => ResetQuestionaPanel(TF_KEY));

        TickButton3.gameObject.SetActive(false);

        selectedCategory = index;
        SetFoodOptionData();

        //int temp = foodQuizIndex;

        //foodQuizIndex = Random.Range(0, foodQues.Length);

        //if (temp == foodQuizIndex)
        //{
        //    foodQuizIndex = Random.Range(0, foodQues.Length);
        //}

        ////Debug.Log(foodQuizIndex);

        foodQuestonText.text = foodQues[GData.BLfoodQuizIndex];

        foodOptionTexts[0].text = foodOp1[GData.BLfoodQuizIndex].answer;
        foodOptionTexts[1].text = foodOp2[GData.BLfoodQuizIndex].answer;

        //setting style
        //SetTextStyle(foodOptionTexts[0], foodOptionTexts[1]);


        if (foodAns[GData.BLfoodQuizIndex] == 0)
        {
            foodFinalAnswer = foodOp1[GData.BLfoodQuizIndex].answer;
        }
        else if (foodAns[GData.BLfoodQuizIndex] == 1)
        {
            foodFinalAnswer = foodOp2[GData.BLfoodQuizIndex].answer;
        }


        //Debug.Log(foodFinalAnswer);
    }

    private void SetFoodOptionData()
    {
        for (int i = 0; i < 6; i++)
        {
            foodQues = new string[6];
            foodQues[i] = "";

            foodAns = new int[6];
            foodAns[i] = 0;
        }


        for (int i = 0; i < foodOp1.Length; i++)
        {
            foodOp1[i] = new Option();
        }
        for (int i = 0; i < foodOp2.Length; i++)
        {
            foodOp2[i] = new Option();
        }

        //for (int i = 0; i < 3; i++)
        //{
        //    foodQues[i] = TFData.questions[i + 6];
        //    foodAns[i] = TFData.answersIndex[i + 6];

        //    foodOp1[i].answer = TFData.Op1[i + 6];
        //    foodOp2[i].answer = TFData.Op2[i + 6];
        //}
        switch (GData.SelectedLanguage)
        {
            case 0:
                for (int i = 0; i < 6; i++)
                {
                    foodQues[i] = TFData.questions[i + 6];
                    foodAns[i] = TFData.answersIndex[i + 6];

                    foodOp1[i].answer = TFData.Op1[i + 6];
                    foodOp2[i].answer = TFData.Op2[i + 6];
                }
                break;
            case 1:
                for (int i = 0; i < 6; i++)
                {
                    foodQues[i] = TFData_Greek.questions[i + 6];
                    foodAns[i] = TFData_Greek.answersIndex[i + 6];

                    foodOp1[i].answer = TFData_Greek.Op1[i + 6];
                    foodOp2[i].answer = TFData_Greek.Op2[i + 6];
                }
                break;
            case 2:
                for (int i = 0; i < 6; i++)
                {
                    foodQues[i] = TFData_Polish.questions[i + 6];
                    foodAns[i] = TFData_Polish.answersIndex[i + 6];

                    foodOp1[i].answer = TFData_Polish.Op1[i + 6];
                    foodOp2[i].answer = TFData_Polish.Op2[i + 6];
                }
                break;
        }

    }

    //************* MCQS ********************//

    public void SetFoodQuizDataMCQS(int index)
    {
        //onclicks added or removed
        TickButton1.onClick.RemoveAllListeners();
        TickButton1.onClick.AddListener(() => AnswerBtnClick(foodOptionTexts[0], MCQS_KEY, TickButton1));

        TickButton2.onClick.RemoveAllListeners();
        TickButton2.onClick.AddListener(() => AnswerBtnClick(foodOptionTexts[1], MCQS_KEY, TickButton2));


        TickButton3.onClick.RemoveAllListeners();
        TickButton3.onClick.AddListener(() => AnswerBtnClick(foodOptionTexts[2], MCQS_KEY, TickButton3));

        ResetButton.onClick.RemoveAllListeners();
        ResetButton.onClick.AddListener(() => ResetQuestionaPanel(MCQS_KEY));

        TickButton3.gameObject.SetActive(true);

        selectedCategory = index;
        SetFoodOptionDataMCQS();

        //int temp = foodQuizIndex;

        //foodQuizIndex = Random.Range(0, foodQues.Length);

        //if (temp == foodQuizIndex)
        //{
        //    foodQuizIndex = Random.Range(0, foodQues.Length);
        //}

        ////Debug.Log(foodQuizIndex);

        foodQuestonText.text = foodQues[GData.BLfoodQuizIndex];

        foodOptionTexts[0].text = foodOp1[GData.BLfoodQuizIndex].answer;
        foodOptionTexts[1].text = foodOp2[GData.BLfoodQuizIndex].answer;
        foodOptionTexts[2].text = foodOp3[GData.BLfoodQuizIndex].answer;

        for (int i = 0; i < foodAnsMcqs[GData.BLfoodQuizIndex].Index.Length; i++)
        {
            if (int.Parse(foodAnsMcqs[GData.BLfoodQuizIndex].Index[i]) == 0)
            {
                TickButton1.GetComponent<Answer>().iscorrect = true;
            }
            if (int.Parse(foodAnsMcqs[GData.BLfoodQuizIndex].Index[i]) == 1)
            {
                TickButton2.GetComponent<Answer>().iscorrect = true;
            }
            if (int.Parse(foodAnsMcqs[GData.BLfoodQuizIndex].Index[i]) == 2)
            {
                TickButton3.GetComponent<Answer>().iscorrect = true;
            }
        }


        //if (foodAns[foodQuizIndex] == 0)
        //{
        //    foodFinalAnswer = foodOp1[foodQuizIndex].answer;
        //}
        //else if (foodAns[foodQuizIndex] == 1)
        //{
        //    foodFinalAnswer = foodOp2[foodQuizIndex].answer;
        //}
        //else if (foodAns[foodQuizIndex] == 2)
        //{
        //    foodFinalAnswer = foodOp3[foodQuizIndex].answer;
        //}


        //Debug.Log(foodFinalAnswer);
    }

    private void SetFoodOptionDataMCQS()
    {
        for (int i = 0; i < 3; i++)
        {
            foodQues = new string[3];
            foodQues[i] = "";

            foodAns = new int[3];
            foodAns[i] = 0;
        }


        for (int i = 0; i < foodOp1.Length; i++)
        {
            foodOp1[i] = new Option();
        }
        for (int i = 0; i < foodOp2.Length; i++)
        {
            foodOp2[i] = new Option();
        }
        for (int i = 0; i < foodOp3.Length; i++)
        {
            foodOp3[i] = new Option();
        }
        for (int i = 0; i < foodAnsMcqs.Length; i++)
        {
            foodAnsMcqs[i] = new FindIndex();
        }


        //for (int i = 0; i < 3; i++)
        //{
        //    foodQues[i] = MCQSData.questions[i + 5];
        //    //foodAns[i] = MCQSData.answersIndex[i];

        //    foodAnsMcqs[i].Index = MCQSData.answersIndex[i + 5].Split(',');

        //    foodOp1[i].answer = MCQSData.Op1[i + 5];
        //    foodOp2[i].answer = MCQSData.Op2[i + 5];
        //    foodOp3[i].answer = MCQSData.Op3[i + 5];
        //}
        switch (GData.SelectedLanguage)
        {
            case 0:
                for (int i = 0; i < 3; i++)
                {
                    foodQues[i] = MCQSData.questions[i + 5];
                    //foodAns[i] = MCQSData.answersIndex[i];

                    foodAnsMcqs[i].Index = MCQSData.answersIndex[i + 5].Split(',');

                    foodOp1[i].answer = MCQSData.Op1[i + 5];
                    foodOp2[i].answer = MCQSData.Op2[i + 5];
                    foodOp3[i].answer = MCQSData.Op3[i + 5];
                }
                break;
            case 1:
                for (int i = 0; i < 3; i++)
                {
                    foodQues[i] = MCQSData_Greek.questions[i + 5];
                    //foodAns[i] = MCQSData.answersIndex[i];

                    foodAnsMcqs[i].Index = MCQSData_Greek.answersIndex[i + 5].Split(',');

                    foodOp1[i].answer = MCQSData_Greek.Op1[i + 5];
                    foodOp2[i].answer = MCQSData_Greek.Op2[i + 5];
                    foodOp3[i].answer = MCQSData_Greek.Op3[i + 5];
                }
                break;
            case 2:
                for (int i = 0; i < 3; i++)
                {
                    foodQues[i] = MCQSData_Polish.questions[i + 5];
                    //foodAns[i] = MCQSData.answersIndex[i];

                    foodAnsMcqs[i].Index = MCQSData_Polish.answersIndex[i + 5].Split(',');

                    foodOp1[i].answer = MCQSData_Polish.Op1[i + 5];
                    foodOp2[i].answer = MCQSData_Polish.Op2[i + 5];
                    foodOp3[i].answer = MCQSData_Polish.Op3[i + 5];
                }
                break;
        }

    }

    #endregion

    #region Culture Quiz Data
    //*************** TRUE False *************//
    public void SetCultureQuizData(int index)
    {
        //onclicks added or removed
        TickButton1.onClick.RemoveAllListeners();
        TickButton1.onClick.AddListener(() => AnswerBtnClick(cultureOptionTexts[0], TF_KEY, TickButton1));

        TickButton2.onClick.RemoveAllListeners();
        TickButton2.onClick.AddListener(() => AnswerBtnClick(cultureOptionTexts[1], TF_KEY, TickButton2));

        ResetButton.onClick.RemoveAllListeners();
        ResetButton.onClick.AddListener(() => ResetQuestionaPanel(TF_KEY));

        TickButton3.gameObject.SetActive(false);

        selectedCategory = index;
        SetCultureOptionData();
        //int temp = cultureQuizIndex;

        //cultureQuizIndex = Random.Range(0, cultureQues.Length);

        //if (temp == cultureQuizIndex)
        //{
        //    cultureQuizIndex = Random.Range(0, cultureQues.Length);
        //}

        ////Debug.Log(cultureQuizIndex);

        cultureQuestonText.text = cultureQues[GData.BLcultureQuizIndex];

        cultureOptionTexts[0].text = culOp1[GData.BLcultureQuizIndex].answer;
        cultureOptionTexts[1].text = culOp2[GData.BLcultureQuizIndex].answer;

        //setting style
        //SetTextStyle(cultureOptionTexts[0], cultureOptionTexts[1]);


        if (cultureAns[GData.BLcultureQuizIndex] == 0)
        {
            cultureFinalAnswer = culOp1[GData.BLcultureQuizIndex].answer;
        }
        else if (cultureAns[GData.BLcultureQuizIndex] == 1)
        {
            cultureFinalAnswer = culOp2[GData.BLcultureQuizIndex].answer;
        }

        //Debug.Log(cultureFinalAnswer);
    }

    private void SetCultureOptionData()
    {
        for (int i = 0; i < 3; i++)
        {
            cultureQues = new string[3];
            cultureQues[i] = "";

            cultureAns = new int[3];
            cultureAns[i] = 0;
        }


        for (int i = 0; i < culOp1.Length; i++)
        {
            culOp1[i] = new Option();
        }
        for (int i = 0; i < culOp2.Length; i++)
        {
            culOp2[i] = new Option();
        }

        //for (int i = 0; i < 3; i++)
        //{
        //    cultureQues[i] = TFData.questions[i + 9];
        //    cultureAns[i] = TFData.answersIndex[i + 9];

        //    culOp1[i].answer = TFData.Op1[i + 9];
        //    culOp2[i].answer = TFData.Op2[i + 9];
        //}
        switch (GData.SelectedLanguage)
        {
            case 0:
                for (int i = 0; i < 3; i++)
                {
                    cultureQues[i] = TFData.questions[i + 9];
                    cultureAns[i] = TFData.answersIndex[i + 9];

                    culOp1[i].answer = TFData.Op1[i + 9];
                    culOp2[i].answer = TFData.Op2[i + 9];
                }
                break;
            case 1:
                for (int i = 0; i < 3; i++)
                {
                    cultureQues[i] = TFData_Greek.questions[i + 9];
                    cultureAns[i] = TFData_Greek.answersIndex[i + 9];

                    culOp1[i].answer = TFData_Greek.Op1[i + 9];
                    culOp2[i].answer = TFData_Greek.Op2[i + 9];
                }
                break;
            case 2:
                for (int i = 0; i < 3; i++)
                {
                    cultureQues[i] = TFData_Polish.questions[i + 9];
                    cultureAns[i] = TFData_Polish.answersIndex[i + 9];

                    culOp1[i].answer = TFData_Polish.Op1[i + 9];
                    culOp2[i].answer = TFData_Polish.Op2[i + 9];
                }
                break;
        }
    }

    //************* MCQS ********************//
    public void SetCultureQuizDataMCQS(int index)//Used
    {
        //onclicks added or removed
        TickButton1.onClick.RemoveAllListeners();
        TickButton1.onClick.AddListener(() => AnswerBtnClick(cultureOptionTexts[0], MCQS_KEY, TickButton1));

        TickButton2.onClick.RemoveAllListeners();
        TickButton2.onClick.AddListener(() => AnswerBtnClick(cultureOptionTexts[1], MCQS_KEY, TickButton2));


        TickButton3.onClick.RemoveAllListeners();
        TickButton3.onClick.AddListener(() => AnswerBtnClick(cultureOptionTexts[2], MCQS_KEY, TickButton3));

        ResetButton.onClick.RemoveAllListeners();
        ResetButton.onClick.AddListener(() => ResetQuestionaPanel(MCQS_KEY));

        TickButton3.gameObject.SetActive(true);

        selectedCategory = index;
        SetCultureOptionDataMCQS();
        //int temp = cultureQuizIndex;

        //cultureQuizIndex = Random.Range(0, cultureQues.Length);

        //if (temp == cultureQuizIndex)
        //{
        //    cultureQuizIndex = Random.Range(0, cultureQues.Length);
        //}

        ////Debug.Log(cultureQuizIndex);

        cultureQuestonText.text = cultureQues[GData.BLcultureQuizIndex];

        cultureOptionTexts[0].text = culOp1[GData.BLcultureQuizIndex].answer;
        cultureOptionTexts[1].text = culOp2[GData.BLcultureQuizIndex].answer;
        cultureOptionTexts[2].text = culOp3[GData.BLcultureQuizIndex].answer;


        for (int i = 0; i < cultureAnsMcqs[GData.BLcultureQuizIndex].Index.Length; i++)
        {
            if (int.Parse(cultureAnsMcqs[GData.BLcultureQuizIndex].Index[i]) == 0)
            {
                TickButton1.GetComponent<Answer>().iscorrect = true;
            }
            if (int.Parse(cultureAnsMcqs[GData.BLcultureQuizIndex].Index[i]) == 1)
            {
                TickButton2.GetComponent<Answer>().iscorrect = true;
            }
            if (int.Parse(cultureAnsMcqs[GData.BLcultureQuizIndex].Index[i]) == 2)
            {
                TickButton3.GetComponent<Answer>().iscorrect = true;
            }
        }

        //if (cultureAns[cultureQuizIndex] == 0)
        //{
        //    cultureFinalAnswer = culOp1[cultureQuizIndex].answer;
        //}
        //else if (cultureAns[cultureQuizIndex] == 1)
        //{
        //    cultureFinalAnswer = culOp2[cultureQuizIndex].answer;
        //}
        //else if (cultureAns[cultureQuizIndex] == 2)
        //{
        //    cultureFinalAnswer = culOp3[cultureQuizIndex].answer;
        //}

        //Debug.Log(cultureFinalAnswer);
    }

    private void SetCultureOptionDataMCQS()
    {
        for (int i = 0; i < 4; i++)
        {
            cultureQues = new string[4];
            cultureQues[i] = "";

            cultureAns = new int[4];
            cultureAns[i] = 0;
        }


        for (int i = 0; i < culOp1.Length; i++)
        {
            culOp1[i] = new Option();
        }
        for (int i = 0; i < culOp2.Length; i++)
        {
            culOp2[i] = new Option();
        }
        for (int i = 0; i < culOp3.Length; i++)
        {
            culOp3[i] = new Option();
        }
        for (int i = 0; i < cultureAnsMcqs.Length; i++)
        {
            cultureAnsMcqs[i] = new FindIndex();
        }
        switch (GData.SelectedLanguage)
        {
            case 0:
                for (int i = 0; i < 4; i++)
                {
                    cultureQues[i] = MCQSData.questions[i + 4];
                    cultureAnsMcqs[i].Index = MCQSData.answersIndex[i + 4].Split(',');
                    culOp1[i].answer = MCQSData.Op1[i + 4];
                    culOp2[i].answer = MCQSData.Op2[i + 4];
                    culOp3[i].answer = MCQSData.Op3[i + 4];
                }
                break;
            case 1:
                for (int i = 0; i < 4; i++)
                {
                    cultureQues[i] = MCQSData_Greek.questions[i + 4];
                    cultureAnsMcqs[i].Index = MCQSData_Greek.answersIndex[i + 4].Split(',');
                    culOp1[i].answer = MCQSData_Greek.Op1[i + 4];
                    culOp2[i].answer = MCQSData_Greek.Op2[i + 4];
                    culOp3[i].answer = MCQSData_Greek.Op3[i + 4];
                }
                break;
            case 2:
                for (int i = 0; i < 4; i++)
                {
                    cultureQues[i] = MCQSData_Polish.questions[i + 4];
                    //cultureAns[i] = MCQSData.answersIndex[i];

                    cultureAnsMcqs[i].Index = MCQSData_Polish.answersIndex[i + 4].Split(',');

                    culOp1[i].answer = MCQSData_Polish.Op1[i + 4];
                    culOp2[i].answer = MCQSData_Polish.Op2[i + 4];
                    culOp3[i].answer = MCQSData_Polish.Op3[i + 4];
                }
                break;
        }
    }

    #endregion


    #region Common Functions


    public class Option
    {
        public string answer;
        public string tag;
    }

    private void SetTextStyle(Text text1, Text text2)
    {
        //increase fonts
        text1.fontSize = 50;
        text2.fontSize = 50;
        //set fontstyle
        text1.fontStyle = FontStyle.Bold;
        text2.fontStyle = FontStyle.Bold;

    }

    public void RemoveTextStyleFunc()
    {
        historyOptionTexts[0].fontSize = 40;
        historyOptionTexts[1].fontSize = 40;
        historyOptionTexts[2].fontSize = 40;
        historyOptionTexts[3].fontSize = 40;

        historyOptionTexts[0].fontStyle = FontStyle.Bold;
        historyOptionTexts[1].fontStyle = FontStyle.Bold;
        historyOptionTexts[2].fontStyle = FontStyle.Bold;
        historyOptionTexts[3].fontStyle = FontStyle.Bold;
    }

    public void ResetQuestionaPanel(string Category)
    {
        OptionButtonHandle(true);
        if (Category.Equals(TF_KEY))
        {
            if (PlayerPrefs.GetInt("levelcurrent") == 2)
            {
                if (!GameManager.Instance.IsMulti)
                {
                    if (selectedCategory == 1 && PlayerPrefs.GetInt("BelgiumHist", 0) < 3)
                    {
                        SetHistoryQuizData(1);
                        levelFailPanel.SetActive(false);
                        quizPanel.SetActive(true);
                    }
                    else if (selectedCategory == 2 && PlayerPrefs.GetInt("BelgiumGeo", 0) < 3)
                    {
                        SetGeographyQuizData(2);
                        levelFailPanel.SetActive(false);
                        quizPanel.SetActive(true);
                    }
                    else if (selectedCategory == 3 && PlayerPrefs.GetInt("BelgiumFood", 0) < 3)
                    {
                        SetFoodQuizData(3);
                        levelFailPanel.SetActive(false);
                        quizPanel.SetActive(true);
                    }
                    else if (selectedCategory == 4 && PlayerPrefs.GetInt("BelgiumCult", 0) < 3)
                    {
                        SetCultureQuizData(4);
                        levelFailPanel.SetActive(false);
                        quizPanel.SetActive(true);
                    }
                    else
                    {
                        levelFailPanel.SetActive(false);
                        cameraobj.SetActive(false);
                        Background.SetActive(false);
                        controller.SetActive(true);
                        countDown.timeRemaining = GData.GameTime;
                        CountDown.timerIsRunning = true;
                        PlayerPrefs.SetFloat("TimeRemaining", countDown.timeRemaining);
                        PlayerPrefs.Save();
                    }
                }
                else
                {
                    if (selectedCategory == 1 && GData.Room[1].HisQ[0].AnswerGiven < 3)
                    {
                        SetHistoryQuizData(1);
                        levelFailPanel.SetActive(false);
                        quizPanel.SetActive(true);
                    }
                    else if (selectedCategory == 2 && GData.Room[1].GeoQ[0].AnswerGiven < 3)
                    {
                        SetGeographyQuizData(2);
                        levelFailPanel.SetActive(false);
                        quizPanel.SetActive(true);
                    }
                    else if (selectedCategory == 3 && GData.Room[1].FoodQ[0].AnswerGiven < 3)
                    {
                        SetFoodQuizData(3);
                        levelFailPanel.SetActive(false);
                        quizPanel.SetActive(true);
                    }
                    else if (selectedCategory == 4 && GData.Room[1].CulQ[0].AnswerGiven < 3)
                    {
                        SetCultureQuizData(4);
                        levelFailPanel.SetActive(false);
                        quizPanel.SetActive(true);
                    }
                    else
                    {
                        levelFailPanel.SetActive(false);
                        cameraobj.SetActive(false);
                        Background.SetActive(false);
                        controller.SetActive(true);
                        countDown.timeRemaining = GData.GameTime;
                        CountDown.timerIsRunning = true;
                        PlayerPrefs.SetFloat("TimeRemaining", countDown.timeRemaining);
                        PlayerPrefs.Save();
                    }
                }

            }
        }
        else if (Category.Equals(MCQS_KEY))
        {
            //Debug.Log("enter");
            if (PlayerPrefs.GetInt("levelcurrent") == 2)
            {
                if (!GameManager.Instance.IsMulti)
                {
                    if (selectedCategory == 1 && PlayerPrefs.GetInt("BelgiumHist", 0) < 3)
                    {
                        //Debug.Log(selectedCategory + "cate1");
                        SetHistoryQuizDataMCQS(1);
                        levelFailPanel.SetActive(false);
                        quizPanel.SetActive(true);
                    }
                    else if (selectedCategory == 2 && PlayerPrefs.GetInt("BelgiumGeo", 0) < 3)
                    {
                        //Debug.Log(selectedCategory + "cate2");
                        SetGeographyQuizDataMCQS(2);
                        levelFailPanel.SetActive(false);
                        quizPanel.SetActive(true);
                    }
                    else if (selectedCategory == 3 && PlayerPrefs.GetInt("BelgiumFood", 0) < 3)
                    {
                        //Debug.Log(selectedCategory + "cate3");
                        SetFoodQuizDataMCQS(3);
                        levelFailPanel.SetActive(false);
                        quizPanel.SetActive(true);
                    }
                    else if (selectedCategory == 4 && PlayerPrefs.GetInt("BelgiumCult", 0) < 3)
                    {
                        //Debug.Log(selectedCategory + "cate4");
                        SetCultureQuizDataMCQS(4);
                        levelFailPanel.SetActive(false);
                        quizPanel.SetActive(true);
                    }
                    else
                    {
                        levelFailPanel.SetActive(false);
                        cameraobj.SetActive(false);
                        Background.SetActive(false);
                        controller.SetActive(true);
                        countDown.timeRemaining = GData.GameTime;
                        CountDown.timerIsRunning = true;
                        PlayerPrefs.SetFloat("TimeRemaining", countDown.timeRemaining);
                        PlayerPrefs.Save();
                    }
                }
                else
                {
                    if (selectedCategory == 1 && GData.Room[1].HisQ[0].AnswerGiven < 3)
                    {
                        //Debug.Log(selectedCategory + "cate1");
                        SetHistoryQuizDataMCQS(1);
                        levelFailPanel.SetActive(false);
                        quizPanel.SetActive(true);
                    }
                    else if (selectedCategory == 2 && GData.Room[1].GeoQ[0].AnswerGiven < 3)
                    {
                        //Debug.Log(selectedCategory + "cate2");
                        SetGeographyQuizDataMCQS(2);
                        levelFailPanel.SetActive(false);
                        quizPanel.SetActive(true);
                    }
                    else if (selectedCategory == 3 && GData.Room[1].FoodQ[0].AnswerGiven < 3)
                    {
                        //Debug.Log(selectedCategory + "cate3");
                        SetFoodQuizDataMCQS(3);
                        levelFailPanel.SetActive(false);
                        quizPanel.SetActive(true);
                    }
                    else if (selectedCategory == 4 && GData.Room[1].CulQ[0].AnswerGiven < 3)
                    {
                        //Debug.Log(selectedCategory + "cate4");
                        SetCultureQuizDataMCQS(4);
                        levelFailPanel.SetActive(false);
                        quizPanel.SetActive(true);
                    }
                    else
                    {
                        levelFailPanel.SetActive(false);
                        cameraobj.SetActive(false);
                        Background.SetActive(false);
                        controller.SetActive(true);
                        countDown.timeRemaining = GData.GameTime;
                        CountDown.timerIsRunning = true;
                        PlayerPrefs.SetFloat("TimeRemaining", countDown.timeRemaining);
                        PlayerPrefs.Save();
                    }
                }

            }
        }

    }  //Complete

    private void OptionButtonHandle(bool Status)
    {
        TickButton1.interactable = Status;
        TickButton2.interactable = Status;
        TickButton3.interactable = Status;
    }
    public void AnswerBtnClick(Text text, string Category, Button btn)
    {
        OptionButtonHandle(false);
        if (Category.Equals(TF_KEY))
        {
            if (PlayerPrefs.GetInt("levelcurrent") == 2)
            {
                if (selectedCategory == 1)
                {
                    GData.BLhistoryQuizIndex = (GData.BLhistoryQuizIndex + 1) % historyQues.Length;
                    PersistentDataManager.instance.SaveData();
                    //Debug.Log("Came 2");

                    if (text.text.Equals(historyFinalAnswer) == true)
                    {
                        RightAnswerHandler(TF_KEY);
                    }
                    else
                    {
                        WrongAnswerHandler(TF_KEY);
                    }
                }
                else if (selectedCategory == 2)
                {
                    GData.BLgeographyQuizIndex = (GData.BLgeographyQuizIndex + 1) % geographyQues.Length;
                    PersistentDataManager.instance.SaveData();
                    //Debug.Log("Came 3");

                    if (text.text.Equals(geographyFinalAnswer) == true)
                    {
                        RightAnswerHandler(TF_KEY);
                    }
                    else
                    {
                        WrongAnswerHandler(TF_KEY);
                    }
                }
                else if (selectedCategory == 3)
                {
                    GData.BLfoodQuizIndex = (GData.BLfoodQuizIndex + 1) % foodQues.Length;
                    PersistentDataManager.instance.SaveData();
                    //Debug.Log("Came 4");

                    if (text.text.Equals(foodFinalAnswer) == true)
                    {
                        RightAnswerHandler(TF_KEY);
                    }
                    else
                    {
                        WrongAnswerHandler(TF_KEY);
                    }
                }
                else if (selectedCategory == 4)
                {
                    GData.BLcultureQuizIndex = (GData.BLcultureQuizIndex + 1) % cultureQues.Length;
                    PersistentDataManager.instance.SaveData();
                    //Debug.Log("Came 5");

                    if (text.text.Equals(cultureFinalAnswer) == true)
                    {
                        RightAnswerHandler(TF_KEY);
                    }
                    else
                    {
                        WrongAnswerHandler(TF_KEY);
                    }
                }
            }
        }
        else if (Category.Equals(MCQS_KEY))
        {
            if (PlayerPrefs.GetInt("levelcurrent") == 2)
            {
                if (selectedCategory == 1)
                {
                    //Debug.Log("Came 2");
                    GData.BLhistoryQuizIndex = (GData.BLhistoryQuizIndex + 1) % historyQues.Length;
                    PersistentDataManager.instance.SaveData();
                    if (btn.GetComponent<Answer>().iscorrect == true)
                    {
                        RightAnswerHandler(MCQS_KEY);
                    }
                    else
                    {
                        WrongAnswerHandler(MCQS_KEY);
                    }
                }
                else if (selectedCategory == 2)
                {
                    GData.BLgeographyQuizIndex = (GData.BLgeographyQuizIndex + 1) % geographyQues.Length;
                    PersistentDataManager.instance.SaveData();
                    //Debug.Log("Came 3");

                    if (btn.GetComponent<Answer>().iscorrect == true)
                    {
                        RightAnswerHandler(MCQS_KEY);
                    }
                    else
                    {
                        WrongAnswerHandler(MCQS_KEY);
                    }
                }
                else if (selectedCategory == 3)
                {
                    GData.BLfoodQuizIndex = (GData.BLfoodQuizIndex + 1) % foodQues.Length;
                    PersistentDataManager.instance.SaveData();
                    //Debug.Log("Came 4");

                    if (btn.GetComponent<Answer>().iscorrect == true)
                    {
                        RightAnswerHandler(MCQS_KEY);
                    }
                    else
                    {
                        WrongAnswerHandler(MCQS_KEY);
                    }
                }
                else if (selectedCategory == 4)
                {
                    GData.BLcultureQuizIndex = (GData.BLcultureQuizIndex + 1) % cultureQues.Length;
                    PersistentDataManager.instance.SaveData();
                    //Debug.Log("Came 5");

                    if (btn.GetComponent<Answer>().iscorrect == true)
                    {
                        RightAnswerHandler(MCQS_KEY);
                    }
                    else
                    {
                        WrongAnswerHandler(MCQS_KEY);
                    }
                }
            }
        }
    }
    public void RightAnswerHandler(string Categry)
    {
        CorrectAnswerText.gameObject.SetActive(true);
        Confetti1.gameObject.SetActive(true);
        Confetti2.gameObject.SetActive(true);
        Confetti1.Play();
        Confetti2.Play();
        StartCoroutine(CorrectAnswerWait(Categry));
        if (GameManager.Instance.IsMulti)
        {
            GData.Player[GameManager.Instance.SelectedPlayer].RightAnswer++;
            PersistentDataManager.instance.SaveData();
        }
        else
        {
            //PlayerPrefs.SetInt("BMscore", PlayerPrefs.GetInt("BMscore") + 5);
        }
    }
    public void WrongAnswerHandler(string Categry)
    {
        WrongAnswerText.gameObject.SetActive(true);

        StartCoroutine(WrongAnswerwait(Categry));

        if (GameManager.Instance.IsMulti)
        {
            StartCoroutine(CorrectAnswerWait(Categry));
            GData.Player[GameManager.Instance.SelectedPlayer].WrongAnswer++;
            PersistentDataManager.instance.SaveData();
        }
    }
    IEnumerator CorrectAnswerWait(string Category)
    {
        yield return new WaitForSeconds(1f);
        Confetti1.gameObject.SetActive(false);
        Confetti2.gameObject.SetActive(false);
        CorrectAnswerText.gameObject.SetActive(false);
        WrongAnswerText.gameObject.SetActive(false);

        if (Category.Equals(TF_KEY))
        {
            if (!GameManager.Instance.IsMulti)
            {
                if (selectedCategory == 1)
                {
                    if (PlayerPrefs.GetInt("BelgiumHist", 0) < 3)
                    {
                        PlayerPrefs.SetInt("BelgiumHist", (PlayerPrefs.GetInt("BelgiumHist")) + 1);
                        PlayerPrefs.SetInt("BMscore", PlayerPrefs.GetInt("BMscore") + 5);
                        PlayerPrefs.Save();
                        if (PlayerPrefs.GetInt("BelgiumHist", 0) < 3)
                        {
                            SetHistoryQuizData(1);
                        }
                        else if (PlayerPrefs.GetInt("BelgiumHist", 0) == 3)
                        {
                            PlayerPrefs.SetInt("Level2", PlayerPrefs.GetInt("Level2") + 1);
                            PlayerPrefs.Save();
                            quizHist.interactable = false;
                            quizPanel.SetActive(false);
                            levelCompletePanel.SetActive(true);
                            LevelCompleteText.text = PlayerPrefs.GetInt("BMscore").ToString();
                            Background.SetActive(true);
                            ReadQuestion.interactable = false;
                            GData.OffRoom[GData.SelectedRoom].RoomObj[selectedCategory - 1].IsComplete = true;
                            PersistentDataManager.instance.SaveData();

                        }
                    }
                    //else if (PlayerPrefs.GetInt("BelgiumHist", 0) == 3 && !historyCompleteImage.activeInHierarchy)
                    //{
                    //    PlayerPrefs.SetInt("Level2", (PlayerPrefs.GetInt("Level2")) + 1);
                    //    PlayerPrefs.Save();

                    //    //quizHist.interactable = false;
                    //    quizPanel.SetActive(false);
                    //    levelCompletePanel.SetActive(true);
                    //    LevelCompleteText.text = PlayerPrefs.GetInt("BMscore").ToString();
                    //    Background.SetActive(true);

                    //}
                    //else if (PlayerPrefs.GetInt("BelgiumHist", 0) == 3 && historyCompleteImage.activeInHierarchy)
                    //{
                    //    quizPanel.SetActive(false);
                    //    levelCompletePanel.SetActive(true);
                    //    LevelCompleteText.text = PlayerPrefs.GetInt("BMscore").ToString();
                    //    Background.SetActive(true);
                    //}
                }
                else if (selectedCategory == 2)
                {
                    if (PlayerPrefs.GetInt("BelgiumGeo", 0) < 3)
                    {
                        PlayerPrefs.SetInt("BelgiumGeo", (PlayerPrefs.GetInt("BelgiumGeo")) + 1);
                        PlayerPrefs.SetInt("BMscore", PlayerPrefs.GetInt("BMscore") + 5);
                        PlayerPrefs.Save();

                        if (PlayerPrefs.GetInt("BelgiumGeo", 0) < 3)
                        {
                            SetGeographyQuizData(2);
                        }
                        else if (PlayerPrefs.GetInt("BelgiumGeo", 0) == 3)
                        {
                            PlayerPrefs.SetInt("Level2", (PlayerPrefs.GetInt("Level2")) + 1);
                            PlayerPrefs.Save();

                            quizGeo.interactable = false;

                            quizPanel.SetActive(false);
                            levelCompletePanel.SetActive(true);
                            LevelCompleteText.text = PlayerPrefs.GetInt("BMscore").ToString();
                            Background.SetActive(true);
                            ReadQuestion.interactable = false;
                            GData.OffRoom[GData.SelectedRoom].RoomObj[selectedCategory - 1].IsComplete = true;
                            PersistentDataManager.instance.SaveData();

                        }
                    }
                    //else if (PlayerPrefs.GetInt("BelgiumGeo", 0) == 3 && !geographyCompleteImage.activeInHierarchy)
                    //{
                    //    PlayerPrefs.SetInt("Level2", (PlayerPrefs.GetInt("Level2")) + 1);
                    //    PlayerPrefs.Save();

                    //    //quizGeo.interactable = false;

                    //    quizPanel.SetActive(false);
                    //    levelCompletePanel.SetActive(true);
                    //    LevelCompleteText.text = PlayerPrefs.GetInt("BMscore").ToString();
                    //    Background.SetActive(true);

                    //}
                    //else if (PlayerPrefs.GetInt("BelgiumGeo", 0) == 3 && geographyCompleteImage.activeInHierarchy)
                    //{
                    //    quizPanel.SetActive(false);
                    //    levelCompletePanel.SetActive(true);
                    //    LevelCompleteText.text = PlayerPrefs.GetInt("BMscore").ToString();
                    //    Background.SetActive(true);

                    //}
                }
                else if (selectedCategory == 3)
                {
                    if (PlayerPrefs.GetInt("BelgiumFood", 0) < 3)
                    {
                        PlayerPrefs.SetInt("BelgiumFood", (PlayerPrefs.GetInt("BelgiumFood")) + 1);
                        PlayerPrefs.SetInt("BMscore", PlayerPrefs.GetInt("BMscore") + 5);
                        PlayerPrefs.Save();

                        if (PlayerPrefs.GetInt("BelgiumFood", 0) < 3)
                        {
                            SetFoodQuizData(3);
                        }
                        else if (PlayerPrefs.GetInt("BelgiumFood", 0) == 3)
                        {
                            PlayerPrefs.SetInt("Level2", (PlayerPrefs.GetInt("Level2")) + 1);
                            PlayerPrefs.Save();

                            quizFood.interactable = false;

                            quizPanel.SetActive(false);
                            levelCompletePanel.SetActive(true);
                            LevelCompleteText.text = PlayerPrefs.GetInt("BMscore").ToString();
                            Background.SetActive(true);
                            ReadQuestion.interactable = false;
                            GData.OffRoom[GData.SelectedRoom].RoomObj[selectedCategory - 1].IsComplete = true;
                            PersistentDataManager.instance.SaveData();
                        }
                    }
                    //else if (PlayerPrefs.GetInt("BelgiumFood", 0) == 3 && !foodCompleteImage.activeInHierarchy)
                    //{
                    //    PlayerPrefs.SetInt("Level2", (PlayerPrefs.GetInt("Level2")) + 1);
                    //    PlayerPrefs.Save();

                    //    //quizFood.interactable = false;

                    //    quizPanel.SetActive(false);
                    //    levelCompletePanel.SetActive(true);
                    //    LevelCompleteText.text = PlayerPrefs.GetInt("BMscore").ToString();
                    //    Background.SetActive(true);
                    //}
                    //else if (PlayerPrefs.GetInt("BelgiumFood", 0) == 3 && foodCompleteImage.activeInHierarchy)
                    //{
                    //    quizPanel.SetActive(false);
                    //    levelCompletePanel.SetActive(true);
                    //    LevelCompleteText.text = PlayerPrefs.GetInt("BMscore").ToString();
                    //    Background.SetActive(true);
                    //}
                }
                else if (selectedCategory == 4)
                {
                    if (PlayerPrefs.GetInt("BelgiumCult", 0) < 3)
                    {
                        PlayerPrefs.SetInt("BelgiumCult", (PlayerPrefs.GetInt("BelgiumCult")) + 1);
                        PlayerPrefs.SetInt("BMscore", PlayerPrefs.GetInt("BMscore") + 5);
                        PlayerPrefs.Save();

                        if (PlayerPrefs.GetInt("BelgiumCult", 0) < 3)
                        {
                            SetCultureQuizData(4);
                        }
                        else if (PlayerPrefs.GetInt("BelgiumCult", 0) == 3)
                        {
                            PlayerPrefs.SetInt("Level2", (PlayerPrefs.GetInt("Level2")) + 1);
                            PlayerPrefs.Save();

                            quizCult.interactable = false;

                            quizPanel.SetActive(false);
                            levelCompletePanel.SetActive(true);
                            LevelCompleteText.text = PlayerPrefs.GetInt("BMscore").ToString();
                            Background.SetActive(true);
                            ReadQuestion.interactable = false;
                            GData.OffRoom[GData.SelectedRoom].RoomObj[selectedCategory - 1].IsComplete = true;
                            PersistentDataManager.instance.SaveData();
                        }
                    }
                    //else if (PlayerPrefs.GetInt("BelgiumCult", 0) == 3 && !cultureCompleteImage.activeInHierarchy)
                    //{
                    //    PlayerPrefs.SetInt("Level2", (PlayerPrefs.GetInt("Level2")) + 1);
                    //    PlayerPrefs.Save();

                    //    //quizCult.interactable = false;

                    //    quizPanel.SetActive(false);
                    //    levelCompletePanel.SetActive(true);
                    //    LevelCompleteText.text = PlayerPrefs.GetInt("BMscore").ToString();
                    //    Background.SetActive(true);
                    //}
                    //else if (PlayerPrefs.GetInt("BelgiumCult", 0) == 3 && cultureCompleteImage.activeInHierarchy)
                    //{
                    //    quizPanel.SetActive(false);
                    //    levelCompletePanel.SetActive(true);
                    //    LevelCompleteText.text = PlayerPrefs.GetInt("BMscore").ToString();
                    //    Background.SetActive(true);
                    //}
                }
            }
            else
            {
                if (selectedCategory == 1)
                {
                    if (GData.Room[1].HisQ[0].AnswerGiven < 3)
                    {
                        GData.Room[1].HisQ[0].AnswerGiven++;
                        PersistentDataManager.instance.SaveData();
                        if (GData.Room[1].HisQ[0].AnswerGiven < 3)
                        {
                            SetHistoryQuizData(1);
                        }
                        else if (GData.Room[1].HisQ[0].AnswerGiven == 3)
                        {
                            ReadQuestion.interactable = false;
                            OnMultiplayerObjComplete();
                        }
                    }
                }
                else if (selectedCategory == 2)
                {
                    if (GData.Room[1].GeoQ[0].AnswerGiven < 3)
                    {
                        GData.Room[1].GeoQ[0].AnswerGiven++;
                        PersistentDataManager.instance.SaveData();

                        if (GData.Room[1].GeoQ[0].AnswerGiven < 3)
                        {
                            SetGeographyQuizData(2);
                        }
                        else if (GData.Room[1].GeoQ[0].AnswerGiven == 3)
                        {
                            ReadQuestion.interactable = false;
                            OnMultiplayerObjComplete();
                        }
                    }
                }
                else if (selectedCategory == 3)
                {
                    if (GData.Room[1].FoodQ[0].AnswerGiven < 3)
                    {
                        GData.Room[1].FoodQ[0].AnswerGiven++;
                        PersistentDataManager.instance.SaveData();

                        if (GData.Room[1].FoodQ[0].AnswerGiven < 3)
                        {
                            SetFoodQuizData(3);
                        }
                        else if (GData.Room[1].FoodQ[0].AnswerGiven == 3)
                        {
                            ReadQuestion.interactable = false;
                            OnMultiplayerObjComplete();
                        }
                    }
                }
                else if (selectedCategory == 4)
                {
                    if (GData.Room[1].CulQ[0].AnswerGiven < 3)
                    {
                        GData.Room[1].CulQ[0].AnswerGiven++;
                        PersistentDataManager.instance.SaveData();

                        if (GData.Room[1].CulQ[0].AnswerGiven < 3)
                        {
                            SetCultureQuizData(4);
                        }
                        else if (GData.Room[1].CulQ[0].AnswerGiven == 3)
                        {
                            ReadQuestion.interactable = false;
                            OnMultiplayerObjComplete();
                        }
                    }
                }
            }

        }
        else if (Category.Equals(MCQS_KEY))
        {
            if (!GameManager.Instance.IsMulti)
            {
                if (selectedCategory == 1)
                {
                    if (PlayerPrefs.GetInt("BelgiumHist", 0) < 3)
                    {
                        PlayerPrefs.SetInt("BelgiumHist", (PlayerPrefs.GetInt("BelgiumHist")) + 1);
                        PlayerPrefs.SetInt("BMscore", PlayerPrefs.GetInt("BMscore") + 5);
                        PlayerPrefs.Save();
                        if (PlayerPrefs.GetInt("BelgiumHist", 0) < 3)
                        {
                            SetHistoryQuizDataMCQS(1);
                        }
                        else if (PlayerPrefs.GetInt("BelgiumHist", 0) == 3)
                        {
                            PlayerPrefs.SetInt("Level2", (PlayerPrefs.GetInt("Level2")) + 1);
                            PlayerPrefs.Save();

                            quizHist.interactable = false;
                            quizPanel.SetActive(false);
                            levelCompletePanel.SetActive(true);
                            LevelCompleteText.text = PlayerPrefs.GetInt("BMscore").ToString();
                            Background.SetActive(true);
                            ReadQuestion.interactable = false;
                            GData.OffRoom[GData.SelectedRoom].RoomObj[selectedCategory - 1].IsComplete = true;
                            PersistentDataManager.instance.SaveData();

                        }
                    }
                }
                else if (selectedCategory == 2)
                {
                    if (PlayerPrefs.GetInt("BelgiumGeo", 0) < 3)
                    {
                        PlayerPrefs.SetInt("BelgiumGeo", (PlayerPrefs.GetInt("BelgiumGeo")) + 1);
                        PlayerPrefs.SetInt("BMscore", PlayerPrefs.GetInt("BMscore") + 5);
                        PlayerPrefs.Save();

                        if (PlayerPrefs.GetInt("BelgiumGeo", 0) < 3)
                        {
                            SetGeographyQuizDataMCQS(2);
                        }
                        else if (PlayerPrefs.GetInt("BelgiumGeo", 0) == 3)
                        {
                            PlayerPrefs.SetInt("Level2", (PlayerPrefs.GetInt("Level2")) + 1);
                            PlayerPrefs.Save();

                            quizGeo.interactable = false;

                            quizPanel.SetActive(false);
                            levelCompletePanel.SetActive(true);
                            LevelCompleteText.text = PlayerPrefs.GetInt("BMscore").ToString();
                            Background.SetActive(true);
                            ReadQuestion.interactable = false;
                            GData.OffRoom[GData.SelectedRoom].RoomObj[selectedCategory - 1].IsComplete = true;
                            PersistentDataManager.instance.SaveData();

                        }
                    }
                    //else if (PlayerPrefs.GetInt("BelgiumGeo", 0) == 3 && !geographyCompleteImage.activeInHierarchy)
                    //{
                    //    PlayerPrefs.SetInt("Level2", (PlayerPrefs.GetInt("Level2")) + 1);
                    //    PlayerPrefs.Save();

                    //    //quizGeo.interactable = false;

                    //    quizPanel.SetActive(false);
                    //    levelCompletePanel.SetActive(true);
                    //    LevelCompleteText.text = PlayerPrefs.GetInt("BMscore").ToString();
                    //    Background.SetActive(true);

                    //}
                    //else if (PlayerPrefs.GetInt("BelgiumGeo", 0) == 3 && geographyCompleteImage.activeInHierarchy)
                    //{
                    //    quizPanel.SetActive(false);
                    //    levelCompletePanel.SetActive(true);
                    //    LevelCompleteText.text = PlayerPrefs.GetInt("BMscore").ToString();
                    //    Background.SetActive(true);

                    //}
                }
                else if (selectedCategory == 3)
                {
                    if (PlayerPrefs.GetInt("BelgiumFood", 0) < 3)
                    {
                        PlayerPrefs.SetInt("BelgiumFood", (PlayerPrefs.GetInt("BelgiumFood")) + 1);
                        PlayerPrefs.SetInt("BMscore", PlayerPrefs.GetInt("BMscore") + 5);
                        PlayerPrefs.Save();

                        if (PlayerPrefs.GetInt("BelgiumFood", 0) < 3)
                        {
                            SetFoodQuizDataMCQS(3);
                        }
                        else if (PlayerPrefs.GetInt("BelgiumFood", 0) == 3)
                        {
                            PlayerPrefs.SetInt("Level2", (PlayerPrefs.GetInt("Level2")) + 1);
                            PlayerPrefs.Save();

                            quizFood.interactable = false;

                            quizPanel.SetActive(false);
                            levelCompletePanel.SetActive(true);
                            LevelCompleteText.text = PlayerPrefs.GetInt("BMscore").ToString();
                            Background.SetActive(true);
                            ReadQuestion.interactable = false;
                            GData.OffRoom[GData.SelectedRoom].RoomObj[selectedCategory - 1].IsComplete = true;
                            PersistentDataManager.instance.SaveData();
                        }
                    }
                    //else if (PlayerPrefs.GetInt("BelgiumFood", 0) == 3 && !foodCompleteImage.activeInHierarchy)
                    //{
                    //    PlayerPrefs.SetInt("Level2", (PlayerPrefs.GetInt("Level2")) + 1);
                    //    PlayerPrefs.Save();

                    //    //quizFood.interactable = false;

                    //    quizPanel.SetActive(false);
                    //    levelCompletePanel.SetActive(true);
                    //    LevelCompleteText.text = PlayerPrefs.GetInt("BMscore").ToString();
                    //    Background.SetActive(true);
                    //}
                    //else if (PlayerPrefs.GetInt("BelgiumFood", 0) == 3 && foodCompleteImage.activeInHierarchy)
                    //{
                    //    quizPanel.SetActive(false);
                    //    levelCompletePanel.SetActive(true);
                    //    LevelCompleteText.text = PlayerPrefs.GetInt("BMscore").ToString();
                    //    Background.SetActive(true);
                    //}
                }
                else if (selectedCategory == 4)
                {
                    if (PlayerPrefs.GetInt("BelgiumCult", 0) < 3)
                    {
                        PlayerPrefs.SetInt("BelgiumCult", (PlayerPrefs.GetInt("BelgiumCult")) + 1);
                        PlayerPrefs.SetInt("BMscore", PlayerPrefs.GetInt("BMscore") + 5);
                        PlayerPrefs.Save();

                        if (PlayerPrefs.GetInt("BelgiumCult", 0) < 3)
                        {
                            SetCultureQuizDataMCQS(4);
                        }
                        else if (PlayerPrefs.GetInt("BelgiumCult", 0) == 3)
                        {
                            PlayerPrefs.SetInt("Level2", (PlayerPrefs.GetInt("Level2")) + 1);
                            PlayerPrefs.Save();

                            quizCult.interactable = false;

                            quizPanel.SetActive(false);
                            levelCompletePanel.SetActive(true);
                            LevelCompleteText.text = PlayerPrefs.GetInt("BMscore").ToString();
                            Background.SetActive(true);
                            ReadQuestion.interactable = false;
                            GData.OffRoom[GData.SelectedRoom].RoomObj[selectedCategory - 1].IsComplete = true;
                            PersistentDataManager.instance.SaveData();
                        }
                    }
                    //else if (PlayerPrefs.GetInt("BelgiumCult", 0) == 3 && !cultureCompleteImage.activeInHierarchy)
                    //{
                    //    PlayerPrefs.SetInt("Level2", (PlayerPrefs.GetInt("Level2")) + 1);
                    //    PlayerPrefs.Save();

                    //    //quizCult.interactable = false;

                    //    quizPanel.SetActive(false);
                    //    levelCompletePanel.SetActive(true);
                    //    LevelCompleteText.text = PlayerPrefs.GetInt("BMscore").ToString();
                    //    Background.SetActive(true);
                    //}
                    //else if (PlayerPrefs.GetInt("BelgiumCult", 0) == 3 && cultureCompleteImage.activeInHierarchy)
                    //{
                    //    quizPanel.SetActive(false);
                    //    levelCompletePanel.SetActive(true);
                    //    LevelCompleteText.text = PlayerPrefs.GetInt("BMscore").ToString();
                    //    Background.SetActive(true);
                    //}
                }
            }
            else
            {
                if (selectedCategory == 1)
                {
                    if (GData.Room[1].HisQ[0].AnswerGiven < 3)
                    {
                        GData.Room[1].HisQ[0].AnswerGiven++;
                        PersistentDataManager.instance.SaveData();
                        if (GData.Room[1].HisQ[0].AnswerGiven < 3)
                        {
                            SetHistoryQuizDataMCQS(1);
                        }
                        else if (GData.Room[1].HisQ[0].AnswerGiven == 3)
                        {
                            ReadQuestion.interactable = false;
                            OnMultiplayerObjComplete();
                        }
                    }
                }
                else if (selectedCategory == 2)
                {
                    if (GData.Room[1].GeoQ[0].AnswerGiven < 3)
                    {
                        GData.Room[1].GeoQ[0].AnswerGiven++;
                        PersistentDataManager.instance.SaveData();

                        if (GData.Room[1].GeoQ[0].AnswerGiven < 3)
                        {
                            SetGeographyQuizDataMCQS(2);
                        }
                        else if (GData.Room[1].GeoQ[0].AnswerGiven == 3)
                        {
                            ReadQuestion.interactable = false;
                            OnMultiplayerObjComplete();
                        }
                    }
                }
                else if (selectedCategory == 3)
                {
                    if (GData.Room[1].FoodQ[0].AnswerGiven < 3)
                    {
                        GData.Room[1].FoodQ[0].AnswerGiven++;
                        PersistentDataManager.instance.SaveData();

                        if (GData.Room[1].FoodQ[0].AnswerGiven < 3)
                        {
                            SetFoodQuizDataMCQS(3);
                        }
                        else if (GData.Room[1].FoodQ[0].AnswerGiven == 3)
                        {
                            ReadQuestion.interactable = false;
                            OnMultiplayerObjComplete();
                        }
                    }
                }
                else if (selectedCategory == 4)
                {
                    if (GData.Room[1].CulQ[0].AnswerGiven < 3)
                    {
                        GData.Room[1].CulQ[0].AnswerGiven++;
                        PersistentDataManager.instance.SaveData();

                        if (GData.Room[1].CulQ[0].AnswerGiven < 3)
                        {
                            SetCultureQuizDataMCQS(4);
                        }
                        else if (GData.Room[1].CulQ[0].AnswerGiven == 3)
                        {
                            ReadQuestion.interactable = false;
                            OnMultiplayerObjComplete();
                        }
                    }
                }
            }

        }
        UpdateGameProgress();

    }
    public void OnMultiplayerObjComplete()
    {
        quizPanel.SetActive(false);
        levelCompletePanel.SetActive(true);
        levelCompletePanel.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
        levelCompletePanel.transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(false);
        levelCompletePanel.transform.GetChild(1).GetComponent<Text>().text = "Object Complete";
        LevelCompleteText.gameObject.SetActive(false);
        Background.SetActive(true);
    }
    IEnumerator WrongAnswerwait(string Category)
    {
        yield return new WaitForSeconds(1f);

        CorrectAnswerText.gameObject.SetActive(false);
        WrongAnswerText.gameObject.SetActive(false);

        if (Category.Equals(TF_KEY))
        {
            if (!GameManager.Instance.IsMulti)
            {
                if (selectedCategory == 1)
                {
                    if (PlayerPrefs.GetInt("BelgiumHist", 0) < 3)
                    {
                        PlayerPrefs.SetInt("BelgiumHist", (PlayerPrefs.GetInt("BelgiumHist")) + 1);
                        PlayerPrefs.Save();
                        if (PlayerPrefs.GetInt("BelgiumHist", 0) < 3)
                        {
                            SetHistoryQuizData(1);
                        }
                        else if (PlayerPrefs.GetInt("BelgiumHist", 0) == 3)
                        {
                            PlayerPrefs.SetInt("Level2", (PlayerPrefs.GetInt("Level2")) + 1);
                            PlayerPrefs.Save();
                            quizHist.interactable = false;
                            quizPanel.SetActive(false);
                            levelCompletePanel.SetActive(true);
                            LevelCompleteText.text = PlayerPrefs.GetInt("BMscore").ToString();
                            Background.SetActive(true);
                            ReadQuestion.interactable = false;
                            GData.OffRoom[GData.SelectedRoom].RoomObj[selectedCategory - 1].IsComplete = true;
                            PersistentDataManager.instance.SaveData();

                        }
                    }
                }
                else if (selectedCategory == 2)
                {
                    if (PlayerPrefs.GetInt("BelgiumGeo", 0) < 3)
                    {
                        PlayerPrefs.SetInt("BelgiumGeo", (PlayerPrefs.GetInt("BelgiumGeo")) + 1);
                        PlayerPrefs.Save();

                        if (PlayerPrefs.GetInt("BelgiumGeo", 0) < 3)
                        {
                            SetGeographyQuizData(2);
                        }
                        else if (PlayerPrefs.GetInt("BelgiumGeo", 0) == 3)
                        {
                            PlayerPrefs.SetInt("Level2", (PlayerPrefs.GetInt("Level2")) + 1);
                            PlayerPrefs.Save();

                            quizGeo.interactable = false;

                            quizPanel.SetActive(false);
                            levelCompletePanel.SetActive(true);
                            LevelCompleteText.text = PlayerPrefs.GetInt("BMscore").ToString();
                            Background.SetActive(true);
                            ReadQuestion.interactable = false;
                            GData.OffRoom[GData.SelectedRoom].RoomObj[selectedCategory - 1].IsComplete = true;
                            PersistentDataManager.instance.SaveData();

                        }
                    }
                }
                else if (selectedCategory == 3)
                {
                    if (PlayerPrefs.GetInt("BelgiumFood", 0) < 3)
                    {
                        PlayerPrefs.SetInt("BelgiumFood", (PlayerPrefs.GetInt("BelgiumFood")) + 1);
                        PlayerPrefs.Save();

                        if (PlayerPrefs.GetInt("BelgiumFood", 0) < 3)
                        {
                            SetFoodQuizData(3);
                        }
                        else if (PlayerPrefs.GetInt("BelgiumFood", 0) == 3)
                        {
                            PlayerPrefs.SetInt("Level2", (PlayerPrefs.GetInt("Level2")) + 1);
                            PlayerPrefs.Save();

                            quizFood.interactable = false;

                            quizPanel.SetActive(false);
                            levelCompletePanel.SetActive(true);
                            LevelCompleteText.text = PlayerPrefs.GetInt("BMscore").ToString();
                            Background.SetActive(true);
                            ReadQuestion.interactable = false;
                            GData.OffRoom[GData.SelectedRoom].RoomObj[selectedCategory - 1].IsComplete = true;
                            PersistentDataManager.instance.SaveData();
                        }
                    }
                }
                else if (selectedCategory == 4)
                {
                    if (PlayerPrefs.GetInt("BelgiumCult", 0) < 3)
                    {
                        PlayerPrefs.SetInt("BelgiumCult", (PlayerPrefs.GetInt("BelgiumCult")) + 1);
                        PlayerPrefs.Save();

                        if (PlayerPrefs.GetInt("BelgiumCult", 0) < 3)
                        {
                            SetCultureQuizData(4);
                        }
                        else if (PlayerPrefs.GetInt("BelgiumCult", 0) == 3)
                        {
                            PlayerPrefs.SetInt("Level2", (PlayerPrefs.GetInt("Level2")) + 1);
                            PlayerPrefs.Save();

                            quizCult.interactable = false;

                            quizPanel.SetActive(false);
                            levelCompletePanel.SetActive(true);
                            LevelCompleteText.text = PlayerPrefs.GetInt("BMscore").ToString();
                            Background.SetActive(true);
                            ReadQuestion.interactable = false;
                            GData.OffRoom[GData.SelectedRoom].RoomObj[selectedCategory - 1].IsComplete = true;
                            PersistentDataManager.instance.SaveData();
                        }
                    }
                }
            }
        }
        else if (Category.Equals(MCQS_KEY))
        {
            if (!GameManager.Instance.IsMulti)
            {
                if (selectedCategory == 1)
                {
                    if (PlayerPrefs.GetInt("BelgiumHist", 0) < 3)
                    {
                        PlayerPrefs.SetInt("BelgiumHist", (PlayerPrefs.GetInt("BelgiumHist")) + 1);
                        PlayerPrefs.Save();
                        if (PlayerPrefs.GetInt("BelgiumHist", 0) < 3)
                        {
                            SetHistoryQuizDataMCQS(1);
                        }
                        else if (PlayerPrefs.GetInt("BelgiumHist", 0) == 3)
                        {
                            PlayerPrefs.SetInt("Level2", (PlayerPrefs.GetInt("Level2")) + 1);
                            PlayerPrefs.Save();

                            quizHist.interactable = false;
                            quizPanel.SetActive(false);
                            levelCompletePanel.SetActive(true);
                            LevelCompleteText.text = PlayerPrefs.GetInt("BMscore").ToString();
                            Background.SetActive(true);
                            ReadQuestion.interactable = false;
                            GData.OffRoom[GData.SelectedRoom].RoomObj[selectedCategory - 1].IsComplete = true;
                            PersistentDataManager.instance.SaveData();

                        }
                    }
                }
                else if (selectedCategory == 2)
                {
                    if (PlayerPrefs.GetInt("BelgiumGeo", 0) < 3)
                    {
                        PlayerPrefs.SetInt("BelgiumGeo", (PlayerPrefs.GetInt("BelgiumGeo")) + 1);
                        PlayerPrefs.Save();

                        if (PlayerPrefs.GetInt("BelgiumGeo", 0) < 3)
                        {
                            SetGeographyQuizDataMCQS(2);
                        }
                        else if (PlayerPrefs.GetInt("BelgiumGeo", 0) == 3)
                        {
                            PlayerPrefs.SetInt("Level2", (PlayerPrefs.GetInt("Level2")) + 1);
                            PlayerPrefs.Save();

                            quizGeo.interactable = false;

                            quizPanel.SetActive(false);
                            levelCompletePanel.SetActive(true);
                            LevelCompleteText.text = PlayerPrefs.GetInt("BMscore").ToString();
                            Background.SetActive(true);
                            ReadQuestion.interactable = false;
                            GData.OffRoom[GData.SelectedRoom].RoomObj[selectedCategory - 1].IsComplete = true;
                            PersistentDataManager.instance.SaveData();

                        }
                    }
                }
                else if (selectedCategory == 3)
                {
                    if (PlayerPrefs.GetInt("BelgiumFood", 0) < 3)
                    {
                        PlayerPrefs.SetInt("BelgiumFood", (PlayerPrefs.GetInt("BelgiumFood")) + 1);
                        PlayerPrefs.Save();

                        if (PlayerPrefs.GetInt("BelgiumFood", 0) < 3)
                        {
                            SetFoodQuizDataMCQS(3);
                        }
                        else if (PlayerPrefs.GetInt("BelgiumFood", 0) == 3)
                        {
                            PlayerPrefs.SetInt("Level2", (PlayerPrefs.GetInt("Level2")) + 1);
                            PlayerPrefs.Save();

                            quizFood.interactable = false;

                            quizPanel.SetActive(false);
                            levelCompletePanel.SetActive(true);
                            LevelCompleteText.text = PlayerPrefs.GetInt("BMscore").ToString();
                            Background.SetActive(true);
                            ReadQuestion.interactable = false;
                            GData.OffRoom[GData.SelectedRoom].RoomObj[selectedCategory - 1].IsComplete = true;
                            PersistentDataManager.instance.SaveData();
                        }
                    }
                }
                else if (selectedCategory == 4)
                {
                    if (PlayerPrefs.GetInt("BelgiumCult", 0) < 3)
                    {
                        PlayerPrefs.SetInt("BelgiumCult", (PlayerPrefs.GetInt("BelgiumCult")) + 1);
                        PlayerPrefs.Save();

                        if (PlayerPrefs.GetInt("BelgiumCult", 0) < 3)
                        {
                            SetCultureQuizDataMCQS(4);
                        }
                        else if (PlayerPrefs.GetInt("BelgiumCult", 0) == 3)
                        {
                            PlayerPrefs.SetInt("Level2", (PlayerPrefs.GetInt("Level2")) + 1);
                            PlayerPrefs.Save();

                            quizCult.interactable = false;

                            quizPanel.SetActive(false);
                            levelCompletePanel.SetActive(true);
                            LevelCompleteText.text = PlayerPrefs.GetInt("BMscore").ToString();
                            Background.SetActive(true);
                            ReadQuestion.interactable = false;
                            GData.OffRoom[GData.SelectedRoom].RoomObj[selectedCategory - 1].IsComplete = true;
                            PersistentDataManager.instance.SaveData();
                        }
                    }
                }
            }
        }
        UpdateGameProgress();
    }
    [System.Serializable]
    public class FindIndex
    {
        public string[] Index;
    }

    #endregion
}
//[System.Serializable]
