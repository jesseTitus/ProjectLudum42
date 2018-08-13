using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionSet : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        Screen.SetResolution(800, 600, false);
	}
}
