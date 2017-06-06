using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour {

	public GameObject InventoryCanves;
	private GameObject box;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.I)){
			box = Instantiate(InventoryCanves, Vector3.zero, Quaternion.identity);
			box.SetActive(true);
		}
		
	}
	public void delete(){
		Destroy(InventoryCanves);
	}
}
