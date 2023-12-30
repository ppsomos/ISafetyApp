using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerpref : MonoBehaviour
{
    public void DeleteAllplayerpref()
    {
        PlayerPrefs.DeleteAll();
    }
}
