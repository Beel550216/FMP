using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public Animator anim;
    public GameObject playerActions;
    public TMP_Text playerActionText;

    //public float buttonNumber = 1f;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Night Fever")
        {
            anim.SetBool("disco", true);
            Animate(1);
            Dance();
        }

        if (SceneManager.GetActiveScene().name == "Maze")
        {
            anim.SetBool("maze", true);
            //Animate(1);

            /*if (Message = "walk")
            {
                Animate(6);
            }*/
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






    public void Animate(int num)
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
        if (num == 7)
        {
            anim.SetBool("walk", false);
        }


    }

    }
