using UnityEngine;
using TMPro;

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
        Animate(1);
        Dance();

    }

    void Dance()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Pose1();
            playerActionText.text = "A";
        }
        if (Input.GetKey(KeyCode.S))
        {
            Pose2();
            playerActionText.text = "S";
        }
        if (Input.GetKey(KeyCode.D))
        {
            Pose3();
            playerActionText.text = "D";
        }
        if (Input.GetKey(KeyCode.F))
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

    }

}
