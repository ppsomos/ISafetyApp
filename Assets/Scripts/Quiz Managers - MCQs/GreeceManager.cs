using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GreeceManager : MonoBehaviour
{


    public TrueFalseData TFData;
    public TrueFalseData TFData_Greek;
    public TrueFalseData TFData_Polish;
    public GameData GData;
    public PosterData Poster;
    public GameObject[] Room_Poster;
    public Image[] Canves_Room_Poster;
    /// <summary>
    /// Fake News Quizes Data
    /// </summary>
    /// 

    public Button TickButton1;
    public Button TickButton2;
    public Button TickButton3;

    public Button ResetButton;

    //public string[] TFQuestions;
    //public int[] TFAns;


    public Text CorrectAnswerText;
    public Text WrongAnswerText;



    public int[] historyAns;
    public string[] historyQues;
    public static string historyFinalAnswer;
    //public static int historyQuizIndex;

    private Option[] histOp1 = new Option[5];
    private Option[] histOp2 = new Option[5];


    public Text historyQuestonText;
    public Text[] historyOptionTexts;
    public TextMeshProUGUI historyScoreText;
    public GameObject historyCompleteImage;

    /// <summary>
    /// Geography Quiz Data
    /// </summary>
    /// 
    public int[] geographyAns;
    public string[] geographyQues;
    public static string geographyFinalAnswer;
    //public static int geographyQuizIndex;

    private Option[] geogOp1 = new Option[5];
    private Option[] geogOp2 = new Option[5];

    public Text geographyQuestonText;
    public Text[] geographyOptionTexts;
    public TextMeshProUGUI geographyScoreText;
    public GameObject geographyCompleteImage;


    /// <summary>
    /// Food Quiz Data
    /// </summary>
    /// 
    public int[] foodAns;
    public string[] foodQues;
    public static string foodFinalAnswer;
    //public static int foodQuizIndex;

    private Option[] foodOp1 = new Option[5];
    private Option[] foodOp2 = new Option[5];


    public Text foodQuestonText;
    public Text[] foodOptionTexts;
    public TextMeshProUGUI foodScoreText;
    public GameObject foodCompleteImage;

    /// <summary>
    /// Culture Quiz Data
    /// </summary>
    /// 
    public int[] cultureAns;
    public string[] cultureQues;
    public static string cultureFinalAnswer;
    //public static int cultureQuizIndex;

    private Option[] culOp1 = new Option[5];
    private Option[] culOp2 = new Option[5];


    public Text cultureQuestonText;
    public Text[] cultureOptionTexts;
    public TextMeshProUGUI cultureScoreText;
    public GameObject cultureCompleteImage;


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

    public BoxCollider door3Col;
    public GameObject congratsPanel;
    public GameObject playerController;
    public GameObject playerControllerCanvas;
    public GameObject MainCanvas;
    private bool Ischaracter;

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
        PlayerPrefs.SetString("SelectedManager", "GR");
        UpdateGameProgress();
        //RemoveTextStyle.onClick.RemoveAllListeners();
        //RemoveTextStyle.onClick.AddListener(RemoveTextStyleFunc);
        //SetPoster();
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
    //    //int Sel = PlayerPrefs.GetInt("levelcurrent") - 1;
    //    //for (int i = 0; i < Room_Poster.Length; i++)
    //    //{
    //    //    Canves_Room_Poster[i].GetComponent<Image>().sprite = Poster.Room[Sel].PosterLanguage[GData.SelectedLanguage].Poster[i].Poster_Sprite;
    //    //    Room_Poster[i].GetComponent<SpriteRenderer>().sprite = Poster.Room[Sel].PosterLanguage[GData.SelectedLanguage].Poster[i].Poster_Sprite;
    //    //}
    //}
    public void UpdateGameProgress()
    {
        OptionButtonHandle(true);
        if (!GameManager.Instance.IsMulti)
        {
            historyScoreText.text = PlayerPrefs.GetInt("GreeceHist") + "/3";
            geographyScoreText.text = PlayerPrefs.GetInt("GreeceGeo") + "/3";
            foodScoreText.text = PlayerPrefs.GetInt("GreeceFood") + "/3";
            cultureScoreText.text = PlayerPrefs.GetInt("GreeceCult") + "/3";

            if (PlayerPrefs.GetInt("GreeceHist") >= 3)
            {
                quizHist.interactable = false;

                historyCompleteImage.SetActive(true);
            }
            if (PlayerPrefs.GetInt("GreeceGeo") >= 3)
            {
                quizGeo.interactable = false;

                geographyCompleteImage.SetActive(true);
            }
            if (PlayerPrefs.GetInt("GreeceFood") >= 3)
            {
                quizFood.interactable = false;
                foodCompleteImage.SetActive(true);
            }
            if (PlayerPrefs.GetInt("GreeceCult") >= 3)
            {
                quizCult.interactable = false;
                cultureCompleteImage.SetActive(true);
            }
            if (PlayerPrefs.GetInt("Level3") >= 4)
            {
                LevelFail();
            }
        }
        else
        {
            historyScoreText.text = GData.Room[2].HisQ[0].AnswerGiven + "/3";
            geographyScoreText.text = GData.Room[2].GeoQ[0].AnswerGiven + "/3";
            foodScoreText.text = GData.Room[2].FoodQ[0].AnswerGiven + "/3";
            cultureScoreText.text = GData.Room[2].CulQ[0].AnswerGiven + "/3";
            if (GData.Room[2].No_Of_Obj_Complete < 4)
            {
                if (GData.Room[2].HisQ[0].AnswerGiven >= GData.Room[2].HisQ[0].TotalQuestion)
                {
                    if (!GData.Room[2].HisQ[0].IsComplte)
                    {
                        GData.Room[2].HisQ[0].IsComplte = true;
                        GData.Room[2].No_Of_Obj_Complete++;
                        PersistentDataManager.instance.SaveData();
                        historyCompleteImage.SetActive(true);
                    }
                    else
                    {
                        ReadQuestion.interactable = false;
                    }
                }
                if (GData.Room[2].GeoQ[0].AnswerGiven >= GData.Room[2].GeoQ[0].TotalQuestion)
                {
                    if (!GData.Room[2].GeoQ[0].IsComplte)
                    {
                        GData.Room[2].GeoQ[0].IsComplte = true;
                        GData.Room[2].No_Of_Obj_Complete++;
                        PersistentDataManager.instance.SaveData();
                        geographyCompleteImage.SetActive(true);
                    }
                    else
                    {
                        ReadQuestion.interactable = false;
                    }
                }
                if (GData.Room[2].FoodQ[0].AnswerGiven >= GData.Room[2].FoodQ[0].TotalQuestion)
                {
                    if (!GData.Room[2].FoodQ[0].IsComplte)
                    {
                        GData.Room[2].FoodQ[0].IsComplte = true;
                        GData.Room[2].No_Of_Obj_Complete++;
                        PersistentDataManager.instance.SaveData();
                        foodCompleteImage.SetActive(true);
                    }
                    else
                    {
                        ReadQuestion.interactable = false;
                    }
                }
                if (GData.Room[2].CulQ[0].AnswerGiven >= GData.Room[2].CulQ[0].TotalQuestion)
                {
                    if (!GData.Room[2].CulQ[0].IsComplte)
                    {
                        GData.Room[2].CulQ[0].IsComplte = true;
                        GData.Room[2].No_Of_Obj_Complete++;
                        PersistentDataManager.instance.SaveData();
                        cultureCompleteImage.SetActive(true);
                    }
                    else
                    {
                        ReadQuestion.interactable = false;
                    }
                }

                if (GData.Room[2].No_Of_Obj_Complete == 4)
                {
                    GData.Player[GameManager.Instance.SelectedPlayer].IsComplete = true;
                    GData.Player[GameManager.Instance.SelectedPlayer].TimeTaken = GData.GameTime - PlayerPrefs.GetFloat("TimeRemaining");
                    PersistentDataManager.instance.SaveData();
                    //if (GameManager.Instance.SelectedPlayer < 1)
                    {
                        //Debug.Log("22222");
                        CountDown.timerIsRunning = true;
                        RoomCompleteParticleEffect.SetActive(true);
                        //congratsPanel.SetActive(true);
                        //congratsPanel.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = "Player1 Turn Complete";
                        //cultureCompleteImage.SetActive(false);
                        //playerController.SetActive(false);
                    }
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
        if (PlayerPrefs.GetInt("GMscore") >= 30)
        {
            RoomCompleteParticleEffect.SetActive(true);
        }
        else
        {
            levelFailPanel.SetActive(true);
            levelFailPanel.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
            switch (GData.SelectedLanguage)
            {
                case 0:
                    ShowScore.text = $"Your Score is {PlayerPrefs.GetInt("GMscore")}" + " / 60";
                    break;
                case 1:
                    ShowScore.text = $"Το σκορ σου είναι {PlayerPrefs.GetInt("GMscore")}" + " / 60";
                    break;
                case 2:
                    ShowScore.text = $"Twój wynik to {PlayerPrefs.GetInt("GMscore")}" + " / 60";
                    break;
            }
        }
    }
    public void CompleteRoom()
    {
        if (!GameManager.Instance.IsMulti)
        {
            PlayerPrefs.SetInt("levelunlocked", 0);
            //door3Col.isTrigger = true;
            if (GData.UnlockedLevel < 6)
            {
                GData.UnlockedLevel = 3;
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
            //GameServices.ReportScore(PlayerPrefs.GetInt("Score"), EM_GameServicesConstants.Leaderboard_Escape_Hero);

            countDown.timeRemaining = GData.GameTime;
            CountDown.timerIsRunning = true;
            PlayerPrefs.SetFloat("TimeRemaining", countDown.timeRemaining);
            PlayerPrefs.Save();

            PlayerPrefs.SetInt("Level3", 0);
            PlayerPrefs.SetInt("LevelM3", 1);
            PlayerPrefs.Save();
        }


        else
        {
            if (GameManager.Instance.SelectedPlayer == 0)
            {
                cultureCompleteImage.SetActive(false);
                congratsPanel.transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(false);
                congratsPanel.transform.GetChild(1).transform.GetChild(1).gameObject.SetActive(true);

                //door1Col.isTrigger = true;
                congratsPanel.SetActive(true);
                playerController.SetActive(false);
                playerControllerCanvas.SetActive(false);
                MainCanvas.SetActive(false);
            }
            else
            {
                GameUIManager.Instance.OnCompetitionComplete();
            }
        }
    }

    #region History Quiz Data

    public void SetHistoryQuizData(int index)
    {
        //onclicks added or removed
        TickButton1.onClick.RemoveAllListeners();
        TickButton1.onClick.AddListener(() => AnswerBtnClick(historyOptionTexts[0]));

        TickButton2.onClick.RemoveAllListeners();
        TickButton2.onClick.AddListener(() => AnswerBtnClick(historyOptionTexts[1]));

        ResetButton.onClick.RemoveAllListeners();
        ResetButton.onClick.AddListener(() => ResetQuestionaPanel());

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

        historyQuestonText.text = historyQues[GData.GRhistoryQuizIndex];

        historyOptionTexts[0].text = histOp1[GData.GRhistoryQuizIndex].answer;
        historyOptionTexts[1].text = histOp2[GData.GRhistoryQuizIndex].answer;

        //setting style
        //SetTextStyle(historyOptionTexts[0], historyOptionTexts[1]);

        if (historyAns[GData.GRhistoryQuizIndex] == 0)
        {
            historyFinalAnswer = histOp1[GData.GRhistoryQuizIndex].answer;
        }
        else if (historyAns[GData.GRhistoryQuizIndex] == 1)
        {
            historyFinalAnswer = histOp2[GData.GRhistoryQuizIndex].answer;
        }

        //Debug.Log(historyFinalAnswer);
    }

    private void SetHistoryOptionData()
    {

        for (int i = 0; i < 5; i++)
        {
            historyQues = new string[5];
            historyQues[i] = "";

            historyAns = new int[5];
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

        //for (int i = 0; i < 5; i++)
        //{
        //    historyQues[i] = TFData.questions[i];
        //    historyAns[i] = TFData.answersIndex[i];

        //    histOp1[i].answer = TFData.Op1[i];
        //    histOp2[i].answer = TFData.Op2[i];
        //}
        switch (GData.SelectedLanguage)
        {
            case 0:
                for (int i = 0; i < 5; i++)
                {
                    historyQues[i] = TFData.questions[i];
                    historyAns[i] = TFData.answersIndex[i];

                    histOp1[i].answer = TFData.Op1[i];
                    histOp2[i].answer = TFData.Op2[i];
                }
                break;
            case 1:
                for (int i = 0; i < 5; i++)
                {
                    historyQues[i] = TFData_Greek.questions[i];
                    historyAns[i] = TFData_Greek.answersIndex[i];

                    histOp1[i].answer = TFData_Greek.Op1[i];
                    histOp2[i].answer = TFData_Greek.Op2[i];
                }
                break;
            case 2:
                for (int i = 0; i < 5; i++)
                {
                    historyQues[i] = TFData_Polish.questions[i];
                    historyAns[i] = TFData_Polish.answersIndex[i];

                    histOp1[i].answer = TFData_Polish.Op1[i];
                    histOp2[i].answer = TFData_Polish.Op2[i];
                }
                break;
        }

    }

    #endregion

    #region Geography Quiz Data

    public void SetGeographyQuizData(int index)
    {
        //onclicks added or removed
        TickButton1.onClick.RemoveAllListeners();
        TickButton1.onClick.AddListener(() => AnswerBtnClick(geographyOptionTexts[0]));

        TickButton2.onClick.RemoveAllListeners();
        TickButton2.onClick.AddListener(() => AnswerBtnClick(geographyOptionTexts[1]));

        ResetButton.onClick.RemoveAllListeners();
        ResetButton.onClick.AddListener(() => ResetQuestionaPanel());

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

        geographyQuestonText.text = geographyQues[GData.GRgeographyQuizIndex];

        geographyOptionTexts[0].text = geogOp1[GData.GRgeographyQuizIndex].answer;
        geographyOptionTexts[1].text = geogOp2[GData.GRgeographyQuizIndex].answer;

        //setting style
        //SetTextStyle(geographyOptionTexts[0], geographyOptionTexts[1]);

        if (geographyAns[GData.GRgeographyQuizIndex] == 0)
        {
            geographyFinalAnswer = geogOp1[GData.GRgeographyQuizIndex].answer;
        }
        else if (geographyAns[GData.GRgeographyQuizIndex] == 1)
        {
            geographyFinalAnswer = geogOp2[GData.GRgeographyQuizIndex].answer;
        }

        //Debug.Log(geographyFinalAnswer);
    }

    private void SetGeographyOptionData()
    {
        for (int i = 0; i < 5; i++)
        {
            geographyQues = new string[5];
            geographyQues[i] = "";

            geographyAns = new int[5];
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


        switch (GData.SelectedLanguage)
        {
            case 0:
                for (int i = 0; i < 5; i++)
                {
                    geographyQues[i] = TFData.questions[i + 5];
                    geographyAns[i] = TFData.answersIndex[i + 5];

                    geogOp1[i].answer = TFData.Op1[i + 5];
                    geogOp2[i].answer = TFData.Op2[i + 5];
                }
                break;
            case 1:
                for (int i = 0; i < 5; i++)
                {
                    geographyQues[i] = TFData_Greek.questions[i + 5];
                    geographyAns[i] = TFData_Greek.answersIndex[i + 5];

                    geogOp1[i].answer = TFData_Greek.Op1[i + 5];
                    geogOp2[i].answer = TFData_Greek.Op2[i + 5];
                }
                break;
            case 2:
                for (int i = 0; i < 5; i++)
                {
                    geographyQues[i] = TFData_Polish.questions[i + 5];
                    geographyAns[i] = TFData_Polish.answersIndex[i + 5];

                    geogOp1[i].answer = TFData_Polish.Op1[i + 5];
                    geogOp2[i].answer = TFData_Polish.Op2[i + 5];
                }
                break;
        }

    }

    #endregion

    #region Food Quiz Data

    public void SetFoodQuizData(int index)
    {
        //onclicks added or removed
        TickButton1.onClick.RemoveAllListeners();
        TickButton1.onClick.AddListener(() => AnswerBtnClick(foodOptionTexts[0]));

        TickButton2.onClick.RemoveAllListeners();
        TickButton2.onClick.AddListener(() => AnswerBtnClick(foodOptionTexts[1]));

        ResetButton.onClick.RemoveAllListeners();
        ResetButton.onClick.AddListener(() => ResetQuestionaPanel());

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

        foodQuestonText.text = foodQues[GData.GRfoodQuizIndex];

        foodOptionTexts[0].text = foodOp1[GData.GRfoodQuizIndex].answer;
        foodOptionTexts[1].text = foodOp2[GData.GRfoodQuizIndex].answer;

        //setting style
        //SetTextStyle(foodOptionTexts[0], foodOptionTexts[1]);

        if (foodAns[GData.GRfoodQuizIndex] == 0)
        {
            foodFinalAnswer = foodOp1[GData.GRfoodQuizIndex].answer;
        }
        else if (foodAns[GData.GRfoodQuizIndex] == 1)
        {
            foodFinalAnswer = foodOp2[GData.GRfoodQuizIndex].answer;
        }


        //Debug.Log(foodFinalAnswer);
    }

    private void SetFoodOptionData()
    {
        for (int i = 0; i < 5; i++)
        {
            foodQues = new string[5];
            foodQues[i] = "";

            foodAns = new int[5];
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

        //for (int i = 0; i < 5; i++)
        //{
        //    foodQues[i] = TFData.questions[i + 10];
        //    foodAns[i] = TFData.answersIndex[i + 10];

        //    foodOp1[i].answer = TFData.Op1[i + 10];
        //    foodOp2[i].answer = TFData.Op2[i + 10];
        //}
        switch (GData.SelectedLanguage)
        {
            case 0:
                for (int i = 0; i < 5; i++)
                {
                    foodQues[i] = TFData.questions[i + 10];
                    foodAns[i] = TFData.answersIndex[i + 10];

                    foodOp1[i].answer = TFData.Op1[i + 10];
                    foodOp2[i].answer = TFData.Op2[i + 10];
                }
                break;
            case 1:
                for (int i = 0; i < 5; i++)
                {
                    foodQues[i] = TFData_Greek.questions[i + 10];
                    foodAns[i] = TFData_Greek.answersIndex[i + 10];

                    foodOp1[i].answer = TFData_Greek.Op1[i + 10];
                    foodOp2[i].answer = TFData_Greek.Op2[i + 10];
                }
                break;
            case 2:
                for (int i = 0; i < 5; i++)
                {
                    foodQues[i] = TFData_Polish.questions[i + 10];
                    foodAns[i] = TFData_Polish.answersIndex[i + 10];

                    foodOp1[i].answer = TFData_Polish.Op1[i + 10];
                    foodOp2[i].answer = TFData_Polish.Op2[i + 10];
                }
                break;
        }

    }

    #endregion

    #region Culture Quiz Data

    public void SetCultureQuizData(int index)
    {
        //onclicks added or removed
        TickButton1.onClick.RemoveAllListeners();
        TickButton1.onClick.AddListener(() => AnswerBtnClick(cultureOptionTexts[0]));

        TickButton2.onClick.RemoveAllListeners();
        TickButton2.onClick.AddListener(() => AnswerBtnClick(cultureOptionTexts[1]));

        ResetButton.onClick.RemoveAllListeners();
        ResetButton.onClick.AddListener(() => ResetQuestionaPanel());

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

        cultureQuestonText.text = cultureQues[GData.GRcultureQuizIndex];

        cultureOptionTexts[0].text = culOp1[GData.GRcultureQuizIndex].answer;
        cultureOptionTexts[1].text = culOp2[GData.GRcultureQuizIndex].answer;

        //setting style
        //SetTextStyle(cultureOptionTexts[0], cultureOptionTexts[1]);

        if (cultureAns[GData.GRcultureQuizIndex] == 0)
        {
            cultureFinalAnswer = culOp1[GData.GRcultureQuizIndex].answer;
        }
        else if (cultureAns[GData.GRcultureQuizIndex] == 1)
        {
            cultureFinalAnswer = culOp2[GData.GRcultureQuizIndex].answer;
        }

        //Debug.Log(cultureFinalAnswer);
    }

    private void SetCultureOptionData()
    {
        for (int i = 0; i < 5; i++)
        {
            cultureQues = new string[5];
            cultureQues[i] = "";

            cultureAns = new int[5];
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

        //for (int i = 0; i < 5; i++)
        //{
        //    cultureQues[i] = TFData.questions[i + 15];
        //    cultureAns[i] = TFData.answersIndex[i + 15];

        //    culOp1[i].answer = TFData.Op1[i + 15];
        //    culOp2[i].answer = TFData.Op2[i + 15];
        //}
        switch (GData.SelectedLanguage)
        {
            case 0:
                for (int i = 0; i < 5; i++)
                {
                    cultureQues[i] = TFData.questions[i + 15];
                    cultureAns[i] = TFData.answersIndex[i + 15];

                    culOp1[i].answer = TFData.Op1[i + 15];
                    culOp2[i].answer = TFData.Op2[i + 15];
                }
                break;
            case 1:
                for (int i = 0; i < 5; i++)
                {
                    cultureQues[i] = TFData_Greek.questions[i + 15];
                    cultureAns[i] = TFData_Greek.answersIndex[i + 15];

                    culOp1[i].answer = TFData_Greek.Op1[i + 15];
                    culOp2[i].answer = TFData_Greek.Op2[i + 15];
                }
                break;
            case 2:
                for (int i = 0; i < 5; i++)
                {
                    cultureQues[i] = TFData_Polish.questions[i + 15];
                    cultureAns[i] = TFData_Polish.answersIndex[i + 15];

                    culOp1[i].answer = TFData_Polish.Op1[i + 15];
                    culOp2[i].answer = TFData_Polish.Op2[i + 15];
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

    public void ResetQuestionaPanel()
    {
        OptionButtonHandle(true);
        if (PlayerPrefs.GetInt("levelcurrent") == 3)
        {
            if (!GameManager.Instance.IsMulti)
            {
                if (selectedCategory == 1 && PlayerPrefs.GetInt("GreeceHist", 0) < 3)
                {
                    SetHistoryQuizData(1);
                    levelFailPanel.SetActive(false);
                    quizPanel.SetActive(true);
                }
                else if (selectedCategory == 2 && PlayerPrefs.GetInt("GreeceGeo", 0) < 3)
                {
                    SetGeographyQuizData(2);
                    levelFailPanel.SetActive(false);
                    quizPanel.SetActive(true);
                }
                else if (selectedCategory == 3 && PlayerPrefs.GetInt("GreeceFood", 0) < 3)
                {
                    SetFoodQuizData(3);
                    levelFailPanel.SetActive(false);
                    quizPanel.SetActive(true);
                }
                else if (selectedCategory == 4 && PlayerPrefs.GetInt("GreeceCult", 0) < 3)
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
                if (selectedCategory == 1 && GData.Room[2].HisQ[0].AnswerGiven < 3)
                {
                    SetHistoryQuizData(1);
                    levelFailPanel.SetActive(false);
                    quizPanel.SetActive(true);
                }
                else if (selectedCategory == 2 && GData.Room[2].GeoQ[0].AnswerGiven < 3)
                {
                    SetGeographyQuizData(2);
                    levelFailPanel.SetActive(false);
                    quizPanel.SetActive(true);
                }
                else if (selectedCategory == 3 && GData.Room[2].FoodQ[0].AnswerGiven < 3)
                {
                    SetFoodQuizData(3);
                    levelFailPanel.SetActive(false);
                    quizPanel.SetActive(true);
                }
                else if (selectedCategory == 4 && GData.Room[2].CulQ[0].AnswerGiven < 3)
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
                    //Debug.Log("Came here5");
                    controller.SetActive(true);
                    countDown.timeRemaining = GData.GameTime;
                    CountDown.timerIsRunning = true;
                    PlayerPrefs.SetFloat("TimeRemaining", countDown.timeRemaining);
                    PlayerPrefs.Save();
                }
            }
        }
    }
    private void OptionButtonHandle(bool Status)
    {
        TickButton1.interactable = Status;
        TickButton2.interactable = Status;
        TickButton3.interactable = Status;
    }
    public void AnswerBtnClick(Text text)
    {
        OptionButtonHandle(false);
        if (PlayerPrefs.GetInt("levelcurrent") == 3)
        {
            if (selectedCategory == 1)
            {
                GData.GRhistoryQuizIndex = (GData.GRhistoryQuizIndex + 1) % historyQues.Length;
                PersistentDataManager.instance.SaveData();
                if (text.text.Equals(historyFinalAnswer) == true)
                {
                    RightAnswerHandler();
                }
                else
                {
                    WrongAnswerHandler();
                }
            }
            else if (selectedCategory == 2)
            {
                GData.GRgeographyQuizIndex = (GData.GRgeographyQuizIndex + 1) % geographyQues.Length;
                PersistentDataManager.instance.SaveData();
                if (text.text.Equals(geographyFinalAnswer) == true)
                {
                    RightAnswerHandler();
                }
                else
                {
                    WrongAnswerHandler();
                }
            }
            else if (selectedCategory == 3)
            {
                GData.GRfoodQuizIndex = (GData.GRfoodQuizIndex + 1) % foodQues.Length;
                PersistentDataManager.instance.SaveData();
                if (text.text.Equals(foodFinalAnswer) == true)
                {
                    RightAnswerHandler();
                }
                else
                {
                    WrongAnswerHandler();
                }
            }
            else if (selectedCategory == 4)
            {
                GData.GRcultureQuizIndex = (GData.GRcultureQuizIndex + 1) % cultureQues.Length;
                PersistentDataManager.instance.SaveData();
                if (text.text.Equals(cultureFinalAnswer) == true)
                {
                    RightAnswerHandler();
                }
                else
                {
                    WrongAnswerHandler();
                }
            }

        }
    }
    public void RightAnswerHandler()
    {
        CorrectAnswerText.gameObject.SetActive(true);
        Confetti1.gameObject.SetActive(true);
        Confetti2.gameObject.SetActive(true);
        Confetti1.Play();
        Confetti2.Play();
        StartCoroutine(CorrectAnswerWait());
        if (GameManager.Instance.IsMulti)
        {
            GData.Player[GameManager.Instance.SelectedPlayer].RightAnswer++;
            PersistentDataManager.instance.SaveData();
        }
        else
        {
            //PlayerPrefs.SetInt("GMscore", PlayerPrefs.GetInt("GMscore") + 5);
        }
    }
    public void WrongAnswerHandler()
    {
        WrongAnswerText.gameObject.SetActive(true);
        StartCoroutine(WrongAnswerwait());

        if (GameManager.Instance.IsMulti)
        {
            StartCoroutine(CorrectAnswerWait());
            GData.Player[GameManager.Instance.SelectedPlayer].WrongAnswer++;
            PersistentDataManager.instance.SaveData();
        }
    }
    IEnumerator CorrectAnswerWait()
    {
        yield return new WaitForSeconds(1f);
        Confetti1.gameObject.SetActive(false);
        Confetti2.gameObject.SetActive(false);
        CorrectAnswerText.gameObject.SetActive(false);
        WrongAnswerText.gameObject.SetActive(false);
        if (!GameManager.Instance.IsMulti)
        {
            if (selectedCategory == 1)
            {
                if (PlayerPrefs.GetInt("GreeceHist", 0) < 3)
                {
                    PlayerPrefs.SetInt("GreeceHist", (PlayerPrefs.GetInt("GreeceHist")) + 1);
                    PlayerPrefs.SetInt("GMscore", PlayerPrefs.GetInt("GMscore") + 5);
                    PlayerPrefs.Save();

                    if (PlayerPrefs.GetInt("GreeceHist", 0) < 3)
                    {
                        SetHistoryQuizData(1);
                    }
                    else if (PlayerPrefs.GetInt("GreeceHist", 0) == 3)
                    {
                        PlayerPrefs.SetInt("Level3", PlayerPrefs.GetInt("Level3") + 1);
                        PlayerPrefs.Save();

                        quizHist.interactable = false;

                        quizPanel.SetActive(false);
                        levelCompletePanel.SetActive(true);
                        LevelCompleteText.text = PlayerPrefs.GetInt("GMscore").ToString();
                        Background.SetActive(true);
                        ReadQuestion.interactable = false;
                        GData.OffRoom[GData.SelectedRoom].RoomObj[selectedCategory - 1].IsComplete = true;
                        PersistentDataManager.instance.SaveData();
                    }
                }
                //else if (PlayerPrefs.GetInt("GreeceHist", 0) == 3 && !historyCompleteImage.activeInHierarchy)
                //{
                //    PlayerPrefs.SetInt("Level3", (PlayerPrefs.GetInt("Level3")) + 1);
                //    PlayerPrefs.Save();

                //    //quizHist.interactable = false;

                //    quizPanel.SetActive(false);
                //    levelCompletePanel.SetActive(true);
                //    LevelCompleteText.text = PlayerPrefs.GetInt("GMscore").ToString();
                //    Background.SetActive(true);
                //}
                //else if (PlayerPrefs.GetInt("GreeceHist", 0) == 3 && historyCompleteImage.activeInHierarchy)
                //{
                //    quizPanel.SetActive(false);
                //    levelCompletePanel.SetActive(true);
                //    LevelCompleteText.text = PlayerPrefs.GetInt("GMscore").ToString();
                //    Background.SetActive(true);
                //}
            }
            else if (selectedCategory == 2)
            {
                if (PlayerPrefs.GetInt("GreeceGeo", 0) < 3)
                {
                    PlayerPrefs.SetInt("GreeceGeo", (PlayerPrefs.GetInt("GreeceGeo")) + 1);
                    PlayerPrefs.SetInt("GMscore", PlayerPrefs.GetInt("GMscore") + 5);
                    PlayerPrefs.Save();

                    if (PlayerPrefs.GetInt("GreeceGeo", 0) < 3)
                    {
                        SetGeographyQuizData(2);
                    }
                    else if (PlayerPrefs.GetInt("GreeceGeo", 0) == 3)
                    {
                        PlayerPrefs.SetInt("Level3", (PlayerPrefs.GetInt("Level3")) + 1);
                        PlayerPrefs.Save();

                        quizGeo.interactable = false;

                        quizPanel.SetActive(false);
                        levelCompletePanel.SetActive(true);
                        LevelCompleteText.text = PlayerPrefs.GetInt("GMscore").ToString();
                        Background.SetActive(true);
                        ReadQuestion.interactable = false;
                        GData.OffRoom[GData.SelectedRoom].RoomObj[selectedCategory - 1].IsComplete = true;
                        PersistentDataManager.instance.SaveData();
                    }

                }
                //else if (PlayerPrefs.GetInt("GreeceGeo", 0) == 3 && !geographyCompleteImage.activeInHierarchy)
                //{
                //    PlayerPrefs.SetInt("Level3", (PlayerPrefs.GetInt("Level3")) + 1);
                //    PlayerPrefs.Save();

                //    //quizGeo.interactable = false;

                //    quizPanel.SetActive(false);
                //    levelCompletePanel.SetActive(true);
                //    LevelCompleteText.text = PlayerPrefs.GetInt("GMscore").ToString();
                //    Background.SetActive(true);
                //}
                //else if (PlayerPrefs.GetInt("GreeceGeo", 0) == 3 && geographyCompleteImage.activeInHierarchy)
                //{
                //    quizPanel.SetActive(false);
                //    levelCompletePanel.SetActive(true);
                //    LevelCompleteText.text = PlayerPrefs.GetInt("GMscore").ToString();
                //    Background.SetActive(true);
                //}
            }
            else if (selectedCategory == 3)
            {
                if (PlayerPrefs.GetInt("GreeceFood", 0) < 3)
                {
                    PlayerPrefs.SetInt("GreeceFood", (PlayerPrefs.GetInt("GreeceFood")) + 1);
                    PlayerPrefs.SetInt("GMscore", PlayerPrefs.GetInt("GMscore") + 5);
                    PlayerPrefs.Save();

                    if (PlayerPrefs.GetInt("GreeceFood", 0) < 3)
                    {
                        SetFoodQuizData(3);
                    }
                    else if (PlayerPrefs.GetInt("GreeceFood", 0) == 3)
                    {
                        PlayerPrefs.SetInt("Level3", (PlayerPrefs.GetInt("Level3")) + 1);
                        PlayerPrefs.Save();

                        quizFood.interactable = false;

                        quizPanel.SetActive(false);
                        levelCompletePanel.SetActive(true);
                        LevelCompleteText.text = PlayerPrefs.GetInt("GMscore").ToString();
                        Background.SetActive(true);
                        ReadQuestion.interactable = false;
                        GData.OffRoom[GData.SelectedRoom].RoomObj[selectedCategory - 1].IsComplete = true;
                        PersistentDataManager.instance.SaveData();
                    }
                }
                //else if (PlayerPrefs.GetInt("GreeceFood", 0) == 3 && !foodCompleteImage.activeInHierarchy)
                //{
                //    PlayerPrefs.SetInt("Level3", (PlayerPrefs.GetInt("Level3")) + 1);
                //    PlayerPrefs.Save();

                //    //quizFood.interactable = false;

                //    quizPanel.SetActive(false);
                //    levelCompletePanel.SetActive(true);
                //    LevelCompleteText.text = PlayerPrefs.GetInt("GMscore").ToString();
                //    Background.SetActive(true);
                //}
                //else if (PlayerPrefs.GetInt("GreeceFood", 0) == 3 && foodCompleteImage.activeInHierarchy)
                //{
                //    quizPanel.SetActive(false);
                //    levelCompletePanel.SetActive(true);
                //    LevelCompleteText.text = PlayerPrefs.GetInt("GMscore").ToString();
                //    Background.SetActive(true);
                //}
            }
            else if (selectedCategory == 4)
            {
                if (PlayerPrefs.GetInt("GreeceCult", 0) < 3)
                {
                    PlayerPrefs.SetInt("GreeceCult", (PlayerPrefs.GetInt("GreeceCult")) + 1);
                    PlayerPrefs.SetInt("GMscore", PlayerPrefs.GetInt("GMscore") + 5);
                    PlayerPrefs.Save();

                    if (PlayerPrefs.GetInt("GreeceCult", 0) < 3)
                    {
                        SetCultureQuizData(4);
                    }
                    else if (PlayerPrefs.GetInt("GreeceCult", 0) == 3)
                    {
                        PlayerPrefs.SetInt("Level3", (PlayerPrefs.GetInt("Level3")) + 1);
                        PlayerPrefs.Save();

                        quizCult.interactable = false;


                        quizPanel.SetActive(false);
                        levelCompletePanel.SetActive(true);
                        LevelCompleteText.text = PlayerPrefs.GetInt("GMscore").ToString();
                        Background.SetActive(true);
                        ReadQuestion.interactable = false;
                        GData.OffRoom[GData.SelectedRoom].RoomObj[selectedCategory - 1].IsComplete = true;
                        PersistentDataManager.instance.SaveData();
                    }
                }
                //else if (PlayerPrefs.GetInt("GreeceCult", 0) == 3 && !cultureCompleteImage.activeInHierarchy)
                //{
                //    PlayerPrefs.SetInt("Level3", (PlayerPrefs.GetInt("Level3")) + 1);
                //    PlayerPrefs.Save();

                //    //quizCult.interactable = false;


                //    quizPanel.SetActive(false);
                //    levelCompletePanel.SetActive(true);
                //    LevelCompleteText.text = PlayerPrefs.GetInt("GMscore").ToString();
                //    Background.SetActive(true);
                //}
                //else if (PlayerPrefs.GetInt("GreeceCult", 0) == 3 && cultureCompleteImage.activeInHierarchy)
                //{
                //    quizPanel.SetActive(false);
                //    levelCompletePanel.SetActive(true);
                //    LevelCompleteText.text = PlayerPrefs.GetInt("GMscore").ToString();
                //    Background.SetActive(true);
                //}
            }
        }
        else
        {
            if (selectedCategory == 1)
            {
                if (GData.Room[2].HisQ[0].AnswerGiven < 3)
                {
                    GData.Room[2].HisQ[0].AnswerGiven++;
                    PersistentDataManager.instance.SaveData();
                    if (GData.Room[2].HisQ[0].AnswerGiven < 3)
                    {
                        SetHistoryQuizData(1);
                    }
                    else if (GData.Room[2].HisQ[0].AnswerGiven == 3)
                    {
                        ReadQuestion.interactable = false;
                        OnMultiplayerObjComplete();
                    }
                }
            }
            else if (selectedCategory == 2)
            {
                if (GData.Room[2].GeoQ[0].AnswerGiven < 3)
                {
                    GData.Room[2].GeoQ[0].AnswerGiven++;
                    PersistentDataManager.instance.SaveData();
                    if (GData.Room[2].GeoQ[0].AnswerGiven < 3)
                    {
                        SetGeographyQuizData(2);
                    }
                    else if (GData.Room[2].GeoQ[0].AnswerGiven == 3)
                    {
                        ReadQuestion.interactable = false;
                        OnMultiplayerObjComplete();
                    }
                }
            }
            else if (selectedCategory == 3)
            {
                if (GData.Room[2].FoodQ[0].AnswerGiven < 3)
                {
                    GData.Room[2].FoodQ[0].AnswerGiven++;
                    PersistentDataManager.instance.SaveData();
                    if (GData.Room[2].FoodQ[0].AnswerGiven < 3)
                    {
                        SetFoodQuizData(3);
                    }
                    else if (GData.Room[2].FoodQ[0].AnswerGiven == 3)
                    {
                        ReadQuestion.interactable = false;
                        OnMultiplayerObjComplete();
                    }
                }
            }
            else if (selectedCategory == 4)
            {
                if (GData.Room[2].CulQ[0].AnswerGiven < 3)
                {
                    GData.Room[2].CulQ[0].AnswerGiven++;
                    PersistentDataManager.instance.SaveData();
                    if (GData.Room[2].CulQ[0].AnswerGiven < 3)
                    {
                        SetCultureQuizData(4);
                    }
                    else if (GData.Room[2].CulQ[0].AnswerGiven == 3)
                    {
                        ReadQuestion.interactable = false;
                        OnMultiplayerObjComplete();
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
    IEnumerator WrongAnswerwait()
    {
        yield return new WaitForSeconds(1f);
        CorrectAnswerText.gameObject.SetActive(false);
        WrongAnswerText.gameObject.SetActive(false);

        if (!GameManager.Instance.IsMulti)
        {
            if (selectedCategory == 1)
            {
                if (PlayerPrefs.GetInt("GreeceHist", 0) < 3)
                {
                    PlayerPrefs.SetInt("GreeceHist", (PlayerPrefs.GetInt("GreeceHist")) + 1);
                    PlayerPrefs.Save();

                    if (PlayerPrefs.GetInt("GreeceHist", 0) < 3)
                    {
                        SetHistoryQuizData(1);
                    }
                    else if (PlayerPrefs.GetInt("GreeceHist", 0) == 3)
                    {
                        PlayerPrefs.SetInt("Level3", (PlayerPrefs.GetInt("Level3")) + 1);
                        PlayerPrefs.Save();

                        quizHist.interactable = false;

                        quizPanel.SetActive(false);
                        levelCompletePanel.SetActive(true);
                        LevelCompleteText.text = PlayerPrefs.GetInt("GMscore").ToString();
                        Background.SetActive(true);
                        ReadQuestion.interactable = false;
                        GData.OffRoom[GData.SelectedRoom].RoomObj[selectedCategory - 1].IsComplete = true;
                        PersistentDataManager.instance.SaveData();
                    }
                }
            }
            else if (selectedCategory == 2)
            {
                if (PlayerPrefs.GetInt("GreeceGeo", 0) < 3)
                {
                    PlayerPrefs.SetInt("GreeceGeo", (PlayerPrefs.GetInt("GreeceGeo")) + 1);
                    PlayerPrefs.Save();

                    if (PlayerPrefs.GetInt("GreeceGeo", 0) < 3)
                    {
                        SetGeographyQuizData(2);
                    }
                    else if (PlayerPrefs.GetInt("GreeceGeo", 0) == 3)
                    {
                        PlayerPrefs.SetInt("Level3", (PlayerPrefs.GetInt("Level3")) + 1);
                        PlayerPrefs.Save();

                        quizGeo.interactable = false;

                        quizPanel.SetActive(false);
                        levelCompletePanel.SetActive(true);
                        LevelCompleteText.text = PlayerPrefs.GetInt("GMscore").ToString();
                        Background.SetActive(true);
                        ReadQuestion.interactable = false;
                        GData.OffRoom[GData.SelectedRoom].RoomObj[selectedCategory - 1].IsComplete = true;
                        PersistentDataManager.instance.SaveData();
                    }

                }
            }
            else if (selectedCategory == 3)
            {
                if (PlayerPrefs.GetInt("GreeceFood", 0) < 3)
                {
                    PlayerPrefs.SetInt("GreeceFood", (PlayerPrefs.GetInt("GreeceFood")) + 1);
                    PlayerPrefs.Save();

                    if (PlayerPrefs.GetInt("GreeceFood", 0) < 3)
                    {
                        SetFoodQuizData(3);
                    }
                    else if (PlayerPrefs.GetInt("GreeceFood", 0) == 3)
                    {
                        PlayerPrefs.SetInt("Level3", (PlayerPrefs.GetInt("Level3")) + 1);
                        PlayerPrefs.Save();

                        quizFood.interactable = false;

                        quizPanel.SetActive(false);
                        levelCompletePanel.SetActive(true);
                        LevelCompleteText.text = PlayerPrefs.GetInt("GMscore").ToString();
                        Background.SetActive(true);
                        ReadQuestion.interactable = false;
                        GData.OffRoom[GData.SelectedRoom].RoomObj[selectedCategory - 1].IsComplete = true;
                        PersistentDataManager.instance.SaveData();
                    }
                }
            }
            else if (selectedCategory == 4)
            {
                if (PlayerPrefs.GetInt("GreeceCult", 0) < 3)
                {
                    PlayerPrefs.SetInt("GreeceCult", (PlayerPrefs.GetInt("GreeceCult")) + 1);
                    PlayerPrefs.Save();

                    if (PlayerPrefs.GetInt("GreeceCult", 0) < 3)
                    {
                        SetCultureQuizData(4);
                    }
                    else if (PlayerPrefs.GetInt("GreeceCult", 0) == 3)
                    {
                        PlayerPrefs.SetInt("Level3", (PlayerPrefs.GetInt("Level3")) + 1);
                        PlayerPrefs.Save();

                        quizCult.interactable = false;


                        quizPanel.SetActive(false);
                        levelCompletePanel.SetActive(true);
                        LevelCompleteText.text = PlayerPrefs.GetInt("GMscore").ToString();
                        Background.SetActive(true);
                        ReadQuestion.interactable = false;
                        GData.OffRoom[GData.SelectedRoom].RoomObj[selectedCategory - 1].IsComplete = true;
                        PersistentDataManager.instance.SaveData();
                    }
                }
            }
        }
        UpdateGameProgress();
    }

    #endregion
}
