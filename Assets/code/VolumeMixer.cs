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
        Debug.Log(audioSlider.value);
        sound = PlayerPrefs.GetFloat("Volume", audioSlider.value);
        if (PlayerPrefs.HasKey("Volume") == false)
        {
            PlayerPrefs.SetFloat("Volume", audioSlider.value);
        }
        else
        {
            if (sound == -40f) masterMixer.SetFloat("BGM", -80);
            else masterMixer.SetFloat("BGM", PlayerPrefs.GetFloat("Volume", audioSlider.value)) ;
        }


        
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
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.GetFloat("Volume", audioSlider.value);
    }
}
