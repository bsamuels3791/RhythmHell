using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RhythmObject : MonoBehaviour {
    protected BeatMachine beatMachine;

	// Use this for initialization
	void Awake () {
        beatMachine = GameObject.Find("Rhythm").GetComponent<BeatMachine>();
	}
}
