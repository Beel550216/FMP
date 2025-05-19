using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    
    public CharacterController controller;
    public Transform Cam;

    public Animator anim;

    public float speed = 5f;

    public float turnSmoothTime = 0.3f;
    float turnSmoothVelocity;

    private Vector3 playerVelocity;

    float gravity = -20.8f;

    public float jumpHeight = 2.0f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public GameObject playerModel;

    bool isGrounded;

    public PlayerScript pScript;
    public PointsTracker pT;
    public LevelManager LM;
    public AudioManager aM;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        pScript = GameObject.Find("player Variant 1").GetComponent<PlayerScript>();
        pT = GameObject.Find("Points tracker").GetComponent<PointsTracker>();
        LM = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        aM = GameObject.Find("Audio Manager").GetComponent<AudioManager>();

    }

    void Update()
    {
        speed = 1.8f;

        Movement();
        //print("velocity y=" + playerVelocity.y);
    }
              
    void Movement()
    {
        pScript.Animate(7);
        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isGrounded = controller.isGrounded;
        print("Grounded");

        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;



        if (controller.isGrounded)
        {
            print("grounded");

        }
        else 
        {
            print("not grounded");
        }



        if (Input.GetButtonDown("Jump") && isGrounded && SceneManager.GetActiveScene().name == "Target Practice")
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
        
        playerVelocity.y += gravity * Time.deltaTime;

        controller.Move(playerVelocity * Time.deltaTime);



        if (direction.magnitude >= 0.1f)
        {
            //anim.SetBool("walk", true);
           

            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 3f;
                //Animate(3);
            }
            else
            {
                if (SceneManager.GetActiveScene().name == "Target Practice")
                {
                    speed = 4f;
                }
                else
                {
                   speed = 1.8f;
                }
                
            }

            pScript.Animate(6);

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("coin"))
        {
            print("Colided");
            pT.AddPoints(100);

            aM.playSFX(1);

            if (hit.gameObject.activeSelf == false)
            {
                print("!");
            }

            if (hit.gameObject.activeSelf == true)
            {
                hit.gameObject.SetActive(false);
            }
            LM.EndOfRound();
        }
    }

}