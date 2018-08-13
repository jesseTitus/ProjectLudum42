using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButton : MonoBehaviour {

    public Choice choice1;

    AudioSource aSource;

    void Start()
    {
        aSource = GetComponent<AudioSource>();
    }

    public void Click()
    {
        if (!choice1.availableChoice)
        {
            aSource.Play();
        }
    }
}
