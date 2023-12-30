using UnityEngine;
using UnityEngine.UI;

public class zone : MonoBehaviour
{
    public GameObject canvas;
    [Header("Game Data")]
    [SerializeField] private GameData gameData;
    [Header("UI Elements")]
    [SerializeField] private GameObject mainCanvas;
    [SerializeField] private GameObject quizPanal;
    [SerializeField] private GameObject Canvas;
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject CF2_FPP_Rig;
    [SerializeField] private GameObject Camera;
    [Header("Room Managers")]
    [SerializeField] private UKManager uKManager;
    [SerializeField] private GreeceManager greeceManager;
    [SerializeField] private BelgiumManager belgiumManager;
    [SerializeField] private MathManager mathManager;
    [SerializeField] private PolandManager polandManager;
    [SerializeField] private PortugalManager portugalManager;
    [SerializeField] private int ModelIndex;
    [SerializeField] Button ReadQuestion;
    private bool Ischaracter;
    private GameManagers gameManagers;
    public GameObject LevelCompletePage;
    private void Start()
    {
        gameManagers = FindObjectOfType<GameManagers>();
        ReadQuestion.onClick.RemoveAllListeners();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!GameManager.Instance.IsMulti)
        {
            if (other.gameObject.CompareTag("Player") && !gameData.OffRoom[gameData.SelectedRoom].RoomObj[ModelIndex - 1].IsComplete)
            {
                //Debug.Log("collision");
                ReadQuestion.gameObject.SetActive(true);
                ReadQuestion.interactable = true;
                ReadQuestion.onClick.RemoveAllListeners();
                ReadQuestion.onClick.AddListener(SetListener);
            }
            else if (other.gameObject.CompareTag("Player") && gameData.OffRoom[gameData.SelectedRoom].RoomObj[ModelIndex - 1].IsComplete)
            {
                //Debug.Log("else");
                ReadQuestion.gameObject.SetActive(true);
                ReadQuestion.interactable = false;
            }
        }
        else
        {
            if (ModelIndex == 1)
            {
                if (other.gameObject.CompareTag("Player") && !gameData.Room[gameData.SelectedRoom].HisQ[0].IsComplte)
                {
                    //Debug.Log("collision");
                    ReadQuestion.gameObject.SetActive(true);
                    ReadQuestion.interactable = true;
                    ReadQuestion.onClick.RemoveAllListeners();
                    ReadQuestion.onClick.AddListener(SetListener);
                }
                else if (other.gameObject.CompareTag("Player") && gameData.Room[gameData.SelectedRoom].HisQ[0].IsComplte)
                {
                    //Debug.Log("else");
                    ReadQuestion.gameObject.SetActive(true);
                    ReadQuestion.interactable = false;
                }
            }
            else if (ModelIndex == 2)
            {
                if (other.gameObject.CompareTag("Player") && !gameData.Room[gameData.SelectedRoom].GeoQ[0].IsComplte)
                {
                    //Debug.Log("collision");
                    ReadQuestion.gameObject.SetActive(true);
                    ReadQuestion.interactable = true;
                    ReadQuestion.onClick.RemoveAllListeners();
                    ReadQuestion.onClick.AddListener(SetListener);
                }
                else if (other.gameObject.CompareTag("Player") && gameData.Room[gameData.SelectedRoom].GeoQ[0].IsComplte)
                {
                    //Debug.Log("else");
                    ReadQuestion.gameObject.SetActive(true);
                    ReadQuestion.interactable = false;
                }
            }
            else if (ModelIndex == 3)
            {
                if (other.gameObject.CompareTag("Player") && !gameData.Room[gameData.SelectedRoom].FoodQ[0].IsComplte)
                {
                    //Debug.Log("collision");
                    ReadQuestion.gameObject.SetActive(true);
                    ReadQuestion.interactable = true;
                    ReadQuestion.onClick.RemoveAllListeners();
                    ReadQuestion.onClick.AddListener(SetListener);
                }
                else if (other.gameObject.CompareTag("Player") && gameData.Room[gameData.SelectedRoom].FoodQ[0].IsComplte)
                {
                    //Debug.Log("else");
                    ReadQuestion.gameObject.SetActive(true);
                    ReadQuestion.interactable = false;
                }
            }
            else if (ModelIndex == 4)
            {
                if (other.gameObject.CompareTag("Player") && !gameData.Room[gameData.SelectedRoom].CulQ[0].IsComplte)
                {
                    //Debug.Log("collision");
                    ReadQuestion.gameObject.SetActive(true);
                    ReadQuestion.interactable = true;
                    ReadQuestion.onClick.RemoveAllListeners();
                    ReadQuestion.onClick.AddListener(SetListener);
                }
                else if (other.gameObject.CompareTag("Player") && gameData.Room[gameData.SelectedRoom].CulQ[0].IsComplte)
                {
                    //Debug.Log("else");
                    ReadQuestion.gameObject.SetActive(true);
                    ReadQuestion.interactable = false;
                }
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Exit");
            ReadQuestion.gameObject.SetActive(false);
            ReadQuestion.onClick.RemoveAllListeners();
            //canvas.SetActive(false);
        }
    }

    private void SetListener()
    {
        Camera.SetActive(true);
        gameManagers.HandlePlayerState(false);
        CF2_FPP_Rig.SetActive(false);
        mainCanvas.SetActive(true);
        quizPanal.SetActive(true);
        LevelCompletePage.SetActive(true);
        //background.SetActive(true);
        Canvas.SetActive(false);
        if (gameData.SelectedRoom.Equals(0))
        {
            if (ModelIndex == 1)
            {
                uKManager.SetHistoryQuizData(1);
            }
            else if (ModelIndex == 2)
            {
                uKManager.SetGeographyQuizData(2);
            }
            else if (ModelIndex == 3)
            {
                uKManager.SetFoodQuizData(3);
            }
            else if (ModelIndex == 4)
            {
                uKManager.SetCultureQuizData(4);
            }
        }
        else if (gameData.SelectedRoom.Equals(1))
        {
            if (ModelIndex == 1)
            {
                belgiumManager.SetHistoryQuizData(1);
            }
            else if (ModelIndex == 2)
            {
                belgiumManager.SetGeographyQuizDataMCQS(2);
            }
            else if (ModelIndex == 3)
            {
                belgiumManager.SetFoodQuizData(3);
            }
            else if (ModelIndex == 4)
            {
                belgiumManager.SetCultureQuizDataMCQS(4);
            }
        }
        else if (gameData.SelectedRoom.Equals(2))
        {
            if (ModelIndex == 1)
            {
                greeceManager.SetHistoryQuizData(1);
            }
            else if (ModelIndex == 2)
            {
                greeceManager.SetGeographyQuizData(2);
            }
            else if (ModelIndex == 3)
            {
                greeceManager.SetFoodQuizData(3);
            }
            else if (ModelIndex == 4)
            {
                greeceManager.SetCultureQuizData(4);
            }
        }
        else if (gameData.SelectedRoom.Equals(3))
        {
            if (ModelIndex == 1)
            {
                mathManager.SetHistoryQuizDataMCQS(1);
            }
            else if (ModelIndex == 2)
            {
                mathManager.SetGeographyQuizDataMCQS(2);
            }
            else if (ModelIndex == 3)
            {
                mathManager.SetFoodQuizData(3);
            }
            else if (ModelIndex == 4)
            {
                mathManager.SetCultureQuizData(4);
            }
        }
        else if (gameData.SelectedRoom.Equals(4))
        {
            if (ModelIndex == 1)
            {
                polandManager.SetHistoryQuizDataMCQS(1);
            }
            else if (ModelIndex == 2)
            {
                polandManager.SetGeographyQuizData(2);
            }
            else if (ModelIndex == 3)
            {
                polandManager.SetFoodQuizData(3);
            }
            else if (ModelIndex == 4)
            {
                polandManager.SetCultureQuizData(4);
            }
        }
        else if (gameData.SelectedRoom.Equals(5))
        {
            if (ModelIndex == 1)
            {
                portugalManager.SetHistoryQuizData(1);
            }
            else if (ModelIndex == 2)
            {
                portugalManager.SetGeographyQuizData(2);
            }
            else if (ModelIndex == 3)
            {
                portugalManager.SetFoodQuizData(3);
            }
            else if (ModelIndex == 4)
            {
                portugalManager.SetCultureQuizData(4);
            }
        }
    }
}

// 1- Uk
// 2- Belguim
// 3- Greece
// 3- Math
// 3- Poland
// 3- Portagual