using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Addbutton : MonoBehaviour
{
    [SerializeField] private Transform puzzlefield;

    [SerializeField] private GameObject btn;

    private void Awake()
    {
        for (int i = 0; i < 15; i++)
        {
            GameObject button = Instantiate(btn);
            button.name = "" + i;
            button.transform.SetParent(puzzlefield , false);
        }
    }
} 
