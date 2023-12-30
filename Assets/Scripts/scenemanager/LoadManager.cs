using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadManager : MonoBehaviour
{
    public GameObject loadingscreen;
    // public CountDown countDown;
    public GameData gameData;
    public Slider _slider;
    public void levelLoad(int sceneindex)
    {
        ResetProgress();
        StartCoroutine(Loadasyncouronsly(sceneindex));
    }
    IEnumerator Loadasyncouronsly(int sceneindex)
    {
        loadingscreen.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneindex);
        //loadingscreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            _slider.value = progress;
            //progresstext.text = progress * 100f + "%";
            yield return null;
        }
    }
    public void Restart()
    {
        ResetProgress();
        SceneManager.LoadSceneAsync("Musem scene");
       // countDown.timeRemaining = gameData.GameTime;
        CountDown.timerIsRunning = true;
        //PlayerPrefs.SetFloat("TimeRemaining", countDown.timeRemaining);
        //PlayerPrefs.Save();
    }
    private void ResetProgress()
    {
        for (int i = 0; i < gameData.OffRoom.Length; i++)
        {
            for (int j = 0; j < gameData.OffRoom[i].RoomObj.Length; j++)
            {
                gameData.OffRoom[i].RoomObj[j].IsComplete = false;
            }
        }
        PersistentDataManager.instance.SaveData();
        //UkManager
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
}

