using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayWothFriendsHandler : MonoBehaviour
{
    public InputField PlayerName_InputField;
    public GameObject Player1Avatar;
    public GameObject Player1Text;
    public GameObject Player2Text;
    public GameObject Player2Avatar;
    public Button OkButton;
    public GameData GameData;
    public GameObject PlaywithFriend_Page;
    public GameObject SelectLevel_Page;
    public int playerNo;

    private void Start()
    {
        Player1Text.SetActive(true);
        playerNo = 0;

        OkButton.onClick.RemoveAllListeners();
        OkButton.onClick.AddListener(OkButtonPressed);

        Player1Avatar.GetComponent<Button>().onClick.RemoveAllListeners();
        Player1Avatar.GetComponent<Button>().onClick.AddListener(() => SelecAvatar(1));

        Player2Avatar.GetComponent<Button>().onClick.RemoveAllListeners();
        Player2Avatar.GetComponent<Button>().onClick.AddListener(() => SelecAvatar(2));
    }

    private void OkButtonPressed()
    {
        if (string.IsNullOrEmpty(PlayerName_InputField.text))
        {
            switch(GameData.SelectedLanguage)
            {
                case 0:
                    PlayerName_InputField.text = "Please Input Name";
                    break;
                case 1:
                    PlayerName_InputField.text = "Παρακαλώ εισάγετε Όνομα";
                    break;
                case 2:
                    PlayerName_InputField.text = "Proszę wpisać nazwę";
                    break;

            }
           
            PlayerName_InputField.textComponent.color = Color.red;
            StartCoroutine(NormalizedText());
            return;
        }
        if (GameData.Player[playerNo].AvatarIndex == 0)
        {
            Player1Avatar.GetComponent<Image>().color = Color.red;
            Player2Avatar.GetComponent<Image>().color = Color.red;
            StartCoroutine(NormalizedColor());
            return;
        }

        GameData.Player[playerNo].Name = PlayerName_InputField.text;
        playerNo++;
        Player1Text.SetActive(false);
        Player2Text.SetActive(true);
        ClearAllFields();
        PersistentDataManager.instance.SaveData();

        if (playerNo == 2)
        {
            PlaywithFriend_Page.SetActive(false);
            SelectLevel_Page.SetActive(true);
        }
    }
    private void SelecAvatar(int index)
    {
        if (index == 1)
        {
            Player1Avatar.transform.GetChild(0).gameObject.SetActive(true);
            Player2Avatar.transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            Player1Avatar.transform.GetChild(0).gameObject.SetActive(false);
            Player2Avatar.transform.GetChild(0).gameObject.SetActive(true);
        }
        GameData.Player[playerNo].AvatarIndex = index;
    }

    private IEnumerator NormalizedText()
    {
        yield return new WaitForSeconds(1f);
        PlayerName_InputField.text = string.Empty;
        PlayerName_InputField.textComponent.color = Color.white;
    }
    private IEnumerator NormalizedColor()
    {
        yield return new WaitForSeconds(1f);
        Player1Avatar.GetComponent<Image>().color = Color.white;
        Player2Avatar.GetComponent<Image>().color = Color.white;
    }

    private void ClearAllFields()
    {
        PlayerName_InputField.text = string.Empty;
        Player1Avatar.transform.GetChild(0).gameObject.SetActive(false);
        Player2Avatar.transform.GetChild(0).gameObject.SetActive(false);
    }













    //public GameObject LevelPanal;
    //public GameObject PlayerProfilePanal;
    //public Text HeaderText;
    //public Sprite[] PlayerAvatar;
    //public Image PlayerImg;
    //public Text PlayerNameTextColor;
    //public int PlayerNo;
    //public GameData GData;
    //private void Start()
    //{

    //}
    //public void OnOkBtnClick()
    //{
    //    if (PlayerName.text == "")
    //    {
    //        PlayerName.text = "Please Enter Name";
    //        PlayerNameTextColor.color = Color.red;
    //        StartCoroutine(RemoveText());
    //    }
    //    else
    //    {
    //        GData.Player[PlayerNo].Name = PlayerName.text;
    //        PersistentDataManager.instance.SaveData();
    //        if (PlayerNo < 1 && PlayerName.text != null)
    //        {
    //            PlayerName.text = null;
    //            HeaderText.text = "Player 2";
    //            PlayerImg.sprite = PlayerAvatar[PlayerNo + 1];
    //        }
    //        else if (PlayerName.text != null)
    //        {
    //            LevelPanal.SetActive(true);
    //            PlayerProfilePanal.SetActive(false);
    //        }
    //        PlayerNo++;
    //    }  
    //}
    //IEnumerator RemoveText()
    //{
    //    yield return new WaitForSeconds(2f);
    //    PlayerName.text = "";
    //    PlayerNameTextColor.color = Color.white;

    //}
}



