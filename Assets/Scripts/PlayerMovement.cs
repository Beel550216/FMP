using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public CharacterController controller;
    public Transform Cam;

    public Animator anim;

    public float speed = 5f;

    public float turnSmoothTime = 0.3f;
    float turnSmoothVelocity;

    private Vector3 playerVelocity;

    float gravity = -9.8f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public GameObject endScreen;
    public GameObject playerModel;

    bool isGrounded;

    public PlayerScript pScript;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //anim = GetComponent<Animator>();

         pScript = GameObject.Find("player Variant 1").GetComponent<PlayerScript>();

    }

    void Update()
    {
        speed = 5f;

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

        
        
        playerVelocity.y += gravity * Time.deltaTime;

        controller.Move(playerVelocity * Time.deltaTime);



        if (direction.magnitude >= 0.1f)
        {
            //anim.SetBool("walk", true);
           

            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 9f;

                //Animate(3);
                
            }
            else
            {
                speed = 4f;
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

            if (hit.gameObject.activeSelf == false)
            {
                print("!");
            }

            if (hit.gameObject.activeSelf == true)
            {
                hit.gameObject.SetActive(false);
            }

            endScreen.SetActive(true);
}
    }

}
