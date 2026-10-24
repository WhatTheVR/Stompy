using UnityEngine;
using UnityEngine.UI;

public class valueConnector : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    void Start()
    {
        if (musicSlider != null)
        {
            musicSlider.value = PlayerPrefs.GetFloat("SavedMusicVolume", 0.75f);
            musicSlider.onValueChanged.AddListener(AudioManager.Instance.SetMusicVolume);
        }

        if (sfxSlider != null)
        {
            sfxSlider.value = PlayerPrefs.GetFloat("SavedSFXVolume", 0.75f);
            sfxSlider.onValueChanged.AddListener(AudioManager.Instance.SetSFXVolume);
        }
    }
}
