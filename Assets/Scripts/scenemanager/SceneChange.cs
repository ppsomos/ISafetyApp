using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    public GameObject loadingscreen;
    public Slider _slider;
    public void LevelLoad(int sceneindex)
    {
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
}
