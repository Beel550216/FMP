using System;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Animator anim;

    public GameObject bow;
    public GameObject bowEnd;
    public GameObject player;
    public GameObject arrowPrefab;

    public Transform shootPoint;

    public AudioManager AudioM;

    public AudioClip shootingSound;
    private AudioSource shootingAudio;

    private Vector3 target;           
    void Start()
    {
        shootingAudio = GetComponent<AudioSource>();

        anim = GameObject.Find("Player").GetComponent<Animator>();

        AudioM = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
    }


    void Update()
    {
        anim.SetBool("shoot", false);


        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("shoot", true);

            AudioM.playSFX(1);

            GameObject arrow = Instantiate(arrowPrefab, bowEnd.transform.position, transform.rotation);

            Rigidbody rb = arrow.GetComponent<Rigidbody>();
            rb.linearVelocity = arrow.transform.forward * 20;

            print("shoot");
        }
    }
}
