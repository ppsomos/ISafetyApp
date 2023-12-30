using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChangeScript : MonoBehaviour
{
    public Sprite SoundOnImage;
    public Sprite SoundOffImage;
    private bool IsOn = true;
    public Button _button;
    public GameData GData;
    void Start()
    {
        SoundOnImage = _button.image.sprite;
        StartSound();
    }
    public void StartSound()
    {
        if (!GData.IsSound)
        {
            _button.image.sprite = SoundOffImage;
        }
        else
        {
            _button.image.sprite = SoundOnImage;
        }
    }
   public void buttonclicked()
    {
        if (GData.IsSound)
        {
            _button.image.sprite = SoundOffImage;
            GData.IsSound = false;
            PersistentDataManager.instance.SaveData();
        }
        else
        {
            _button.image.sprite = SoundOnImage;
            GData.IsSound = true;
            PersistentDataManager.instance.SaveData();
        }

    }
}
