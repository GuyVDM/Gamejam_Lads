using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Mixer_Manager : MonoBehaviour {

    [SerializeField]private AudioMixer masterMixer;

    public void SetSound(float soundLevel) {
        masterMixer.SetFloat("musicVol", soundLevel);
    }
}

