using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LanguageText : MonoBehaviour
{
    private TMP_Text textComponent;
    private Text textComponentsimple;

    private void Start()
    {

    }
    private void OnEnable()
    {
        if (gameObject.GetComponent<TMP_Text>() != null)
        {
            textComponent = GetComponent<TMP_Text>();
            FontManager.Instance.RegisterTextObject(textComponent);
            FontManager.Instance.UpdateFont();
        }
        else
        {
            textComponentsimple = GetComponent<Text>();
            FontManager.Instance.RegisterTextObjectsimple(textComponentsimple);
            FontManager.Instance.UpdateFont();
        }
    }
}
