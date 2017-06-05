using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Close : MonoBehaviour {
	public Button yourButton;
	public GameObject parent;

	// Use this for initialization
	void Start () {
			yourButton.onClick.AddListener(TaskOnClick);
	}
	
	// Update is called once per frame
	void TaskOnClick () {
		Destroy(parent);
	}
}
