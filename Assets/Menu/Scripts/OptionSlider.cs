using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionSlider : MonoBehaviour
{
    //variavel que recebe o slider
    public Slider volume;

    //variavel que recebe o audio mixer
    [SerializeField] private AudioMixer aMixer;
    
    void Start()
    {
    volume.value = 0;
    //começa o volume como 0
    aMixer.SetFloat("AudioSong", -80);
    }

    //função que mexe com o volume do game
    public void VolumeChange()
    {
        aMixer.SetFloat("AudioSong", -80 + (volume.value * 17));
    }
}
