using UnityEngine;

public class RoomCompleteHandular : MonoBehaviour
{
    [SerializeField] private UKManager uKManager;
    [SerializeField] private GreeceManager greeceManager;
    [SerializeField] private BelgiumManager belgiumManager;
    [SerializeField] private MathManager mathManager;
    [SerializeField] private PolandManager polandManager;
    [SerializeField] private PortugalManager portugalManager;
    [SerializeField] private GameData gameData;

    private void Start()
    {
        uKManager = FindObjectOfType<UKManager>();
        greeceManager = FindObjectOfType<GreeceManager>();
        belgiumManager = FindObjectOfType<BelgiumManager>();
        mathManager = FindObjectOfType<MathManager>();
        polandManager = FindObjectOfType<PolandManager>();
        portugalManager = FindObjectOfType<PortugalManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (gameData.SelectedRoom.Equals(0))
            {
                uKManager.CompleteRoom();
            }
            else if (gameData.SelectedRoom.Equals(1))
            {
                belgiumManager.CompleteRoom();
            }
            else if (gameData.SelectedRoom.Equals(2))
            {
                greeceManager.CompleteRoom();
            }
            else if (gameData.SelectedRoom.Equals(3))
            {
                mathManager.CompleteRoom();
            }
            else if (gameData.SelectedRoom.Equals(4))
            {
                polandManager.CompleteRoom();
            }
            else if (gameData.SelectedRoom.Equals(5))
            {
                portugalManager.CompleteRoom();
            }
        }
    }
}
