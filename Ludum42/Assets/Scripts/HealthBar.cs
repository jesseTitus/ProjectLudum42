using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    GameManager gameManger;
    Slider slider;
    //Image fill;       //HP BG now red, so this is redundant

	// Use this for initialization
	void Start () {
        gameManger = GameObject.Find("GameManager").GetComponent<GameManager>();
        slider = this.GetComponent<Slider>();

        //fill = transform.Find("Fill").GetComponent<Image>();  //replaced
	}
	
	// Update is called once per frame
	void Update () {
        if (this.name == "DetectiveHealthBar")
        {
            slider.value = gameManger.charactersCurrentHealth[0] / gameManger.charactersMaxHealth[0];
        }
        else if (this.name == "ArtistHealthBar")
        {
            slider.value = gameManger.charactersCurrentHealth[1] / gameManger.charactersMaxHealth[1];
        }
        else if (this.name == "SurgeonHealthBar")
        {
            slider.value = gameManger.charactersCurrentHealth[2] / gameManger.charactersMaxHealth[2];
        }
        else if (this.name == "PriestHealthBar")
        {
            slider.value = gameManger.charactersCurrentHealth[3] / gameManger.charactersMaxHealth[3];
        }
        else
        {
            Debug.Log("character not found");
        }


        //if (slider.value > 0.4)       //made BG red so this is irrelevant
        //{
        //    fill.color = Color.white;
        //}
        //else {
        //    fill.color = Color.red;
        //}

    }
}
