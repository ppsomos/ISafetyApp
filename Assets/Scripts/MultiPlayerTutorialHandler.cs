using System.Collections.Generic;
using UnityEngine;

public class MultiPlayerTutorialHandler : MonoBehaviour
{
    public List<GameObject> tutorialTasks;
    public List<GameObject> TasksPanal;
    public GameData GData;

    public void EnableTask(int num)
    {
        if(GData.M_StartTutorial)
        {
            if (GData.M_tutorialFinished == false)
            {
                if (!GData.M_tutorial[num].IsComplete)
                {
                    for (int i = 0; i < tutorialTasks.Count; i++)
                    {
                        tutorialTasks[i].SetActive(false);
                    }
                    tutorialTasks[num].SetActive(true);
                    GData.M_tutorial[num].IsComplete = true;
                    if (num == GData.M_tutorial.Length)
                    {
                        GData.M_tutorialFinished = true;
                    }
                    PersistentDataManager.instance.SaveData();
                }
            }
        }
    }
    public void EnablePanel(int num)
    {
        for (int i = 0; i < TasksPanal.Count; i++)
        {
            TasksPanal[i].SetActive(false);
        }
        TasksPanal[num].SetActive(true);
        GData.M_tutorial[num].IsComplete = true;
    }
    public void DisableTasks()
    {
        if (GData.tutorialFinished == false)
        {
            for (int i = 0; i < tutorialTasks.Count; i++)
            {
                tutorialTasks[i].SetActive(false);
            }

        }
    }
    public void TutorialFinished()
    {
        if (GData.M_StartTutorial)
        {
            for (int i = 0; i < tutorialTasks.Count; i++)
            {
                tutorialTasks[i].SetActive(false);
            }
            GData.M_tutorialFinished = true;
        }
    }
}
