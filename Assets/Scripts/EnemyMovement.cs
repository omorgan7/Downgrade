using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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
    AudioSource enemyAudio;
    public AudioClip attackClip;
    bool firstTime = true;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerLoc = GameObject.FindGameObjectWithTag("Player").transform;
        ray = new Ray(transform.position, transform.forward * 10);
        Debug.DrawRay(transform.position, transform.forward * 10, rayColor);
        anim = gameObject.GetComponent<Animator>();
        enemyAudio = gameObject.GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player){
            SceneManager.LoadScene("Main_owen_2",LoadSceneMode.Single);
        }
    }


    void Update(){  
        if (Physics.Raycast(transform.position, transform.forward, 10))
        {
            playerInRange = true;
            anim.SetTrigger("IsDetected");
            if(firstTime){
                ChangeAudio();
                firstTime = false;
            }

        }

        if (playerInRange){
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerLoc.position - transform.position), rotationSpeed * Time.deltaTime);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }
    private void ChangeAudio(){
        enemyAudio.Stop();
        enemyAudio.clip = attackClip;
        enemyAudio.Play();
        enemyAudio.loop = true;
    }
}
