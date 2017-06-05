using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescription : MonoBehaviour {
	public GameObject ItemName;
	public GameObject Item_Description;
	private Text item_name;
	private Text description;
	public Button close;
	public Button use;
	public GameObject parent;

	// Use this for initialization
	void Start () {
		item_name = ItemName.GetComponent<Text>();
		description = Item_Description.GetComponent<Text>();
		close.onClick.AddListener(TaskOnClick);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void SetUp(Item newItem ){
		item_name = ItemName.GetComponent<Text>();
		description = Item_Description.GetComponent<Text>();
		item_name.text = newItem.getName();
		description.text = newItem.getDescription();
	}
	void TaskOnClick(){
		Destroy(parent);
	}
}
