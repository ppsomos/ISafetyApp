using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OnEnableInteractablity : MonoBehaviour
{
    public List<Button>  btn;
    public bool hasDropdown;
    public bool hasDropdown2;
    public TMP_Dropdown dropDown;
    public TMP_Dropdown dropDown2;

    private void OnEnable()
    {
        if (hasDropdown)
        {
            dropDown.interactable = false;
        }
        if (hasDropdown2)
        {
            dropDown2.interactable = false;
        }
        for (int i = 0; i < btn.Count; i++)
        {
            btn[i].interactable = false;
        }
       
        
    }
    private void OnDisable()
    {
        if (hasDropdown)
        {
            dropDown.interactable = true;
        }
        if (hasDropdown2)
        {
            dropDown2.interactable = true;
        }
        for (int i = 0; i < btn.Count; i++)
        {
            btn[i].interactable = true;
        }
    }
}
