//using System.Collections;
//using UnityEngine;
//using UnityEngine.Localization.Settings;
//using UnityEngine.UI;

//public class LocaleSelector : MonoBehaviour
//{
//    public static LocaleSelector instance { get; private set; }
//    public Dropdown dropdown;


//    // The key for saving/loading the selected language
//    private const string SelectedLanguageKey = "SelectedLanguage";

//    private void Awake()
//    {
//        // Singleton pattern
//        if (instance == null)
//        {
//            instance = this;
//            DontDestroyOnLoad(gameObject);
//        }
//        else
//        {
//            Destroy(gameObject);
//            return;
//        }
//    }



//    public void SelectLanguage()
//    {
//        //Dropdown temp;

//        //if (index == 0)
//        //{
//        //    temp = dropdown;
//        //}
//        //else
//        //{
//        //    temp = dropdown;
//        //}

//        int value = dropdown.value;
//        Debug.Log("Selected Value: " + value);

//        switch (value)
//        {
//            case 0:
//                PlayerPrefs.SetInt("currentlanguage", value);
//                PlayerPrefs.Save();
//                break;
//            case 1:
//                Debug.Log("Came");
//                PlayerPrefs.SetInt("currentlanguage", value);
//                PlayerPrefs.Save();
//                break;
//            case 2:
//                PlayerPrefs.SetInt("currentlanguage", value);
//                PlayerPrefs.Save();
//                break;
//        }

//        Debug.Log(PlayerPrefs.GetInt("currentlanguage"));

//        //ChangeLocale();

//    }
//}

