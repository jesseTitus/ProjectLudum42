using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {
    /// <summary>
    /// This class manages music
    /// It should switch between exploration | combat 
    /// </summary>
    public AudioClip explorationMusic;
    public AudioClip combatMusic;

    AudioSource musicPlayer;

	void Start () {
        musicPlayer = GetComponent<AudioSource>();
        musicPlayer.clip = explorationMusic;
    }

    public void ChangeMusic(bool combat)
    {
        //TODO - fade IN fade OUT
        if (combat)
        {
            musicPlayer.clip = combatMusic;
        } else
        {
            musicPlayer.clip = explorationMusic;
        }
        musicPlayer.Play();
    }
    

}
