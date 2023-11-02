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
    public bool isClicked;
    public Image Speaker;
    public Sprite SpeakerOff;
    public Sprite SpeakerOn;

    public void AudioControl()
    {
        float sound = audioSlider.value;

        if (sound == -40f) masterMixer.SetFloat("BGM", -80);
        else masterMixer.SetFloat("BGM", sound);
    }

    public void ToggleAudioVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
        isClicked = !isClicked;
        if (isClicked == true)
        {
            Speaker.sprite = SpeakerOff;
        }
        else
        {
            Speaker.sprite = SpeakerOn;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
