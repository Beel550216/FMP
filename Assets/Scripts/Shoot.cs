using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bow;
    public GameObject bowEnd;
    public GameObject player;
    public GameObject arrowPrefab;

    public Transform shootPoint;

    public AudioClip shootingSound;
    private AudioSource shootingAudio;

    private Vector3 target;           //
    void Start()
    {
        //Cursor.visible = false;
        shootingAudio = GetComponent<AudioSource>();
    }


    void Update()
    {

        
        if (Input.GetKeyDown(KeyCode.X))
        {
            GameObject arrow = Instantiate(arrowPrefab, bowEnd.transform.position, Quaternion.identity);
            //arrow.transform.LookAt(target);

            Rigidbody rb = arrow.GetComponent<Rigidbody>();
            rb.linearVelocity = transform.forward * 10;


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
