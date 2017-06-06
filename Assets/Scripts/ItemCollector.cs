using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemCollector : MonoBehaviour {
	public GameObject popup_box;
	private GameObject boxp;

	// Use this for initialization
	void Start () {
		
	}
	   void OnTriggerEnter(Collider other){;
            if (other.gameObject.CompareTag ("Pick Up")){
                GameObject box = other.gameObject;
                LightCube L = box.GetComponent<LightCube>();
				DroneCube D = box.GetComponent<DroneCube>();
				LadderCube Ld = box.GetComponent<LadderCube>();
				WeaponCube W = box.GetComponent<WeaponCube>();
				if(L!=null){
					L.Light.increase_number(Item.Items.Light);
					boxp = Instantiate(popup_box, Vector3.zero, Quaternion.identity);
					BoxText text = boxp.GetComponent<BoxText>();
					text.Setup("torch");
				}
				if(D!=null){
					D.Drone.increase_number(Item.Items.Drone);
					boxp = Instantiate(popup_box, Vector3.zero, Quaternion.identity);
					BoxText text = boxp.GetComponent<BoxText>();
					text.Setup("drone");
				}
				if(Ld!=null){
					Ld.Ladder.increase_number(Item.Items.Other);
					boxp = Instantiate(popup_box, Vector3.zero, Quaternion.identity);
					BoxText text = boxp.GetComponent<BoxText>();
					text.Setup("ladder");
				}
				if(W!=null){
					W.Weapon.increase_number(Item.Items.Weapon);
					boxp = Instantiate(popup_box, Vector3.zero, Quaternion.identity);
					BoxText text = boxp.GetComponent<BoxText>();
					text.Setup("teleport cube");
				}
                box.SetActive (false); 
				Destroy(box);
            }
        }
	// Update is called once per frame
	void Update () {
		
	}
}
