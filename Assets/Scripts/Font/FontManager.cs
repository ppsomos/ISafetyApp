using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FontManager : MonoBehaviour
{
    public static FontManager Instance;
    public GameData GData;

    [Header("TMP")]
    public TMP_FontAsset EnglishFont;
    public TMP_FontAsset GreekFont;
    [Header("Simple Text")]
    public Font EnglishFontsimple;
    public Font GreekFontsimple;

    public List<TMP_Text> textObjects = new List<TMP_Text>();
    public List<Text> textObjectssimple = new List<Text>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void RegisterTextObject(TMP_Text textObject)
    {
        textObjects.Add(textObject);
    }

    public void RegisterTextObjectsimple(Text textObject)
    {
        textObjectssimple.Add(textObject);
    }


    public void ChangeFontForLanguage(TMP_FontAsset font)
    {
        // Create a new list to store text objects without null references
        List<TMP_Text> validTextObjects = new List<TMP_Text>();

        // Iterate through the original list and filter out null references
        foreach (TMP_Text textObject in textObjects)
        {
            if (textObject != null)
            {
                validTextObjects.Add(textObject);
            }
        }

        // Update the original list with the filtered list
        textObjects = validTextObjects;

        // Set the font for each valid text object
        foreach (TMP_Text textObject in textObjects)
        {
            textObject.font = font;
        }
    }


    public void ChangeFontForLanguageSimple(Font font)
    {
        // Create a new list to store text objects without null references
        List<Text> validTextObjects = new List<Text>();

        // Iterate through the original list and filter out null references
        foreach (Text textObject in textObjectssimple)
        {
            if (textObject != null)
            {
                validTextObjects.Add(textObject);
            }
        }

        // Update the original list with the filtered list
        textObjectssimple = validTextObjects;

        // Set the font for each valid text object
        foreach (Text textObject in textObjectssimple)
        {
            textObject.font = font;
        }
    }


    public void UpdateFont()
    {
        if (GData.SelectedLanguage == 1)
        {
            ChangeFontForLanguage(GreekFont);
            ChangeFontForLanguageSimple(GreekFontsimple);
        }
        else
        {
            ChangeFontForLanguage(EnglishFont);
            ChangeFontForLanguageSimple(EnglishFontsimple);
        }
       
    }
    public void DefaultFont()
    {
        ChangeFontForLanguage(EnglishFont);
        ChangeFontForLanguageSimple(EnglishFontsimple);
    }
}
