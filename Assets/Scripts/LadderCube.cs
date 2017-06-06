using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderCube : MonoBehaviour {
	public Item Ladder;
	// Use this for initialization
	void Start () {
		Ladder = new Item(Item.Items.Other);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
