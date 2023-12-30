using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
   
    public void OnExitClick()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
