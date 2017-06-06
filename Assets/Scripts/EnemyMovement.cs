using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform playerLoc;
    GameObject player;
    bool playerInRange;
    Ray ray;
    RaycastHit hit;
    public float rotationSpeed = 3.0f, moveSpeed = 3.0f;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerLoc = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
            print("Trigger entered");
        }
    }


    void Update()
    {

        if (playerInRange)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerLoc.position - transform.position), rotationSpeed * Time.deltaTime);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        else
        {
            playerInRange = false;
        }
    }
}
