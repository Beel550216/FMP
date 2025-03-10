using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bow;
    public GameObject bowEnd;
    public GameObject player;
    public GameObject arrowPrefab;

    public AudioClip shootingSound;
    private AudioSource shootingAudio;

    private Vector3 target;
    void Start()
    {
        //Cursor.visible = false;
        shootingAudio = GetComponent<AudioSource>();
    }


    void Update()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        bow.transform.position = new Vector3(target.x, target.y);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject arrow = Instantiate(arrowPrefab, bowEnd.transform.position, Quaternion.identity);
            arrow.transform.LookAt(target);
            Rigidbody b = arrow.GetComponent<Rigidbody>();
            b.AddRelativeForce(Vector3.forward);

            shootingAudio.PlayOneShot(shootingSound, 1.0f);
        }

    }
}
