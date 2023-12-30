using Newtonsoft.Json;
using UnityEngine;

public class PersistentDataManager : MonoBehaviour
{
    public GameData gameData;

    #region Singleton
    public static PersistentDataManager instance;
    void Awake()
    {
        GetInstance();
    }

    void GetInstance()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion

    void Start()
    {
        LoadData();
        // PlayerPrefs.DeleteAll();
    }

    void OnApplicationQuit()
    {
        SaveData();
    }

    public void SaveData()
    {
        string gameDataString = JsonConvert.SerializeObject(gameData);
        PlayerPrefs.SetString("GameData", gameDataString);
        print("GameData Saved In PlayerPrefs: " + PlayerPrefs.GetString("GameData"));
    }

    public void LoadData()
    {
        string gameDataString = PlayerPrefs.GetString("GameData");
        GameData gameDataFromPlayerPrefs = JsonConvert.DeserializeObject<GameData>(gameDataString);
        if (gameDataFromPlayerPrefs == null)
        {
            print("Game is played first time. No GameData found.");
            return;
        }
        print("GameData Loaded From PlayerPrefs");


        gameData.IsFirstTime = gameDataFromPlayerPrefs.IsFirstTime;
        gameData.IsSound = gameDataFromPlayerPrefs.IsSound;
        gameData.IsMusic = gameDataFromPlayerPrefs.IsMusic;
        gameData.tutorialFinished = gameDataFromPlayerPrefs.tutorialFinished;
        gameData.StartTutorial = gameDataFromPlayerPrefs.StartTutorial;
        gameData.M_StartTutorial = gameDataFromPlayerPrefs.M_StartTutorial;
        gameData.M_tutorialFinished = gameDataFromPlayerPrefs.M_tutorialFinished;
        gameData.SelectedLanguage = gameDataFromPlayerPrefs.SelectedLanguage;
        gameData.DifficultyLevel = gameDataFromPlayerPrefs.DifficultyLevel;
        gameData.SelectedRoom = gameDataFromPlayerPrefs.SelectedRoom;
        gameData.MultiPlayerLevelUnlocked = gameDataFromPlayerPrefs.MultiPlayerLevelUnlocked;
        gameData.GameTime = gameDataFromPlayerPrefs.GameTime;
        gameData.UnlockedLevel = gameDataFromPlayerPrefs.UnlockedLevel;
        gameData.RightAnswer = gameDataFromPlayerPrefs.RightAnswer;
        gameData.WrongAnswer = gameDataFromPlayerPrefs.WrongAnswer;
        //UK Manager
        gameData.UKhistoryQuizIndex = gameDataFromPlayerPrefs.UKhistoryQuizIndex;
        gameData.UKgeographyQuizIndex = gameDataFromPlayerPrefs.UKgeographyQuizIndex;
        gameData.UKfoodQuizIndex = gameDataFromPlayerPrefs.UKfoodQuizIndex;
        gameData.UKcultureQuizIndex = gameDataFromPlayerPrefs.UKcultureQuizIndex;
        //Belgium Manager
        gameData.BLhistoryQuizIndex = gameDataFromPlayerPrefs.BLhistoryQuizIndex;
        gameData.BLgeographyQuizIndex = gameDataFromPlayerPrefs.BLgeographyQuizIndex;
        gameData.BLfoodQuizIndex = gameDataFromPlayerPrefs.BLfoodQuizIndex;
        gameData.BLcultureQuizIndex = gameDataFromPlayerPrefs.BLcultureQuizIndex;
        //Greece Manager
        gameData.GRhistoryQuizIndex = gameDataFromPlayerPrefs.GRhistoryQuizIndex;
        gameData.GRgeographyQuizIndex = gameDataFromPlayerPrefs.GRgeographyQuizIndex;
        gameData.GRfoodQuizIndex = gameDataFromPlayerPrefs.GRfoodQuizIndex;
        gameData.GRcultureQuizIndex = gameDataFromPlayerPrefs.GRcultureQuizIndex;
        //Math Manager
        gameData.MhistoryQuizIndex = gameDataFromPlayerPrefs.MhistoryQuizIndex;
        gameData.MgeographyQuizIndex = gameDataFromPlayerPrefs.MgeographyQuizIndex;
        gameData.MfoodQuizIndex = gameDataFromPlayerPrefs.MfoodQuizIndex;
        gameData.McultureQuizIndex = gameDataFromPlayerPrefs.McultureQuizIndex;
        //Poland Bullying
        gameData.PLhistoryQuizIndex = gameDataFromPlayerPrefs.PLhistoryQuizIndex;
        gameData.PLgeographyQuizIndex = gameDataFromPlayerPrefs.PLgeographyQuizIndex;
        gameData.PLfoodQuizIndex = gameDataFromPlayerPrefs.PLfoodQuizIndex;
        gameData.PLcultureQuizIndex = gameDataFromPlayerPrefs.PLcultureQuizIndex;
        //Portagual Manager
        gameData.PRhistoryQuizIndex = gameDataFromPlayerPrefs.PRhistoryQuizIndex;
        gameData.PRgeographyQuizIndex = gameDataFromPlayerPrefs.PRgeographyQuizIndex;
        gameData.PRfoodQuizIndex = gameDataFromPlayerPrefs.PRfoodQuizIndex;
        gameData.PRcultureQuizIndex = gameDataFromPlayerPrefs.PRcultureQuizIndex;
        for(int i=0; i< gameData.tutorial.Length;i++)
        {
            gameData.tutorial[i].IsComplete = gameDataFromPlayerPrefs.tutorial[i].IsComplete;
        }
        for (int i = 0; i < gameData.Player.Length; i++)
        {
            gameData.Player[i].Name = gameDataFromPlayerPrefs.Player[i].Name;
            gameData.Player[i].TimeTaken = gameDataFromPlayerPrefs.Player[i].TimeTaken;
            gameData.Player[i].WrongAnswer = gameDataFromPlayerPrefs.Player[i].WrongAnswer;
            gameData.Player[i].RightAnswer = gameDataFromPlayerPrefs.Player[i].RightAnswer;
        }
        for (int i = 0; i < gameData.Room.Length; i++)
        {
            gameData.Room[i].No_Of_Obj_Complete = gameDataFromPlayerPrefs.Room[i].No_Of_Obj_Complete;
            gameData.Room[i].HisQ[0].AnswerGiven = gameDataFromPlayerPrefs.Room[i].HisQ[0].AnswerGiven;
            gameData.Room[i].HisQ[0].IsComplte = gameDataFromPlayerPrefs.Room[i].HisQ[0].IsComplte;
            gameData.Room[i].FoodQ[0].AnswerGiven = gameDataFromPlayerPrefs.Room[i].FoodQ[0].AnswerGiven;
            gameData.Room[i].FoodQ[0].IsComplte = gameDataFromPlayerPrefs.Room[i].FoodQ[0].IsComplte;
            gameData.Room[i].CulQ[0].AnswerGiven = gameDataFromPlayerPrefs.Room[i].CulQ[0].AnswerGiven;
            gameData.Room[i].CulQ[0].IsComplte = gameDataFromPlayerPrefs.Room[i].CulQ[0].IsComplte;
            gameData.Room[i].GeoQ[0].AnswerGiven = gameDataFromPlayerPrefs.Room[i].GeoQ[0].AnswerGiven;
            gameData.Room[i].GeoQ[0].IsComplte = gameDataFromPlayerPrefs.Room[i].GeoQ[0].IsComplte;
        }
        for (int i = 0; i < gameData.OffRoom.Length; i++)
        {
            for (int j = 0; j < gameData.OffRoom[i].RoomObj.Length; j++)
            {
                gameData.OffRoom[i].RoomObj[j].IsComplete = gameDataFromPlayerPrefs.OffRoom[i].RoomObj[j].IsComplete;
            }
        }
    }
}
