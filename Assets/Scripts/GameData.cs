using System;
using UnityEngine;
[CreateAssetMenu(fileName = "GData", menuName = "GameData")]
public class GameData : ScriptableObject
{
    public bool IsFirstTime;
    public bool IsSound;
    public bool IsMusic;
    public bool tutorialFinished;
    public bool M_tutorialFinished;
    public bool StartTutorial;
    public bool M_StartTutorial;
    public int SelectedRoom;
    public int DifficultyLevel;
    public int SelectedLanguage;
    public int UnlockedLevel;
    public int MultiPlayerLevelUnlocked;
    public float GameTime;
    [Header("UK Manager")]
    public int UKhistoryQuizIndex;
    public int UKgeographyQuizIndex;
    public int UKfoodQuizIndex;
    public int UKcultureQuizIndex;
    [Header("Belgium Manager")]
    public int BLhistoryQuizIndex;
    public int BLgeographyQuizIndex;
    public int BLfoodQuizIndex;
    public int BLcultureQuizIndex;
    [Header("Greece Manager")]
    public int GRhistoryQuizIndex;
    public int GRgeographyQuizIndex;
    public int GRfoodQuizIndex;
    public int GRcultureQuizIndex;
    [Header("Math Manager")]
    public int MhistoryQuizIndex;
    public int MgeographyQuizIndex;
    public int MfoodQuizIndex;
    public int McultureQuizIndex;
    [Header("Poland Bullying")]
    public int PLhistoryQuizIndex;
    public int PLgeographyQuizIndex;
    public int PLfoodQuizIndex;
    public int PLcultureQuizIndex;
    [Header("Portagual Manager")]
    public int PRhistoryQuizIndex;
    public int PRgeographyQuizIndex;
    public int PRfoodQuizIndex;
    public int PRcultureQuizIndex;
    public int RightAnswer;
    public int WrongAnswer;
    public MultiPlayer[] Player;
    public GameRoom[] Room;
    public OfflineRoom[] OffRoom;
    public Translations[] AvailableLanguages;
    public GameLanguage[] QuestionLanguage;
    public OfflineTutorial[] tutorial;
    public MultiplayerTutorial[] M_tutorial;
}


[Serializable]
public class Translations
{
    public string Name;
    public string StartText;
    public string PlaywithfriendsText;
    public string RateusText;
}

[Serializable]
public class MultiPlayer
{
    public string Name;
    public int AvatarIndex;
    public int WrongAnswer;
    public int RightAnswer;
    public float TimeTaken;
    public bool IsComplete;
}
[Serializable]
public class GameRoom
{
    public string RoomNam;
    public int No_Of_Obj_Complete;
    public HistoryQuestion[] HisQ;
    public GeographicQuestion[] GeoQ;
    public FoodQuestion[] FoodQ;
    public CultuerQuestion[] CulQ;
}
[Serializable]
public class HistoryQuestion
{
    public string Name;
    public int TotalQuestion;
    public int AnswerGiven;
    public bool IsComplte;
}
[Serializable]
public class GeographicQuestion
{
    public string Name;
    public int TotalQuestion;
    public int AnswerGiven;
    public bool IsComplte;
}
[Serializable]
public class FoodQuestion
{
    public string Name;
    public int TotalQuestion;
    public int AnswerGiven;
    public bool IsComplte;
}
[Serializable]
public class CultuerQuestion
{
    public string Name;
    public int TotalQuestion;
    public int AnswerGiven;
    public bool IsComplte;
}
[Serializable]
public class GameLanguage
{
    public string LanguageName;
    public string[] Question;
    public string[] Option_A;
    public string[] Option_B;
    public string[] Option_C;
    public string[] Option_D;
    public int[] Right_Answer;
}
[Serializable]
public class OfflineRoom
{
    public string Name;
    public Obj[] RoomObj;
}
[Serializable]
public class Obj
{
    public string Name;
    public bool IsComplete;
}
[Serializable]
public class OfflineTutorial
{
    public bool IsComplete;
}
[Serializable]
public class MultiplayerTutorial
{
    public bool IsComplete;
}
// Room Total Question
// Room Total Question Answer Given
// Geo Total Question
// Geo Total Ansewer Question
// Hist Total Question
// Hist Total Ansewer Question
// Food Total Question
// Food Total Ansewer Question
// Culture Total Question
// Culture Total Ansewer Question
