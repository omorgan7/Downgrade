using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneCube : MonoBehaviour {
	public Item Drone;
	// Use this for initialization
	void Start () {
		Drone = new Item(Item.Items.Drone);	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
