using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager Instance;

    public GameData GData;
    public GameObject TimeHandler;
    public GameObject ScorePanal;
    public GameObject End_MatchBtn;
    public GameObject RestartBtn;
    public GameObject HomeBtn;
    public Text Player1NameText;
    public Text Player1RightAnserText;
    public Text Player1WrongAnserText;
    public Text Player1ScoreText;
    public Text Player1TimeText;
    public Text Player2NameText;
    public Text Player2RightAnserText;
    public Text Player2WrongAnserText;
    public Text Player2ScoreText;
    public Text Player2TimeText;
    public GameObject MatchDraw;
    public MainMenuTutorialHandler TutorialHandler;
    public GameObject Player1WinBadg;
    public GameObject Player2WinBadg;
    public GameObject[] Player1Avatars;
    public GameObject[] Player2Avatars;
    //public LoadManager loadingManager;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        TutorialHandler.EnableTask(7);
        TimeHandler.GetComponent<CountDown>().timeRemaining = GData.GameTime;
        Invoke("ActiveTimeHandler", .25f);
    }
    public void ActiveTimeHandler()
    {
        TimeHandler.SetActive(true);
    }
    public void PanalOpen(GameObject Panal)
    {
        Panal.SetActive(true);
    }
    public void Panalclose(GameObject Panal)
    {
        Panal.SetActive(false);
    }
    public void OnCompetitionComplete()
    {
        Debug.Log(GData.Player[0].Name);
        Debug.Log(GData.Player[1].Name);
        Player1Avatars[GData.Player[0].AvatarIndex - 1].SetActive(true);
        Player2Avatars[GData.Player[1].AvatarIndex - 1].SetActive(true);
        Player1NameText.text = GData.Player[0].Name;
        Player1RightAnserText.text = ": " + GData.Player[0].RightAnswer.ToString();
        Player1WrongAnserText.text = ": " + GData.Player[0].WrongAnswer.ToString();
        Player1ScoreText.text = ": " + (GData.Player[0].RightAnswer * 5).ToString();
        DisplayPlayer1Time(GData.Player[0].TimeTaken);
        Player2NameText.text = GData.Player[1].Name;
        Player2RightAnserText.text = ": " + GData.Player[1].RightAnswer.ToString();
        Player2WrongAnserText.text = ": " + GData.Player[1].WrongAnswer.ToString();
        Player2ScoreText.text = ": " + (GData.Player[1].RightAnswer * 5).ToString();
        DisplayPlayer2Time(GData.Player[1].TimeTaken);
        if (GData.Player[0].RightAnswer > GData.Player[1].RightAnswer)
        {
            Player1WinBadg.SetActive(true);
        }
        else if (GData.Player[0].RightAnswer < GData.Player[1].RightAnswer)
        {
            Player2WinBadg.SetActive(true);
        }
        else if (GData.Player[0].RightAnswer == GData.Player[1].RightAnswer)
        {
            MatchDraw.SetActive(true);
        }
        ScorePanal.SetActive(true);
    }
    public void DisplayPlayer1Time(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        Player1TimeText.text = ": " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void DisplayPlayer2Time(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        Player2TimeText.text = ": " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void OnHomeBtnClick()
    {
        GameManager.Instance.SelectedPlayer = 0;
        //loadingManager.levelLoad(0);
    }
    public void OnPauseBtnClcik()
    {
        Time.timeScale = 0;
        if (GameManager.Instance.IsMulti)
        {
            End_MatchBtn.SetActive(true);
            RestartBtn.SetActive(false);
            HomeBtn.SetActive(false);
        }
        else
        {
            End_MatchBtn.SetActive(false);
            RestartBtn.SetActive(true);
            HomeBtn.SetActive(true);
        }
    }
    public void OnResume()
    {
        Time.timeScale = 1f;
    }
}
