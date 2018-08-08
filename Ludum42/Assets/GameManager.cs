using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public List<float> charactersHealth = new List<float>(); // a list that contains health of all characters
    public Text textDisplayer; 

    // Use this for initialization
    void Start () {
        textDisplayer = GameObject.Find("TextDisplayer").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	}
}
