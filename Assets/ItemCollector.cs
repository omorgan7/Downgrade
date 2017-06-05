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
				L.Light.increase_number(Item.Items.Light);
				print(L.Light.return_number_of_items());
                box.SetActive (false); 
            }
        }
	// Update is called once per frame
	void Update () {
		
	}
}
