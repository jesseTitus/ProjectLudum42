using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice : MonoBehaviour {

    public GameManager gameManager;

    public AudioClip highlightSnd;
    public AudioClip clickSnd;

    Text mytext;
    AudioSource soundPlayer;

    //Hideables
    public GameObject button;

	void Awake () {
        mytext = GetComponentInChildren<Text>();
        soundPlayer = GetComponent<AudioSource>();
	}

    void Start()
    {
        Hide();
        //Display("Ledwell: That woman needed our help!");
    }

    public void Choose()
    {
        soundPlayer.clip = clickSnd;
        soundPlayer.Play();

        //TODO - send message back to gamemanager to continue
    }

    void OnMouseOver()
    {
        //AudioSource.PlayClipAtPoint(highlightSnd, Vector3.zero);
        soundPlayer.clip = highlightSnd;
        soundPlayer.Play();
        //soundPlayer.PlayOneShot(highlightSnd);
    }

    public void Display(string choiceTxt)
    {
        button.SetActive(true);

        mytext.text = choiceTxt;
    }

    public void Hide()
    {
        button.SetActive(false);
    }
}
