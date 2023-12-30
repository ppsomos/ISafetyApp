using UnityEngine;
using UnityEngine.UI;

public class PosterHandular : MonoBehaviour
{
    public int PosterNo;
    public Transform PostersParent;
    public GameObject Scrollview;
    public GameObject CloseButton;
    public Button Readmore;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Readmore.gameObject.SetActive(true);
            Readmore.onClick.RemoveAllListeners();
            Readmore.onClick.AddListener(() => ActivePoster(PosterNo));
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Readmore.gameObject.SetActive(false);
    }

    private void ActivePoster(int index)
    {
        CloseButton.SetActive(true);
        Scrollview.SetActive(true);
        PostersParent.GetChild(index).gameObject.SetActive(true);
    }
}
