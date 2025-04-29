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

    private Vector3 target;           //
    void Start()
    {
        //Cursor.visible = false;
        shootingAudio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();

        AudioM = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
    }


    void Update()
    {
        anim.SetBool("shoot", false);


        if (Input.GetKeyDown(KeyCode.X))
        {
            anim.SetBool("shoot", true);

            AudioM.playSFX(1);

            GameObject arrow = Instantiate(arrowPrefab, bowEnd.transform.position, transform.rotation);
            //arrow.transform.LookAt(target);

            Rigidbody rb = arrow.GetComponent<Rigidbody>();
            rb.linearVelocity = arrow.transform.forward * 20;


            //shootingAudio.PlayOneShot(shootingSound, 1.0f);
            print("shoot");
        }





        /*target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));  //transform.position.z
        bow.transform.position = new Vector3(target.x, target.y, -9);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject arrow = Instantiate(arrowPrefab, bowEnd.transform.position, Quaternion.identity);
            arrow.transform.LookAt(target);
            Rigidbody b = arrow.GetComponent<Rigidbody>();
            b.AddRelativeForce(Vector3.forward);

            shootingAudio.PlayOneShot(shootingSound, 1.0f);
        }
        /*if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            //target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
            //bow.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
            GameObject clone;
            clone = Instantiate(arrowPrefab, transform.position, transform.rotation);

            Rigidbody rb = clone.GetComponent<Rigidbody>();
            rb.linearVelocity = transform.forward * 15;


            // set the position close to the player
            rb.transform.position = shootPoint.position;

        }*/


    }




     /*if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
            bow.transform.position = new Vector3(target.x, target.y);
    GameObject clone;
    clone = Instantiate(arrowPrefab, transform.position, transform.rotation);

    Rigidbody rb = clone.GetComponent<Rigidbody>();
    rb.linearVelocity = transform.forward* 15;


            // set the position close to the player
            rb.transform.position = shootPoint.position;

        }*/         //throws the bow into the background
}
