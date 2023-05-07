using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMix;
    //pubilc Slider musicSlider

    public void SetVolume (float volume){
        audioMix.SetFloat("volume", volume);
        //Debug.log(volume);
    }
}
