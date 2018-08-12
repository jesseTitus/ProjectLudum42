using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour {
    /// <summary>
    /// This is the sound effects manager
    /// It has a public method "PlaySoundEffect()"
    /// which can be accessed by other classes to play the desired sound
    /// </summary>
    AudioSource soundFXManager;
    public AudioClip[] sounds;

	void Start () {
        soundFXManager = GetComponent<AudioSource>();

    }
	
	public void PlaySoundEffect(int effectNum)
    {
        if (effectNum < 0 || effectNum >= sounds.Length) return;

        soundFXManager.clip = sounds[effectNum];
        soundFXManager.Play();


    }
}
