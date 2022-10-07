using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public AudioSource bgAudio;

    public GameObject AudioOffBtn, AudioOnBtn;
    public Slider AudioSlider;

    bool isAudioPaused = false;
    public float AudioVolume = 1f;

    void Start()
    {
        GetSavedAudioVolumeValue();
    }

    void GetSavedAudioVolumeValue()
    {
        AudioVolume = PlayerPrefs.GetFloat("Volume");
        bgAudio.volume = AudioVolume;
        AudioSlider.value = AudioVolume;
    }

    void Update()
    {
        bgAudio.volume = AudioVolume;
        PlayerPrefs.SetFloat("Volume", AudioVolume);
        ToggleBgAudio();
        MatchBtnWithSlider();
        MatchVolumeWithSlider();
    }

    public void UpdateVolume(float Volume)
    {
        AudioVolume = Volume;
    }

    private void ToggleBgAudio()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (isAudioPaused == false)
            {
                bgAudio.Pause();
                isAudioPaused = true;
                AudioOnBtn.SetActive(false);
                AudioOffBtn.SetActive(true);
                AudioSlider.value = 0f;
            }
            else
            {
                bgAudio.UnPause();
                isAudioPaused = false;
                AudioOnBtn.SetActive(true);
                AudioOffBtn.SetActive(false);
                AudioSlider.value = 1f;
            }
        }
    }

    public void ToggleAudioOnBtn()
    {
        bgAudio.UnPause();
        isAudioPaused = false;
        AudioOnBtn.SetActive(true);
        AudioOffBtn.SetActive(false);
        AudioSlider.value = 1f;
    }

    public void ToggleAudioOffBtn()
    {
        bgAudio.Pause();
        isAudioPaused = true;
        AudioOnBtn.SetActive(false);
        AudioOffBtn.SetActive(true);
        AudioSlider.value = 0f;
    }

    public void MatchVolumeWithSlider()
    {
        if(AudioSlider.value > 0)
        {
            bgAudio.UnPause();
            isAudioPaused = false;
        }
        else if(AudioSlider.value == 0)
        {
            bgAudio.Pause();
            isAudioPaused = true;
        }
    }

    public void MatchBtnWithSlider()
    {
        if (bgAudio.volume == 0f)
        {
            AudioOnBtn.SetActive(false);
            AudioOffBtn.SetActive(true);
        }
        else
        {
            AudioOnBtn.SetActive(true);
            AudioOffBtn.SetActive(false);
        }
    }
}
