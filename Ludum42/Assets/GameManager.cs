using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public List<float> charactersHealth = new List<float>(); // a list that contains health of all characters
    public Text textDisplayer;
    public Button nextButton;

    private enum States
    {
        Intro1, Opinions1, Combat1, Pass1
    }
    private States myState;

    // Use this for initialization
    void Start () {
        textDisplayer = GameObject.Find("TextDisplayer").GetComponent<Text>();
        charactersHealth.Add(10f);
        charactersHealth.Add(10f);
        charactersHealth.Add(10f);
        charactersHealth.Add(10f);

        myState = States.Intro1;
    }
	
	// Update is called once per frame
	void Update () {
        print(myState);
        if (myState == States.Intro1) { Intro1(); }
        else if (myState == States.Opinions1) { Opinions1(); }
        else if (myState == States.Pass1) { Pass1(); }
        else if (myState == States.Combat1) { Combat1(); }
    }

    void Intro1() {
        textDisplayer.text = "A hooded figure apears from shadow.";
    }

    void Opinions1() {
        textDisplayer.text = "Detective: Let's see the face under that hood. \n" +
            "Priest: Hold on, let me talk to him first.";
    }

    void Combat1() {
        textDisplayer.text = "hooded figure move to attack.";
        
    }

    void Pass1() {
        textDisplayer.text = "hooded figure disapeared back into shadow.";
    }

    public void Next() {
        if (myState == States.Intro1) { myState = States.Opinions1; }
    }

    public void OpinionDetective()
    {
        if (myState == States.Opinions1) { myState = States.Combat1; }
    }
    public void OpinionArtist()
    {
    }
    public void OpinionSurgeon()
    {
    }
    public void OpinionPriest()
    {
        if (myState == States.Opinions1) { myState = States.Pass1; }
    }
}
