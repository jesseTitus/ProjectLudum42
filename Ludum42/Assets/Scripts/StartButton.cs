﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class StartButton : MonoBehaviour {

    public string GameSceneName;
    public AudioClip highlightNoise;

    AudioSource audioSource;
    SpriteRenderer spriteRenderer;
    public Color higlight;
    Color unhighlight;
    bool activated;
    bool highlighted;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        unhighlight = spriteRenderer.color;
        audioSource = GetComponent<AudioSource>();
	}

    void OnMouseOver()
    {
        //Highlight
        spriteRenderer.color = higlight;
        if (!highlighted && !activated)
        {
            highlighted = true;
            AudioSource.PlayClipAtPoint(highlightNoise, Vector3.zero);
        }
    }

    void OnMouseExit()
    {
        //unhightlight
        if (!activated)
        {
            spriteRenderer.color = unhighlight;
            highlighted = false;
        }
    }

    public void Activate()
    {
        if (!activated)
        {
            activated = true;
            audioSource.Play();
            StartCoroutine("NextScene");
        }
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(0.5f);
        if (GameSceneName == "Quit") Application.Quit();
        SceneManager.LoadScene(GameSceneName);
        yield return null;
    }

    void OnMouseDown()
    {
        Activate();
    }
}
