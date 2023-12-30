
using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;


public class SoundManager : MonoBehaviour
{

	private static SoundManager instance;

	public static SoundManager Instance
	{
		get
		{
			if (instance == null)
			{
				GameObject go = new GameObject("PersistentDataManager");
				instance = go.AddComponent<SoundManager>();
				DontDestroyOnLoad(go);
			}
			return instance;
		}
	}
	const string PLAYER_PREFS_KEY = "sounds_settings_key";
	[FormerlySerializedAs("_defaultBGClip")] public AudioClip defaultBgClip = null;

	[FormerlySerializedAs("_soundEnabled")] public bool soundEnabled = true;
	[FormerlySerializedAs("_BGAudioSource")] public AudioSource bgAudioSource;
	[FormerlySerializedAs("_FGAudioSource")] public AudioSource fgAudioSource;
	[FormerlySerializedAs("_effectsVolume")] public float effectsVolume = 0;
	[FormerlySerializedAs("_musicVolume")] public float musicVolume = 0;


    void Awake()
    {
        fgAudioSource = gameObject.AddComponent<AudioSource>();
        fgAudioSource.name = "(AudioSource)FG";
        bgAudioSource = gameObject.AddComponent<AudioSource>();
        bgAudioSource.name = "(AudioSource)BG";
        // load Persistent Settings
        //@TODO: persistence by object serialization
        soundEnabled = bool.Parse(PlayerPrefs.GetString(PLAYER_PREFS_KEY, soundEnabled.ToString()));
    }

	public float EffectsVolume {
		set { 
			effectsVolume = value;
			if (effectsVolume < 0) {
				effectsVolume = 0;
			}
			fgAudioSource.volume = Mathf.Clamp01 (effectsVolume);
		}
	}
	public float MusicVolume {
		set { 
			musicVolume = value;
			if (musicVolume < 0) {
				musicVolume = 0;
			}
			bgAudioSource.volume = Mathf.Clamp01 (musicVolume);
		}
	}
	

	public void Play ()
	{
		if (defaultBgClip ==null) {
			Debug.LogWarning ("Default Audio Clip is required for SoundManager ");
			return;
		}
		PlayBackgroundMusic (defaultBgClip);
	}


	public void PlayEffect (AudioClip _clip)
	{
		if (soundEnabled & _clip != null) {
			fgAudioSource.PlayOneShot (_clip);
		}
	}
	

	public void PlayBackgroundMusic (AudioClip _clip)
	{
		if (soundEnabled && _clip != null) {
			bgAudioSource.clip = _clip;
			bgAudioSource.loop = true;
			bgAudioSource.Play ();
		}
	}

}
