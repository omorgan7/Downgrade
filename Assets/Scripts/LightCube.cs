using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCube : MonoBehaviour {

public Item Light;
	// Use this for initialization
	void Start () {
		Light = new Item(Item.Items.Light);		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
