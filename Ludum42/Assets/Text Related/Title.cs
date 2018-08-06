using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Title : MonoBehaviour {

    public Text myText;          //actual text onscreen
    public List<string> prologue;   //a list of lines to feed the prologue before the main menu hits

    int currentLine = 0;    //current line the prologue is on
    Animator anim;      //to control which fade-in / fade-out if needed


    
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	public void NextLine()
    {
        if (++currentLine < prologue.Count)
        {
            //move to the next line of the prologue to be displayed
            myText.text = prologue[currentLine];
        } else
        {
            //TODO - when prologue ends, show outline of cthulhu, and then title screen
            anim.SetTrigger("Reveal");
        }
    }
}
