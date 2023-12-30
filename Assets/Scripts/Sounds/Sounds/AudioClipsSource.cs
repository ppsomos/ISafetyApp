using UnityEngine;


public class AudioClipsSource : MonoBehaviour
{
    public static AudioClipsSource Instance;

    [Header("Music Clips")]
    public AudioClip BGSound;
    public AudioClip ButtonClick;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
