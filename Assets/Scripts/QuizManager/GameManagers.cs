using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManagers : MonoBehaviour
{
    public Text PlayerName;
    public GameObject PlayerNameobj;
    public GameObject[] roomObject;
    // public CountDown countDown;

    public GameObject[] levelPos;
    public GameObject player;
    public GameObject ScoreUI;
    public static int score;
    public Text ScoreText;

    bool istrue = false;
    public Text totalanswer;
    public Text showrelatedquiztext;

    public Text Countrytext;
    public GameData GData;
    private bool Ischaracter;
    public GameObject PlayerController;
    [SerializeField] private GameObject CF2_FPP_Rig;
    private void Start()
    {
        istrue = false;
        if (GameManager.Instance.IsMulti)
        {
            //GameManager.Instance.SelectedPlayer = 0;
            PlayerName.text = GData.Player[GameManager.Instance.SelectedPlayer].Name;
            PlayerNameobj.gameObject.SetActive(true);
            //ScoreUI.SetActive(false);
        }
        else
        {
            PlayerNameobj.gameObject.SetActive(false);
            //ScoreUI.SetActive(true);
        }
    }
    void Update()
    {
        if (!PlayerPrefs.HasKey("Score11"))
        {
            PlayerPrefs.SetInt("Score11", 0);

            PlayerPrefs.SetInt("UKscore", 0);
            PlayerPrefs.SetInt("POMscore", 0);
            PlayerPrefs.SetInt("BMscore", 0);
            PlayerPrefs.SetInt("GMscore", 0);
            PlayerPrefs.SetInt("MMscore", 0);
            PlayerPrefs.SetInt("PMscore", 0);
        }

        if (PlayerPrefs.GetInt("LevelM1") == 0)
        {
            PlayerPrefs.SetInt("CurrentLevel", 1);
            //Uk
        }
        else if (PlayerPrefs.GetInt("LevelM2") == 0)
        {
            PlayerPrefs.SetInt("CurrentLevel", 2);
            //Belgium
        }
        else if (PlayerPrefs.GetInt("LevelM3") == 0)
        {
            PlayerPrefs.SetInt("CurrentLevel", 3);
            //greece
        }
        else if (PlayerPrefs.GetInt("LevelM4") == 0)
        {
            PlayerPrefs.SetInt("CurrentLevel", 4);
            //polanad
        }
        else if (PlayerPrefs.GetInt("LevelM5") == 0)
        {
            PlayerPrefs.SetInt("CurrentLevel", 5);
            //portagual
        }
        else
        {
            PlayerPrefs.SetInt("CurrentLevel", 1);
        }


        ////Debug.Log("currentlevel" + PlayerPrefs.GetInt("CurrentLevel"));
        if (PlayerPrefs.GetInt("levelcurrent") == 1)
        {
            if (istrue == false)
            {
                //Debug.Log("Fake News Room");
                //Debug.Log("check lvl" + PlayerPrefs.GetInt("levelcurrent"));
                //   Countrytext.text = "Welcome to the United Kingdom";
                istrue = true;
                Instantiate(player, levelPos[(PlayerPrefs.GetInt("levelcurrent") - 1)].transform.position, Quaternion.identity);
                StartCoroutine(Waitcountrytext());

                roomObject[(PlayerPrefs.GetInt("levelcurrent") - 1)].SetActive(true);
              //  countDown.timeRemaining = GData.GameTime;
               // CountDown.timerIsRunning = true;
               // PlayerPrefs.SetFloat("TimeRemaining", countDown.timeRemaining);
                PlayerPrefs.Save();
            }

        }
        else if (PlayerPrefs.GetInt("levelcurrent") == 2)
        {
            if (istrue == false)
            {
                //Debug.Log("Addiction Manager");
                //Debug.Log("check lvl" + PlayerPrefs.GetInt("levelcurrent"));
                //   Countrytext.text = "Welcome to Addiction Room";
                istrue = true;
                Instantiate(player, levelPos[(PlayerPrefs.GetInt("levelcurrent") - 1)].transform.position, Quaternion.identity);
                StartCoroutine(Waitcountrytext());
                roomObject[(PlayerPrefs.GetInt("levelcurrent") - 1)].SetActive(true);

                //countDown.timeRemaining = GData.GameTime;
               // CountDown.timerIsRunning = true;
               // PlayerPrefs.SetFloat("TimeRemaining", countDown.timeRemaining);
                PlayerPrefs.Save();
            }

        }
        else if (PlayerPrefs.GetInt("levelcurrent") == 3)
        {
            if (istrue == false)
            {
                //Debug.Log("Grooming Manager");
                //Debug.Log("check lvl" + PlayerPrefs.GetInt("levelcurrent"));
                //       Countrytext.text = "Welcome to Greece";
                istrue = true;
                Instantiate(player, levelPos[(PlayerPrefs.GetInt("levelcurrent") - 1)].transform.position, Quaternion.identity);
                StartCoroutine(Waitcountrytext());
                roomObject[(PlayerPrefs.GetInt("levelcurrent") - 1)].SetActive(true);

               // countDown.timeRemaining = GData.GameTime;
               // CountDown.timerIsRunning = true;
               // PlayerPrefs.SetFloat("TimeRemaining", countDown.timeRemaining);
                PlayerPrefs.Save();
            }

        }
        else if (PlayerPrefs.GetInt("levelcurrent") == 4)
        {
            if (istrue == false)
            {
                //Debug.Log("Math Manager");
                //Debug.Log("check lvl" + PlayerPrefs.GetInt("levelcurrent"));
                // Countrytext.text = "Welcome to Poland";
                istrue = true;
                Instantiate(player, levelPos[(PlayerPrefs.GetInt("levelcurrent") - 1)].transform.position, Quaternion.identity);
                StartCoroutine(Waitcountrytext());
                roomObject[(PlayerPrefs.GetInt("levelcurrent") - 1)].SetActive(true);

               // countDown.timeRemaining = GData.GameTime;
              //  CountDown.timerIsRunning = true;
               // PlayerPrefs.SetFloat("TimeRemaining", countDown.timeRemaining);
                PlayerPrefs.Save();
            }

        }
        else if (PlayerPrefs.GetInt("levelcurrent") == 5)
        {
            if (istrue == false)
            {
                //Debug.Log("Cyber Bullying");
                //Debug.Log("check lvl" + PlayerPrefs.GetInt("levelcurrent"));
                //   Countrytext.text = "Welcome to Portugal";
                istrue = true;
                Instantiate(player, levelPos[(PlayerPrefs.GetInt("levelcurrent") - 1)].transform.position, Quaternion.identity);
                StartCoroutine(Waitcountrytext());
                roomObject[(PlayerPrefs.GetInt("levelcurrent") - 1)].SetActive(true);


               // countDown.timeRemaining = GData.GameTime;
                //CountDown.timerIsRunning = true;
               // PlayerPrefs.SetFloat("TimeRemaining", countDown.timeRemaining);
                PlayerPrefs.Save();
            }

        }
        else if (PlayerPrefs.GetInt("levelcurrent") == 6)
        {
            if (istrue == false)
            {
                //Debug.Log("Phishing");
                //Debug.Log("check lvl" + PlayerPrefs.GetInt("levelcurrent"));
                //   Countrytext.text = "Welcome to Portugal";
                istrue = true;
                Instantiate(player, levelPos[(PlayerPrefs.GetInt("levelcurrent") - 1)].transform.position, Quaternion.identity);
                StartCoroutine(Waitcountrytext());
                roomObject[(PlayerPrefs.GetInt("levelcurrent") - 1)].SetActive(true);


               // countDown.timeRemaining = GData.GameTime;
               // CountDown.timerIsRunning = true;
               // PlayerPrefs.SetFloat("TimeRemaining", countDown.timeRemaining);
                PlayerPrefs.Save();
            }

        }
        //------Wait for Country Text-----------

        IEnumerator Waitcountrytext()
        {
            yield return new WaitForSeconds(1f);
            Countrytext.text = "";
        }




        // For Total Score text
        if (!GameManager.Instance.IsMulti)
        {
            if (PlayerPrefs.GetInt("levelcurrent") == 1)
            {
                totalanswer.text = PlayerPrefs.GetInt("UKHist") + PlayerPrefs.GetInt("UKGeo") + PlayerPrefs.GetInt("UKFood") + PlayerPrefs.GetInt("UKCult") + "/12";
                ScoreText.text = PlayerPrefs.GetInt("UKscore").ToString();

            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 2)
            {
                totalanswer.text = PlayerPrefs.GetInt("BelgiumHist") + PlayerPrefs.GetInt("BelgiumGeo") + PlayerPrefs.GetInt("BelgiumFood") + PlayerPrefs.GetInt("BelgiumCult") + "/12";
                ScoreText.text = PlayerPrefs.GetInt("BMscore").ToString();

            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 3)
            {
                totalanswer.text = PlayerPrefs.GetInt("GreeceHist") + PlayerPrefs.GetInt("GreeceGeo") + PlayerPrefs.GetInt("GreeceFood") + PlayerPrefs.GetInt("GreeceCult") + "/12";
                ScoreText.text = PlayerPrefs.GetInt("GMscore").ToString();

            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 4)
            {
                ////Debug.Log("Math");
                ////Debug.Log(PlayerPrefs.GetInt("MathGeo") + "MathGeo");
                totalanswer.text = PlayerPrefs.GetInt("MathHist") + PlayerPrefs.GetInt("MathGeo") + PlayerPrefs.GetInt("MathFood") + PlayerPrefs.GetInt("MathCult") + "/12";
                ScoreText.text = PlayerPrefs.GetInt("MMscore").ToString();



            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 5)
            {
                totalanswer.text = PlayerPrefs.GetInt("PolandHist") + PlayerPrefs.GetInt("PolandGeo") + PlayerPrefs.GetInt("PolandFood") + PlayerPrefs.GetInt("PolandCult") + "/12";
                ScoreText.text = PlayerPrefs.GetInt("PMscore").ToString();

            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 6)
            {
                totalanswer.text = PlayerPrefs.GetInt("PortugalHist") + PlayerPrefs.GetInt("PortugalGeo") + PlayerPrefs.GetInt("PortugalFood") + PlayerPrefs.GetInt("PortugalCult") + "/12";
                ScoreText.text = PlayerPrefs.GetInt("POMscore").ToString();

            }
        }
        else
        {
            //if (PlayerPrefs.GetInt("levelcurrent") == 1)
            //{
            //    // totalanswer.text = PlayerPrefs.GetInt("UKHist") + PlayerPrefs.GetInt("UKGeo") + PlayerPrefs.GetInt("UKFood") + PlayerPrefs.GetInt("UKCult") + "/12";

            ScoreText.text = (GData.Player[GameManager.Instance.SelectedPlayer].RightAnswer * 5).ToString();

            // }
            //else if (PlayerPrefs.GetInt("levelcurrent") == 2)
            //{
            // totalanswer.text = PlayerPrefs.GetInt("BelgiumHist") + PlayerPrefs.GetInt("BelgiumGeo") + PlayerPrefs.GetInt("BelgiumFood") + PlayerPrefs.GetInt("BelgiumCult") + "/12";
            //  ScoreText.text = PlayerPrefs.GetInt("BMscore").ToString();

            //}
            //else if (PlayerPrefs.GetInt("levelcurrent") == 3)
            //{
            //   // totalanswer.text = PlayerPrefs.GetInt("GreeceHist") + PlayerPrefs.GetInt("GreeceGeo") + PlayerPrefs.GetInt("GreeceFood") + PlayerPrefs.GetInt("GreeceCult") + "/12";
            //    ScoreText.text = PlayerPrefs.GetInt("GMscore").ToString();

            //}
            //else if (PlayerPrefs.GetInt("levelcurrent") == 4)
            //{
            //    ////Debug.Log("Math");
            //    ////Debug.Log(PlayerPrefs.GetInt("MathGeo") + "MathGeo");
            //    //totalanswer.text = PlayerPrefs.GetInt("MathHist") + PlayerPrefs.GetInt("MathGeo") + PlayerPrefs.GetInt("MathFood") + PlayerPrefs.GetInt("MathCult") + "/12";
            //    ScoreText.text = PlayerPrefs.GetInt("MMscore").ToString();



            //}
            //else if (PlayerPrefs.GetInt("levelcurrent") == 5)
            //{
            //   // totalanswer.text = PlayerPrefs.GetInt("PolandHist") + PlayerPrefs.GetInt("PolandGeo") + PlayerPrefs.GetInt("PolandFood") + PlayerPrefs.GetInt("PolandCult") + "/12";
            //    ScoreText.text = PlayerPrefs.GetInt("PMscore").ToString();

            //}
            //else if (PlayerPrefs.GetInt("levelcurrent") == 6)
            //{
            //   // totalanswer.text = PlayerPrefs.GetInt("PortugalHist") + PlayerPrefs.GetInt("PortugalGeo") + PlayerPrefs.GetInt("PortugalFood") + PlayerPrefs.GetInt("PortugalCult") + "/12";
            //    ScoreText.text = PlayerPrefs.GetInt("POMscore").ToString();

            //}
        }


        //----------------Uk Manager//--------

        if (!GameManager.Instance.IsMulti)
        {
            if (PlayerPrefs.GetInt("levelcurrent") == 1 && UKManager.selectedCategory == 1)
            {
                showrelatedquiztext.text = PlayerPrefs.GetInt("UKHist") + "/3";
            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 1 && UKManager.selectedCategory == 2)
            {
                showrelatedquiztext.text = PlayerPrefs.GetInt("UKGeo") + "/3";
            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 1 && UKManager.selectedCategory == 3)
            {
                showrelatedquiztext.text = PlayerPrefs.GetInt("UKFood") + "/3";
            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 1 && UKManager.selectedCategory == 4)
            {
                showrelatedquiztext.text = PlayerPrefs.GetInt("UKCult") + "/3";
            }
        }
        else
        {
            if (PlayerPrefs.GetInt("levelcurrent") == 1 && UKManager.selectedCategory == 1)
            {
                showrelatedquiztext.text = GData.Room[0].HisQ[0].AnswerGiven + "/3";
            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 1 && UKManager.selectedCategory == 2)
            {
                showrelatedquiztext.text = GData.Room[0].GeoQ[0].AnswerGiven + "/3";
            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 1 && UKManager.selectedCategory == 3)
            {
                showrelatedquiztext.text = GData.Room[0].FoodQ[0].AnswerGiven + "/3";
            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 1 && UKManager.selectedCategory == 4)
            {
                showrelatedquiztext.text = GData.Room[0].CulQ[0].AnswerGiven + "/3";
            }
        }
        //----------------Belgium//--------
        if (!GameManager.Instance.IsMulti)
        {
            if (PlayerPrefs.GetInt("levelcurrent") == 2 && BelgiumManager.selectedCategory == 1)
            {
                showrelatedquiztext.text = PlayerPrefs.GetInt("BelgiumHist") + "/3";
            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 2 && BelgiumManager.selectedCategory == 2)
            {
                showrelatedquiztext.text = PlayerPrefs.GetInt("BelgiumGeo") + "/3";
            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 2 && BelgiumManager.selectedCategory == 3)
            {
                showrelatedquiztext.text = PlayerPrefs.GetInt("BelgiumFood") + "/3";
            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 2 && BelgiumManager.selectedCategory == 4)
            {

                showrelatedquiztext.text = PlayerPrefs.GetInt("BelgiumCult") + "/3";
            }
        }
        else
        {
            if (PlayerPrefs.GetInt("levelcurrent") == 2 && BelgiumManager.selectedCategory == 1)
            {
                showrelatedquiztext.text = GData.Room[1].HisQ[0].AnswerGiven + "/3";
            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 2 && BelgiumManager.selectedCategory == 2)
            {
                showrelatedquiztext.text = GData.Room[1].GeoQ[0].AnswerGiven + "/3";
            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 2 && BelgiumManager.selectedCategory == 3)
            {
                showrelatedquiztext.text = GData.Room[1].FoodQ[0].AnswerGiven + "/3";
            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 2 && BelgiumManager.selectedCategory == 4)
            {
                showrelatedquiztext.text = GData.Room[1].CulQ[0].AnswerGiven + "/3";
            }
        }




        //----------------Greece//--------

        if (!GameManager.Instance.IsMulti)
        {
            if (PlayerPrefs.GetInt("levelcurrent") == 3 && GreeceManager.selectedCategory == 1)
            {
                showrelatedquiztext.text = PlayerPrefs.GetInt("GreeceHist") + "/3";
            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 3 && GreeceManager.selectedCategory == 2)
            {
                showrelatedquiztext.text = PlayerPrefs.GetInt("GreeceGeo") + "/3";
            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 3 && GreeceManager.selectedCategory == 3)
            {
                showrelatedquiztext.text = PlayerPrefs.GetInt("GreeceFood") + "/3";
            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 3 && GreeceManager.selectedCategory == 4)
            {
                showrelatedquiztext.text = PlayerPrefs.GetInt("GreeceCult") + "/3";
            }
        }
        else
        {
            if (PlayerPrefs.GetInt("levelcurrent") == 3 && GreeceManager.selectedCategory == 1)
            {
                showrelatedquiztext.text = GData.Room[2].HisQ[0].AnswerGiven + "/3";
            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 3 && GreeceManager.selectedCategory == 2)
            {
                showrelatedquiztext.text = GData.Room[2].GeoQ[0].AnswerGiven + "/3";
            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 3 && GreeceManager.selectedCategory == 3)
            {
                showrelatedquiztext.text = GData.Room[2].FoodQ[0].AnswerGiven + "/3";
            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 3 && GreeceManager.selectedCategory == 4)
            {
                showrelatedquiztext.text = GData.Room[2].CulQ[0].AnswerGiven + "/3";
            }
        }


        //----------------Math//--------
        if (!GameManager.Instance.IsMulti)
        {
            if (PlayerPrefs.GetInt("levelcurrent") == 4 && MathManager.selectedCategory == 1)
            {
                showrelatedquiztext.text = PlayerPrefs.GetInt("MathHist") + "/3";
            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 4 && MathManager.selectedCategory == 2)
            {
                showrelatedquiztext.text = PlayerPrefs.GetInt("MathGeo") + "/3";
            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 4 && MathManager.selectedCategory == 3)
            {
                showrelatedquiztext.text = PlayerPrefs.GetInt("MathFood") + "/3";
            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 4 && MathManager.selectedCategory == 4)
            {
                showrelatedquiztext.text = PlayerPrefs.GetInt("MathCult") + "/3";
            }
        }
        else
        {
            if (PlayerPrefs.GetInt("levelcurrent") == 4 && MathManager.selectedCategory == 1)
            {
                showrelatedquiztext.text = GData.Room[3].HisQ[0].AnswerGiven + "/3";
            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 4 && MathManager.selectedCategory == 2)
            {
                showrelatedquiztext.text = GData.Room[3].GeoQ[0].AnswerGiven + "/3";
            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 4 && MathManager.selectedCategory == 3)
            {
                showrelatedquiztext.text = GData.Room[3].FoodQ[0].AnswerGiven + "/3";
            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 4 && MathManager.selectedCategory == 4)
            {
                showrelatedquiztext.text = GData.Room[3].CulQ[0].AnswerGiven + "/3";
            }
        }



        //----------------Cyber Bullying//--------
        if (!GameManager.Instance.IsMulti)
        {
            if (PlayerPrefs.GetInt("levelcurrent") == 5 && PolandManager.selectedCategory == 1)
            {
                showrelatedquiztext.text = PlayerPrefs.GetInt("PolandHist") + "/3";
            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 5 && PolandManager.selectedCategory == 2)
            {
                showrelatedquiztext.text = PlayerPrefs.GetInt("PolandGeo") + "/3";
            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 5 && PolandManager.selectedCategory == 3)
            {
                showrelatedquiztext.text = PlayerPrefs.GetInt("PolandFood") + "/3";
            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 5 && PolandManager.selectedCategory == 4)
            {
                showrelatedquiztext.text = PlayerPrefs.GetInt("PolandCult") + "/3";
            }
        }
        else
        {
            if (PlayerPrefs.GetInt("levelcurrent") == 5 && PolandManager.selectedCategory == 1)
            {
                showrelatedquiztext.text = GData.Room[4].HisQ[0].AnswerGiven + "/3";
            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 5 && PolandManager.selectedCategory == 2)
            {
                showrelatedquiztext.text = GData.Room[4].GeoQ[0].AnswerGiven + "/3";
            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 5 && PolandManager.selectedCategory == 3)
            {
                showrelatedquiztext.text = GData.Room[4].FoodQ[0].AnswerGiven + "/3";
            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 5 && PolandManager.selectedCategory == 4)
            {
                showrelatedquiztext.text = GData.Room[4].CulQ[0].AnswerGiven + "/3";
            }
        }


        //----------------Portagual//--------

        if (!GameManager.Instance.IsMulti)
        {
            if (PlayerPrefs.GetInt("levelcurrent") == 6 && PortugalManager.selectedCategory == 1)
            {
                showrelatedquiztext.text = PlayerPrefs.GetInt("PortugalHist") + "/3";
            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 6 && PortugalManager.selectedCategory == 2)
            {
                showrelatedquiztext.text = PlayerPrefs.GetInt("PortugalGeo") + "/3";
            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 6 && PortugalManager.selectedCategory == 3)
            {
                showrelatedquiztext.text = PlayerPrefs.GetInt("PortugalFood") + "/3";
            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 6 && PortugalManager.selectedCategory == 4)
            {
                showrelatedquiztext.text = PlayerPrefs.GetInt("PortugalCult") + "/3";

            }
        }
        else
        {
            if (PlayerPrefs.GetInt("levelcurrent") == 6 && PortugalManager.selectedCategory == 1)
            {
                showrelatedquiztext.text = GData.Room[5].HisQ[0].AnswerGiven + "/3";
            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 6 && PortugalManager.selectedCategory == 2)
            {
                showrelatedquiztext.text = GData.Room[5].GeoQ[0].AnswerGiven + "/3";
            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 6 && PortugalManager.selectedCategory == 3)
            {
                showrelatedquiztext.text = GData.Room[5].FoodQ[0].AnswerGiven + "/3";
            }
            else if (PlayerPrefs.GetInt("levelcurrent") == 6 && PortugalManager.selectedCategory == 4)
            {
                showrelatedquiztext.text = GData.Room[5].CulQ[0].AnswerGiven + "/3";

            }
        }
        if (!Ischaracter)
        {
            if (FindObjectOfType<CharacterController>())
            {
                Ischaracter = true;
                PlayerController = FindObjectOfType<CharacterController>().gameObject;
            }
        }

    }
    public void HandlePlayerState(bool Status)
    {
        PlayerController.SetActive(Status);
    }
    public void setvalue()
    {
        if (!GameManager.Instance.IsMulti)
        {
            PlayerPrefs.SetInt("Flag", 1);
        }
    }
    public void ResumeGame()
    {
        HandlePlayerState(true);
        CF2_FPP_Rig.SetActive(true);

    }
    [System.Serializable]
    public class GameRoom
    {
        public string name;
        public Button[] RoomBtn;
    }

}
