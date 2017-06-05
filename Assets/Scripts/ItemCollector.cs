using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour {

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
					print("light");
					L.Light.increase_number(Item.Items.Light);
				}
				if(D!=null){
					D.Drone.increase_number(Item.Items.Drone);
				}
				if(Ld!=null){
					Ld.Ladder.increase_number(Item.Items.Other);
				}
				if(W!=null){
					W.Weapon.increase_number(Item.Items.Weapon);
				}
                box.SetActive (false); 
				Destroy(box);
            }
        }
	// Update is called once per frame
	void Update () {
		
	}
}
