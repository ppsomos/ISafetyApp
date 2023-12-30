using System.Collections.Generic;
using UnityEngine;

public class MainMenuTutorialHandler : MonoBehaviour
{
    public List<GameObject> tutorialTasks;
    public List<GameObject> TasksPanal;
    public GameData GData;

    private void OnEnable()
    {
        if (GData.tutorialFinished == false)
        {
            Debug.Log("1111");
            EnableTask(0);
        }
    }
    public void SkipBtnPress(int num)
    {
        if(!GData.tutorialFinished)
        {
            for(int i = 0;i< tutorialTasks.Count; i++)
            {
                GData.tutorial[i].IsComplete = true;
                tutorialTasks[i].SetActive(false);
                PersistentDataManager.instance.SaveData();
            }
        }

    }

    public void EnableTask(int num)
    {
        if(GData.StartTutorial)
        {
            if (GData.tutorialFinished == false)
            {
                if (!GData.tutorial[num].IsComplete)
                {
                    for (int i = 0; i < tutorialTasks.Count; i++)
                    {
                        if(tutorialTasks[i]!=null)
                        {
                            tutorialTasks[i].SetActive(false);
                        }
                    }
                    tutorialTasks[num].SetActive(true);
                    GData.tutorial[num].IsComplete = true;
                    if (num == GData.tutorial.Length)
                    {
                        GData.tutorialFinished = true;
                    }
                    PersistentDataManager.instance.SaveData();
                }
            }
        }
    }
    public void EnabelPanal(int num)
    {
        //if (GData.StartTutorial)
        //{
        //    if (GData.tutorialFinished == false)
        //    {
                //if (!GData.tutorial[num].IsComplete)
                //{
                    for (int i = 0; i < TasksPanal.Count; i++)
                    {
                        if (TasksPanal[i] != null)
                        {
                            TasksPanal[i].SetActive(false);
                        }
                    }
                    Debug.Log("11");
                    TasksPanal[num].SetActive(true);
                //}
        //    }
        //}
    }
    public void DisableTasks()
    {
        if (GData.tutorialFinished == false)
        {
            for (int i = 0; i < tutorialTasks.Count; i++)
            {
                if(tutorialTasks[i]!=null)
                {
                    tutorialTasks[i].SetActive(false);
                }
            }

        }
    }
    public void TutorialFinished()
    {
        DisableTasks();
        GData.tutorialFinished = true;
    }
}
