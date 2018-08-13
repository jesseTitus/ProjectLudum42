using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice : MonoBehaviour {

    public GameManager gameManager;

    public AudioClip highlightSnd;
    public AudioClip clickSnd;
    public bool availableChoice;

    Text mytext;
    AudioSource soundPlayer;

    //Hideables
    public GameObject button;
    public GameObject otherButton;  //simple way to hide both...

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
        Debug.Log("Choice made!!!");
        soundPlayer.clip = clickSnd;
        soundPlayer.Play();

        // Reply to game manager 
        if (mytext.text.Contains("Darcy"))
        {
            gameManager.OpinionDetective();
        }
        else if (mytext.text.Contains("Ledwell"))
        {

            gameManager.OpinionSurgeon();
        }
        else if (mytext.text.Contains("Talbot"))
        {

            gameManager.OpinionArtist();
        }
        else if (mytext.text.Contains("Mason"))
        {

            gameManager.OpinionPriest();
        }

        // Choice COMPLETE
        Hide();
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
        availableChoice = true; //for next button click sound - checking
        button.SetActive(true);

        mytext.text = choiceTxt;
    }

    public void Hide()
    {
        availableChoice = false;
        otherButton.SetActive(false);
        button.SetActive(false);
    }
}
