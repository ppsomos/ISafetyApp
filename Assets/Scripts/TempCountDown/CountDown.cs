using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public static CountDown Instance;

    public float timeRemaining;
    public static bool timerIsRunning = false;
    public TMP_Text timeText;
    public GameObject Canves;
    public GameObject tryagain_panal;
    public GameObject quiz_panal;
    public GameObject moveCanvas;
    public GameData GData;
    public UKManager UK;
    public BelgiumManager Bl;
    public GreeceManager GM;
    public MathManager MM;
    public PolandManager PM;
    public PortugalManager PrM;
    public TMP_Text score;

    bool start;
    private void Awake()
    {
        start = false;
        Instance = this;
    }
    private void Start()
    {
        Debug.Log("TimeRemaining" + timeRemaining);
        tryagain_panal.SetActive(false);
        Canves.SetActive(true);
       
        //if (PlayerPrefs.GetFloat("TimeRemaining") == 0)
        //{
        //    PlayerPrefs.SetFloat("TimeRemaining", timeRemaining);
        //    PlayerPrefs.Save();
        //}
        //else
        //{
        //    timeRemaining = PlayerPrefs.GetFloat("TimeRemaining");
        //}
        start = true;
        timerIsRunning = true;
    }
    void Update()
    {
        if(start)
        {
            if (timerIsRunning)
            {
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                    //PlayerPrefs.SetFloat("TimeRemaining", timeRemaining);
                    //PlayerPrefs.Save();

                    DisplayTime(timeRemaining);
                }
                else
                {
                    timerIsRunning = false;
                    Debug.Log("Time has run out!");
                    timeRemaining = 0;
                    timerIsRunning = false;
                    if (!GameManager.Instance.IsMulti)
                    {
                        Debug.Log("111");
                        if (GData.SelectedRoom == 0)
                        {
                            UK.LevelFail();
                            Debug.Log("2222");
                        }
                        else if (GData.SelectedRoom == 1)
                        {
                            Bl.LevelFail();
                            Debug.Log("3333");
                        }
                        else if (GData.SelectedRoom == 2)
                        {
                            GM.LevelFail();
                            Debug.Log("4444");
                        }
                        else if (GData.SelectedRoom == 3)
                        {
                            MM.LevelFail();
                            Debug.Log("5555");
                        }
                        else if (GData.SelectedRoom == 4)
                        {
                            PM.LevelFail();
                            Debug.Log("6666");
                        }
                        else if (GData.SelectedRoom == 5)
                        {
                            Debug.Log("7777");
                            PrM.LevelFail();
                        }
                        //tryagain_panal.SetActive(true);

                        //moveCanvas.SetActive(false);
                        //quiz_panal.SetActive(false);
                    }
                    else
                    {
                        Debug.Log("111");
                        if (GData.SelectedRoom == 0)
                        {
                            UK.CompleteRoom();
                            Debug.Log("2222");
                        }
                        else if (GData.SelectedRoom == 1)
                        {
                            Bl.CompleteRoom();
                            Debug.Log("3333");
                        }
                        else if (GData.SelectedRoom == 2)
                        {
                            GM.CompleteRoom();
                            Debug.Log("4444");
                        }
                        else if (GData.SelectedRoom == 3)
                        {
                            MM.CompleteRoom();
                            Debug.Log("5555");
                        }
                        else if (GData.SelectedRoom == 4)
                        {
                            PM.CompleteRoom();
                            Debug.Log("6666");
                        }
                        else if (GData.SelectedRoom == 5)
                        {
                            Debug.Log("7777");
                            PrM.CompleteRoom();
                        }
                    }
                }
            }
        }   
    }

   


    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}