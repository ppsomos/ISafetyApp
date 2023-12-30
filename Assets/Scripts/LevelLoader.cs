using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance = null;
    public GameData GData;
    public GameObject SkipBtn;
    public GameObject Mainmenupanal;
    public GameObject flagpanal;
    public GameObject Desclaimer_page;
    public GameObject Intro_Page;
    public GameObject LanguageDropDown_Intro;
    public GameObject LanguageDropDown_Setting;
    public GameObject Difficultydropdown;
    public Button SoundBtn;
    public Button MusicBtn;
    public Sprite[] Sound_S;
    public Sprite[] Music_S;
    public PlayWothFriendsHandler pf;
    public MultiPlayerTutorialHandler M_TutorialHandler;
    public FirstTimeQuestionHandler FirstTimeQuestion;
    public static int currentindex;
    public GameObject Label;
    public GameObject PlayWithFriendsPanal;
    //-------------For Level Locking------------

    public GameObject[] _button;
    int levelunlocked = 0;


    private void Awake()
    {
        instance = this;
      Invoke("CheckForFirstTime",.25f);
    }

    private void Start()
    {
        clearMultiplayerData();
        ResetProgress();
        StartMusicSetting();
        StartSoundSetting();
        if (PlayerPrefs.HasKey("Flag"))
        {
            int val = PlayerPrefs.GetInt("Flag");
            if (val == 1)
            {
                Mainmenupanal.SetActive(false);
                flagpanal.SetActive(true);
                PlayerPrefs.SetInt("Flag", 0);
            }
        }
        SoundManager.Instance.PlayBackgroundMusic(AudioClipsSource.Instance.BGSound);
    }

    public void StartSoundSetting()
    {
        if(GData.IsSound)
        {
            SoundManager.Instance.MusicVolume = 1;
            SoundBtn.GetComponent<Image>().sprite = Sound_S[1];
        }
        else
        {
            SoundBtn.GetComponent<Image>().sprite = Sound_S[0];
            SoundManager.Instance.MusicVolume = 0;
        }
    }
    public void StartMusicSetting()
    {
        if (GData.IsMusic)
        {
            MusicBtn.GetComponent<Image>().sprite = Music_S[1];
            SoundManager.Instance.EffectsVolume = 1;
        }
        else
        {
            SoundManager.Instance.EffectsVolume = 0;
            MusicBtn.GetComponent<Image>().sprite = Music_S[0];
        }
    }
    public void SoundBtnClick()
    {
        if (GData.IsSound)
        {
            GData.IsSound = false;
            SoundBtn.GetComponent<Image>().sprite = Sound_S[0];
            SoundManager.Instance.EffectsVolume = 0;
            PersistentDataManager.instance.SaveData();
        }
        else
        {
            GData.IsSound = transform;
            SoundManager.Instance.EffectsVolume = 1;
            SoundBtn.GetComponent<Image>().sprite = Sound_S[1];
            PersistentDataManager.instance.SaveData();
        }
         GenaricBtnClcik();
    }
    public void MusicBtnClick()
    {
        if (GData.IsMusic)
        {
            GData.IsMusic = false;
            MusicBtn.GetComponent<Image>().sprite = Music_S[0];
            SoundManager.Instance.MusicVolume = 0;
            PersistentDataManager.instance.SaveData();
        }
        else
        {
            GData.IsMusic = true;
            SoundManager.Instance.MusicVolume = 1;
            MusicBtn.GetComponent<Image>().sprite = Music_S[1];
            PersistentDataManager.instance.SaveData();
        }
        GenaricBtnClcik();
    }
    public void AI_SkipButtonClick()
    {
        GenaricBtnClcik();
        FirstTimeQuestion.FirstTimeQuestionPanal.SetActive(false);
        Mainmenupanal.SetActive(true);
    }
    public void CheckForFirstTime()
    {
        if (GameManager.Instance.PlayFirstTimeGame)
        {
            Debug.Log("11111111111");
            SkipBtn.SetActive(false); 
            OnSelectLanguage(LanguageDropDown_Intro.GetComponent<TMP_Dropdown>());
            OnSelectLanguage(LanguageDropDown_Setting.GetComponent<TMP_Dropdown>());
            PlayerPrefs.SetInt("LevelUnlock", 0);
            PlayerPrefs.Save();
            LockedAllLevels();
        }
        else
        {
            SkipBtn.SetActive(true);
            StartDifficultySetting();
            StartLeanguageSetting();
            LockedAllLevels();
        }
        if(GameManager.Instance.isSplash)
        {
            Debug.Log("11111");
            GameManager.Instance.isSplash = false;
            Desclaimer_page.SetActive(true);
            Mainmenupanal.SetActive(false);
        }

       
    }
    public void clearMultiplayerData()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.IsMulti = false;
            GameManager.Instance.SelectedPlayer = 0;
        }
        pf.playerNo = 0;
        pf.Player1Text.SetActive(true);
        pf.Player2Text.SetActive(false);
        for (int i = 0; i < GData.Player.Length; i++)
        {
            GData.Player[i].Name = string.Empty;
            GData.Player[i].AvatarIndex = 0;
            GData.Player[i].IsComplete = false;
            GData.Player[i].TimeTaken = 0;
            GData.Player[i].WrongAnswer = 0;
            GData.Player[i].RightAnswer = 0;
            PersistentDataManager.instance.SaveData();
        }
        for (int i = 0; i < GData.Room.Length; i++)
        {
            GData.Room[i].No_Of_Obj_Complete = 0;
            GData.Room[i].FoodQ[0].AnswerGiven = 0;
            GData.Room[i].FoodQ[0].IsComplte = false;
            GData.Room[i].HisQ[0].AnswerGiven = 0;
            GData.Room[i].HisQ[0].IsComplte = false;
            GData.Room[i].GeoQ[0].AnswerGiven = 0;
            GData.Room[i].GeoQ[0].IsComplte = false;
            GData.Room[i].CulQ[0].AnswerGiven = 0;
            GData.Room[i].CulQ[0].IsComplte = false;
            PersistentDataManager.instance.SaveData();
        }

    }
    public void PanalOpen(GameObject Panal)
    {
        Panal.SetActive(true);
        GenaricBtnClcik();
        //Panal.transform.GetChild(1).gameObject.SetActive(true);
        //Panal.transform.DOScale(new Vector3(.9f, 1.6f, 1f), .5f).OnComplete(delegate
        //{
        //    Panal.transform.GetChild(1).DOScale(new Vector3(1.4f, .9f, 1f), .5f);
        //});
    }
    public void PanalClose(GameObject Panal)
    {
        //Panal.transform.GetChild(1).DOScale(0, .5f).OnComplete(delegate
        //{
        //    Panal.transform.GetChild(1).gameObject.SetActive(false);
        //    Panal.transform.DOScale(0, .5f).OnComplete(delegate
        //    {
        GenaricBtnClcik();
        Panal.SetActive(false);
        //    });
        //});

    }
    private void LockedAllLevels()
    {
        for (int i = 0; i < _button.Length; i++)
        {
            bool unlocked;
            if (GameManager.Instance.IsMulti)
            {
                unlocked = GData.MultiPlayerLevelUnlocked >= i;
            }
            else
            {
                unlocked = GData.UnlockedLevel >= i;
            }
            _button[i].GetComponent<Button>().interactable = unlocked;
            _button[i].transform.GetChild(0).gameObject.SetActive(!unlocked);
        }

    }
    public void StartDifficultySetting()
    {
        Difficultydropdown.GetComponent<TMP_Dropdown>().value = GData.DifficultyLevel;
        switch(GData.DifficultyLevel)
        {
            case 0:
             GData.GameTime = 240F;
                break;
            case 1:
                GData.GameTime = 180F;
                break;
            case 2:
                GData.GameTime = 120F;
                break;
        }
    }
    public void OnPlayWithFriendsBtnClick()
    {
        GenaricBtnClcik();
        GData.M_StartTutorial = true;
        PlayWithFriendsPanal.SetActive(true);
        GameManager.Instance.IsMulti = true;
        //GData.UnlockedLevel = 5;
        PersistentDataManager.instance.SaveData();
        LockedAllLevels();
    }
    public void RemoveMultiPlayerCheck()
    {
        GameManager.Instance.IsMulti = false;
        //GData.UnlockedLevel = 5;
        PersistentDataManager.instance.SaveData();
        LockedAllLevels();
    }
    public void StartNowClcik()
    {
        GenaricBtnClcik(); 
        LockedAllLevels();
    }
    public void RoomSelectBackBtnClick()
    {
        GenaricBtnClcik();
        if (GameManager.Instance.IsMulti)
        {
            GameManager.Instance.IsMulti = false;
        }
    }
    public void OnSelectLanguage(TMP_Dropdown dropdown)
    {
        // 0 for English
        // 1 for Greek
        // 2 for Polish
        GenaricBtnClcik(); 
        int index = dropdown.value;
        GData.SelectedLanguage = index;
        PersistentDataManager.instance.SaveData();
        StartLeanguageSetting();

    }

    public void StartLeanguageSetting()
    {
        LanguageDropDown_Setting.GetComponent<TMP_Dropdown>().value = GData.SelectedLanguage;
        LanguageDropDown_Intro.GetComponent<TMP_Dropdown>().value = GData.SelectedLanguage;
        if (GData.SelectedLanguage == 0)
        {
            Difficultydropdown.GetComponent<TMP_Dropdown>().options[0].text = "Easy";
            Difficultydropdown.GetComponent<TMP_Dropdown>().options[1].text = "Medium";
            Difficultydropdown.GetComponent<TMP_Dropdown>().options[2].text = "Hard";
        }
        else if (GData.SelectedLanguage == 1) //Greek
        {
            Difficultydropdown.GetComponent<TMP_Dropdown>().options[0].text = "Ανετα";
            Difficultydropdown.GetComponent<TMP_Dropdown>().options[1].text = "Μεσαίο";
            Difficultydropdown.GetComponent<TMP_Dropdown>().options[2].text = "Σκληρά";
        }
        else if (GData.SelectedLanguage == 2)//Polish
        {
            Difficultydropdown.GetComponent<TMP_Dropdown>().options[0].text = "Łatwy";
            Difficultydropdown.GetComponent<TMP_Dropdown>().options[1].text = "Średni";
            Difficultydropdown.GetComponent<TMP_Dropdown>().options[2].text = "Trudny";
        }
        Label.GetComponent<TMP_Text>().text =
    Difficultydropdown.GetComponent<TMP_Dropdown>()
    .options[GData.DifficultyLevel].text;
        ChangeLocale();
    }
    public void OnSelectdifficulty()
    {
        GenaricBtnClcik();
        // 0 for easy
        // 1 for medium
        // 2 for hard
        switch (Difficultydropdown.GetComponent<TMP_Dropdown>().value)
        {
            case 0:
                GData.DifficultyLevel = 0;
                GData.GameTime = 240F;
                PersistentDataManager.instance.SaveData();
                break;

            case 1:
                GData.DifficultyLevel = 1;
                GData.GameTime = 180F;
                PersistentDataManager.instance.SaveData();
                break;

            case 2:
                GData.DifficultyLevel = 2;
                GData.GameTime = 120;
                PersistentDataManager.instance.SaveData();
                break;
            default:
                break;
        }

        PersistentDataManager.instance.SaveData();
    }
    public void MainSettingOkBtn()
    {
        GenaricBtnClcik();
        Intro_Page.SetActive(false);
        FirstTimeQuestion.LoadQuestion();
        FirstTimeQuestion.FirstTimeQuestionPanal.SetActive(true);
        GData.SelectedLanguage = LanguageDropDown_Intro.GetComponent<TMP_Dropdown>().value;
        PersistentDataManager.instance.SaveData();
        StartLeanguageSetting();
    }
    public void DesclamierOkButton()
    {
        GenaricBtnClcik();
        Desclaimer_page.SetActive(false);
        Intro_Page.SetActive(true);
    }
    public void ButtonLocking()
    {
        PlayerPrefs.SetInt("levelunlocked", currentindex);
    }

    public void ChangeLevelPos(int index)
    {
        currentindex = index;
        GData.SelectedRoom = index - 1;
        PlayerPrefs.SetInt("levelcurrent", currentindex);
        PersistentDataManager.instance.SaveData();
    }

    public void ChangeLocale()
    {
        StartCoroutine(SetLocale());
    }

    private IEnumerator SetLocale()
    {
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[GData.SelectedLanguage];
        if (GData.SelectedLanguage == 1)
        {
            FontManager.Instance.UpdateFont();
        }
        else
        {
            FontManager.Instance.DefaultFont();
        }

    }
    private void ResetProgress()
    {
        for (int i = 0; i < GData.OffRoom.Length; i++)
        {
            for (int j = 0; j < GData.OffRoom[i].RoomObj.Length; j++)
            {
                GData.OffRoom[i].RoomObj[j].IsComplete = false;
            }
        }
        PersistentDataManager.instance.SaveData();
        //UkManager
        GData.RightAnswer = 0;
        GData.WrongAnswer = 0;
        PersistentDataManager.instance.SaveData();
        PlayerPrefs.SetInt("UKscore", 0);
        PlayerPrefs.SetInt("UKCult", 0);
        PlayerPrefs.SetInt("UKFood", 0);
        PlayerPrefs.SetInt("UKGeo", 0);
        PlayerPrefs.SetInt("UKHist", 0);
        //portagual Manager
        PlayerPrefs.SetInt("POMscore", 0);
        PlayerPrefs.SetInt("PortugalCult", 0);
        PlayerPrefs.SetInt("PortugalFood", 0);
        PlayerPrefs.SetInt("PortugalGeo", 0);
        PlayerPrefs.SetInt("PortugalHist", 0);
        //Poland Manager
        PlayerPrefs.SetInt("PMscore", 0);
        PlayerPrefs.SetInt("PolandCult", 0);
        PlayerPrefs.SetInt("PolandFood", 0);
        PlayerPrefs.SetInt("PolandGeo", 0);
        PlayerPrefs.SetInt("PolandHist", 0);
        //math Manager
        PlayerPrefs.SetInt("MathHist", 0);
        PlayerPrefs.SetInt("MathCult", 0);
        PlayerPrefs.SetInt("MathFood", 0);
        PlayerPrefs.SetInt("MathGeo", 0);
        PlayerPrefs.SetInt("MMscore", 0);
        //greece Manager
        PlayerPrefs.SetInt("GMscore", 0);
        PlayerPrefs.SetInt("GreeceCult", 0);
        PlayerPrefs.SetInt("GreeceFood", 0);
        PlayerPrefs.SetInt("GreeceGeo", 0);
        PlayerPrefs.SetInt("GreeceHist", 0);
        //Belguim Manager
        PlayerPrefs.SetInt("BMscore", 0);
        PlayerPrefs.SetInt("BelgiumCult", 0);
        PlayerPrefs.SetInt("BelgiumFood", 0);
        PlayerPrefs.SetInt("BelgiumGeo", 0);
        PlayerPrefs.SetInt("BelgiumHist", 0);
        //Level
        PlayerPrefs.SetInt("Level1", 0);
        PlayerPrefs.SetInt("Level2", 0);
        PlayerPrefs.SetInt("Level3", 0);
        PlayerPrefs.SetInt("Level4", 0);
        PlayerPrefs.SetInt("Level5", 0);
        PlayerPrefs.SetInt("Level6", 0);
    }

    public void OpenAppStoreLink()
    {
        GenaricBtnClcik();
#if UNITY_ANDROID

        string appPackageName = "com.bgs.safetyescapegame";
        Application.OpenURL("market://details?id=" + appPackageName);
#elif UNITY_IOS
           
            string iOSAppID = "id6463464411";
            Application.OpenURL("itms-apps://itunes.apple.com/app/id" + iOSAppID);
#else
            Debug.LogWarning("Rating functionality not supported on this platform.");
#endif
    }
    public void GenaricBtnClcik()
    {
        SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.ButtonClick);
    }

}
