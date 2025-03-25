using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public CharacterController controller;

    public Animator anim;
    public GameObject playerActions;
    public TMP_Text playerActionText;
    public GameObject coin;

    private Vector3 playerVelocity;
    public float jumpPower = 1f;
    public float gravity = -9.8f;
    public float turnSmoothTime = 0.3f;
    float turnSmoothVelocity;
    public Transform Cam;
    public float speed = 2f;

    //public float buttonNumber = 1f;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Night Fever")
        {
            Animate(1);
            Dance();
        }

        if (SceneManager.GetActiveScene().name == "Minigame 1")
        {
            Movement();
        }
    }


    void Movement()
    {
        //isGrounded

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        playerVelocity.y += gravity * Time.deltaTime;

        controller.Move(playerVelocity * Time.deltaTime);

        
        if (direction.magnitude >= 0.1f)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 9f;

                Animate(3);
                
            }
            else
            {
                speed = 5f;
            }

            Animate(2);
            

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {

        }
        if (Input.GetKey(KeyCode.A))
        {

        }
        if (Input.GetKey(KeyCode.S))
        {

        }
        if (Input.GetKey(KeyCode.D))
        {

        }
    }




    void Dance()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Pose1();
            playerActionText.text = "A";
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Pose2();
            playerActionText.text = "S";
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Pose3();
            playerActionText.text = "D";
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Pose4();
            playerActionText.text = "F";
        }

    }

    public void Pose1()
    {
        Animate(2);
        print("Pose 1");
    }
    public void Pose2()
    {
        Animate(3);
        print("Pose 2");
    }
    public void Pose3()
    {
        Animate(4);
        print("Pose 3");
    }
    public void Pose4()
    {
        Animate(5);
        print("Pose 4");
    }






    void Animate(int num)
    {
        if (num == 1)
        {
            anim.SetBool("pose1", false);
            anim.SetBool("pose2", false);
            anim.SetBool("pose3", false);
            anim.SetBool("pose4", false);
        }

        if (num == 2)
        {
            anim.SetBool("pose1", true);
        }

        if (num == 3)
        {
            anim.SetBool("pose2", true);
        }

        if (num == 4)
        {
            anim.SetBool("pose3", true);
        }

        if (num == 5)
        {
            anim.SetBool("pose4", true);
        }




        if (num == 6)
        {
            anim.SetBool("walk", true);
        }

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "coin")
        {
            if (coin.gameObject.activeSelf == false)
            {
                print("!");
            }

            if (coin.gameObject.activeSelf == true)
            {
                coin.SetActive(false);
            }
        }
    }

    }
