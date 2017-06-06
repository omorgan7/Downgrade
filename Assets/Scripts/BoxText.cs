using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxText : MonoBehaviour {
	public GameObject textbox;
	public GameObject parent;
	public Button yourbutton;
	private Text txt;

	// Use this for initialization
	void Start () {
		txt = textbox.GetComponent<Text>();
		yourbutton.onClick.AddListener(TaskOnClick);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Setup(string itemName){
		txt = textbox.GetComponent<Text>();
		txt.text = "You have found a " + itemName +"!";
	}
	void TaskOnClick(){
		Destroy(parent);
	}

}
