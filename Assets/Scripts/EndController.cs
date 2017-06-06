using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndController : MonoBehaviour {

    Transform playerLoc;
    GameObject player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
		print(player);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
			player.transform.localPosition = new Vector3(4f,1f,4f);
        }
    }
}
