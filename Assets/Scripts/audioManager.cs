using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Audio Mixer")]
    [SerializeField] private AudioMixer audioMixer;

    [Header("Exposed Mixer Parameter Names")]
    [SerializeField] private string musicParamName = "Music";
    [SerializeField] private string sfxParamName = "Sfx";

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadVolumeSettings();
    }
    public void SetMusicVolume(float sliderValue)
    {
        float dB = Mathf.Log10(Mathf.Clamp(sliderValue, 0.0001f, 1f)) * 20f;
        audioMixer.SetFloat(musicParamName, dB);

        PlayerPrefs.SetFloat("SavedMusicVolume", sliderValue);
    }
    public void SetSFXVolume(float sliderValue)
    {
        float dB = Mathf.Log10(Mathf.Clamp(sliderValue, 0.0001f, 1f)) * 20f;
        audioMixer.SetFloat(sfxParamName, dB);

        PlayerPrefs.SetFloat("SavedSFXVolume", sliderValue);
    }

    private void LoadVolumeSettings()
    {
        float musicVol = PlayerPrefs.GetFloat("SavedMusicVolume", 0.75f);
        float sfxVol = PlayerPrefs.GetFloat("SavedSFXVolume", 0.75f);

        SetMusicVolume(musicVol);
        SetSFXVolume(sfxVol);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }
}
