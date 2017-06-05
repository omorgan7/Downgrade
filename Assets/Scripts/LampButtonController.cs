using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LampButtonController : MonoBehaviour {
	public Button yourButton;
	public GameObject ItemName;
	public GameObject Number;
	public GameObject ItemDescription;
	private GameObject box;
	private Item item;
	private Text itemname;
	private Text itemNumber;
	private int number_of_item = 0;
	private float timeElapsed;

	

	// Use this for initialization
	void Start () {
		item = new Item(Item.Items.Light);
		yourButton.onClick.AddListener(TaskOnClick);
		itemname = ItemName.GetComponent<Text>();
		itemNumber = Number.GetComponent<Text>();
		itemname.text = item.getName();
		print(Item.item_no[0]);
		
	}
	
	// Update is called once per frame
	void Update () {
	itemNumber.text = (Item.item_no[0]).ToString();
		
	}
	void TaskOnClick(){
		box = Instantiate(ItemDescription, Vector3.zero, Quaternion.identity);
		GameObject boxPanel= GameObject.Find("DescriptionPanel");
		ItemDescription data = boxPanel.GetComponent<ItemDescription>();
		data.SetUp(item);	
	}
}
