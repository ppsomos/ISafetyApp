using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashScreenHandler : MonoBehaviour
{
    public Slider FillSlider;
    public GameData GData;
    // Start is called before the first frame update
    void Start()
    {
       Invoke("FillSLider",2f);
       Invoke("CheckForFirstTime", 1f);
    }
    public void CheckForFirstTime()
    {
        if (GData.IsFirstTime)
        {
            GameManager.Instance.PlayFirstTimeGame = true;
            GData.IsFirstTime = false;
            GData.IsSound = true;
            GData.IsMusic = true;
            GData.StartTutorial = false;
            GData.M_StartTutorial = false;
            GData.tutorialFinished = false;
            GData.M_tutorialFinished = false;
            GData.SelectedLanguage = 0;
            GData.DifficultyLevel = 0;
            GData.UnlockedLevel = 0;
            GData.MultiPlayerLevelUnlocked = 6;
            GData.SelectedRoom = 0;
            GData.RightAnswer = 0;
            GData.WrongAnswer = 0;
            //UK Manager
            GData.UKhistoryQuizIndex = 0;
            GData.UKgeographyQuizIndex = 0;
            GData.UKfoodQuizIndex = 0;
            GData.UKcultureQuizIndex = 0;
            //Belgium Manager
            GData.BLhistoryQuizIndex = 0;
            GData.BLgeographyQuizIndex = 0;
            GData.BLfoodQuizIndex = 0;
            GData.BLcultureQuizIndex = 0;
            //Greece Manager
            GData.GRhistoryQuizIndex = 0;
            GData.GRgeographyQuizIndex = 0;
            GData.GRfoodQuizIndex = 0;
            GData.GRcultureQuizIndex = 0;
            //Math Manager
            GData.MhistoryQuizIndex = 0;
            GData.MgeographyQuizIndex = 0;
            GData.MfoodQuizIndex = 0;
            GData.McultureQuizIndex = 0;
            //Poland Bullying
            GData.PLhistoryQuizIndex = 0;
            GData.PLgeographyQuizIndex = 0;
            GData.PLfoodQuizIndex = 0;
            GData.PLcultureQuizIndex = 0;
            //Portagual Manager
            GData.PRhistoryQuizIndex = 0;
            GData.PRgeographyQuizIndex = 0;
            GData.PRfoodQuizIndex = 0;
            GData.PRcultureQuizIndex = 0;
            for (int i = 0; i < GData.tutorial.Length; i++)
            {
                GData.tutorial[i].IsComplete = false;
                PersistentDataManager.instance.SaveData();
            }
            for (int i = 0; i < GData.M_tutorial.Length; i++)
            {
                GData.M_tutorial[i].IsComplete = false;
                PersistentDataManager.instance.SaveData();
            }
            PlayerPrefs.SetInt("LevelUnlock", 0);
            PlayerPrefs.Save();
            PersistentDataManager.instance.SaveData();
        }
        else
        {
            GameManager.Instance.PlayFirstTimeGame = false;
        }
    }
   public void FillSLider()
    {
        GameManager.Instance.isSplash = true; 
        StartCoroutine(SliderFill());
    }
    IEnumerator SliderFill()
    {
        yield return new WaitForSeconds(0.075f);
        if (FillSlider.value < 1f)
        {
            FillSlider.value +=Random.Range(0.015f, 0.025f);
            StartCoroutine(SliderFill());
        }
        else
        {
           
            StopAllCoroutines();
            SceneManager.LoadScene(1);
        }
    }
}
