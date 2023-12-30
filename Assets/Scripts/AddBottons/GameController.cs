using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    [SerializeField]
    private Sprite bgimage;
    [SerializeField]
    private Sprite DestroyImage;
    public List<Button> btns = new List<Button>();

    public Sprite[] puzzles;
    public List<Sprite> gamepuzzle = new List<Sprite>();

    private bool FirstGuess, SecondGuess;
    private int CountGuesses;
    private int CountCorrectGuesses;
    private int GameGuesses;
    private int FirstGuessIndex, SecondGuessIndex;
    private string FirstGuessPuzzle, SecondGuessPuzzle;
    private void Awake()
    {
        puzzles = Resources.LoadAll<Sprite>("Sprites/Images");
    }
    void Start()
    {
        getbutton();
        Addlisteners();
        AddGamePuzzles();
        Shuffle(gamepuzzle);
        GameGuesses = gamepuzzle.Count / 2;
    }
    void getbutton()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");
        for (int i = 0; i < objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgimage;
        }
    }
    void AddGamePuzzles()
    {
        int looper = btns.Count;
        int index = 0;

        for (int i = 0; i < looper; i++)
        {
            if(index == looper / 2)
            {
                index = 0;
            }
            gamepuzzle.Add(puzzles[index]);
            index++;
        }
    }
    void Addlisteners()
    {
        foreach (Button btn in btns)
            btn.onClick.AddListener(() => PickPuzzle());
    }
    public void PickPuzzle()
    {
        

        if (!FirstGuess)
        {
            FirstGuess = true;
            FirstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            FirstGuessPuzzle = gamepuzzle[FirstGuessIndex].name;
            btns[FirstGuessIndex].image.sprite = gamepuzzle[FirstGuessIndex];
        }
        else if (!SecondGuess)
        {
            SecondGuess = true;
            SecondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            SecondGuessPuzzle = gamepuzzle[SecondGuessIndex].name;
            btns[SecondGuessIndex].image.sprite = gamepuzzle[SecondGuessIndex];
            CountGuesses++;
            StartCoroutine(CheckIfPuzzleMatch());

        }
    }
    IEnumerator CheckIfPuzzleMatch()
    {
        yield return new WaitForSeconds(1f);
        if (FirstGuessPuzzle == SecondGuessPuzzle)
        {
            //CheckIfGameFinished();
            yield return new WaitForSeconds(.5f);

            btns[FirstGuessIndex].interactable = false;
            btns[SecondGuessIndex].interactable = false;

            btns[FirstGuessIndex].image.sprite = DestroyImage;
            btns[SecondGuessIndex].image.sprite = DestroyImage;


            CheckIfGameFinished();
        }
        else
        {
            yield return new WaitForSeconds(.5f);

            btns[FirstGuessIndex].image.sprite = bgimage;
            btns[SecondGuessIndex].image.sprite = bgimage;
        }
        yield return new WaitForSeconds(.5f);

        FirstGuess = SecondGuess = false;
    }
    void CheckIfGameFinished()
    {
        CountCorrectGuesses++;
        if(CountCorrectGuesses == GameGuesses)
        {
            Debug.Log("Game finished");
            Debug.Log("it took you " + CountGuesses + " guesses to finish the game");
        }
    }
    void Shuffle(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int RandomIndex = Random.Range(0, list.Count);
            list[i] = list[RandomIndex];
            list[RandomIndex] = temp;
        }
    }

}
