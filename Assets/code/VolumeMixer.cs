using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEditor.VersionControl;

public class VolumeMixer : MonoBehaviour
{
    public AudioMixer masterMixer;
    public Slider audioSlider;
    public Image Speaker;
    public Sprite SpeakerOff;
    public Sprite SpeakerOn;
    float sound;
    public void AudioControl()
    {
        // �����̴� �� ����
        float currentVolume = audioSlider.value;
        PlayerPrefs.SetFloat("Volume", currentVolume);
        PlayerPrefs.Save();

        // ���� ����
        SetVolume(currentVolume);
    }

    public void ToggleAudioVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
        
        if (AudioListener.volume == 0)
        {
            Speaker.sprite = SpeakerOff;
            PlayerPrefs.SetInt("Speaker", 0);
        }
        else
        {
            Speaker.sprite = SpeakerOn;
            PlayerPrefs.SetInt("Speaker", 1);
        }
        PlayerPrefs.Save();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("Volume");
            audioSlider.value = savedVolume;
            SetVolume(savedVolume);
        }

        // ����Ŀ ���� �ҷ�����
        if (PlayerPrefs.HasKey("Speaker"))
        {
            int isSpeakerOn = PlayerPrefs.GetInt("Speaker");
            Speaker.sprite = (isSpeakerOn == 1) ? SpeakerOn : SpeakerOff;
        }
    }
    private void SetVolume(float volume)
    {
        if (volume == -40f)
        {
            masterMixer.SetFloat("BGM", -80);
        }
        else
        {
            masterMixer.SetFloat("BGM", volume);
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.GetFloat("Volume", audioSlider.value);
    }
}
