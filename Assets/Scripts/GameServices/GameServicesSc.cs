//using EasyMobile;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SocialPlatforms;
//using UnityEngine.UI;

//public class GameServicesSc : MonoBehaviour
//{
//    private void Start()
//    {
//        // Unmanaged init
//        GameServices.Init();
//    }

//    // Subscribe to events in the OnEnable method of a MonoBehavior script
//    void OnEnable()
//    {
//        GameServices.UserLoginSucceeded += OnUserLoginSucceeded;
//        GameServices.UserLoginFailed += OnUserLoginFailed;
//    }

//    // Unsubscribe
//    void OnDisable()
//    {
//        GameServices.UserLoginSucceeded -= OnUserLoginSucceeded;
//        GameServices.UserLoginFailed -= OnUserLoginFailed;
//    }

//    // Event handlers
//    void OnUserLoginSucceeded()
//    {
//        Debug.Log("User logged in successfully.");
//    }

//    void OnUserLoginFailed()
//    {
//        Debug.Log("User login failed.");
//    }

//    public void ShowLeaderboard()
//    {
//        // Check for initialization before showing leaderboard UI
//        if (GameServices.IsInitialized())
//        {
//            GameServices.ShowLeaderboardUI();
//        }
//        else
//        {

//#if UNITY_ANDROID
//            GameServices.Init();    // start a new initialization process
//#elif UNITY_IOS
//    Debug.Log("Cannot show leaderboard UI: The user is not logged in to Game Center.");
//#endif
        
//        }
//    }











//    //void Awake()
//    //{
//    //    if (!RuntimeManager.IsInitialized())
//    //        RuntimeManager.Init();
//    //}


//    //public void showAcheivementboard()
//    //{
//    //    if (GameServices.IsInitialized())
//    //    {
//    //        GameServices.ShowAchievementsUI();
//    //    }
//    //}
//    //public void submitScoretoleaderboard()
//    //{
//    //    if (GameServices.IsInitialized())
//    //    {
//    //        GameServices.ReportScore(100, EM_GameServicesConstants.Leaderboard_Escape_Hero);
//    //    }
//    //}
//    //public void loadlocaluserscore()
//    //{
//    //    if (GameServices.IsInitialized())
//    //    {
//    //        GameServices.LoadLocalUserScore(EM_GameServicesConstants.Leaderboard_Escape_Hero, OnLocalUserScoreLoaded);
//    //    }
//    //}
//    //void OnLocalUserScoreLoaded(string leaderboardName, IScore score)
//    //{
//    //    if (score != null)
//    //    {
//    //        showuserscore.text = "Your score is: " + score.value;
//    //    }
//    //    else
//    //    {
//    //        showuserscore.text = "You don't have any score reported to leaderboard " + leaderboardName;
//    //    }
//    //}
//    //public void unlockAcheivement()
//    //{
//    //    if (GameServices.IsInitialized())
//    //    {
//    //        GameServices.UnlockAchievement(EM_GameServicesConstants.Achievement_testacheivement);
//    //    }
//    //}
//}
