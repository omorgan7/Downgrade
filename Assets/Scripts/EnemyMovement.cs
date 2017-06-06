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
    bool playerDead;
    public Color rayColor;
    Animator anim;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerLoc = GameObject.FindGameObjectWithTag("Player").transform;
        ray = new Ray(transform.position, transform.forward * 10);
        Debug.DrawRay(transform.position, transform.forward * 10, rayColor);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            anim.SetTrigger("PlayerDead");
        }
    }


    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, 10))
        {
            playerInRange = true;
            anim.SetTrigger("IsDetected");
        }

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
