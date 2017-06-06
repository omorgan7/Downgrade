using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyballScalar : MonoBehaviour {

	public GameObject mazecontainer;
	private MazeController maze;
	// Use this for initialization
	void Start () {
		maze = mazecontainer.GetComponent<MazeController>();
		float scaleFactor = maze.cubeWidth * maze.width * 2f;
		gameObject.transform.localScale = gameObject.transform.localScale * scaleFactor;
		gameObject.transform.position = new Vector3(-1*gameObject.transform.localScale.x * 0.5f,0f,-1*gameObject.transform.localScale.z * 0.5f);
	}
}
