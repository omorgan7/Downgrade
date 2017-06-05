using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour {

	public GameObject InventoryCanves;
	// Use this for initialization
	void Start () {
		InventoryCanves.SetActive(false);
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.I)){
			InventoryCanves.SetActive(true);
		}
		
	}
}
