using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundController : MonoBehaviour {

	AudioSource AS;
	MazeController MC;
	// Use this for initialization
	void Start () {
		AS = gameObject.GetComponent<AudioSource>();
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		GameObject maze = GameObject.FindGameObjectWithTag("maze");
		MC = maze.GetComponent<MazeController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
