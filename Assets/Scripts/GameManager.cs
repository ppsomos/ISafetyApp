using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int SelectedPlayer;
    public bool isSplash;
    public bool PlayFirstTimeGame;
    public int SelectedRoom;
    public bool IsMulti;
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

}
