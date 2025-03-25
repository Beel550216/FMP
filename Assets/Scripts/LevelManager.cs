using UnityEngine;
 using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;

    public Animator anim;
    public int counter;
    public int camCount;
    public GameObject textBox;
    public GameObject next;
    public GameObject back;
    public GameObject instructions;
    public GameObject playerActions;

    public TMP_Text text;
    public TMP_Text instructionText;
    public TMP_Text playerActionText;

    public int action;
    public int playerAction;

    public float randomPose;

    Vector3[] cameraPos;
    Vector3[] cameraRot;
   

    void Start()
    {
        CameraMovement();
        SceneCheck();
        
    }
    

    public void Quit()
    {
        Application.Quit();
    }
    
    public void LoadSceneName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }



    public void SceneCheck()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            print("Menu");

        }

        if (SceneManager.GetActiveScene().name == "Target Practice")
        {
            print("Target Practice");

        }


        if (SceneManager.GetActiveScene().name == "Night Fever")
        {
            print("NIGHT FEVER!");
            
            counter = 0;
            camCount = 4;               // counter for the camera movement
            CutsceneList(0);
        }

    }



    void CutsceneList(int num)
    {
        
        //camCount++;
        MoveCamera(camCount);
        Animate(counter);
        TextBox(counter);

        if (num == 2)
        {
            back.SetActive(true);
        }

        if (num == 4)
        {
            next.SetActive(false);
            back.SetActive(false);
            textBox.SetActive(false);
            instructions.SetActive(true);
            playerActions.SetActive(true);
            StartDance();
        }

    }



    public void Animate(int num)
    {   
        if(num == 0)
        {
            anim.SetBool("pose1", false);
        }
        if(num == 1)
        {
            anim.SetBool("pose1", true);
        }
        if (num == 2)
        {
            anim.SetBool("pose2", true);
            anim.SetBool("pose1", false);
        }
        if (num == 3)
        {
            anim.SetBool("pose2", false);
            anim.SetBool("pose3", true);
        }
        if (num == 4)
        {
            anim.SetBool("pose3", false);
        }

    }

    public void ButtonPress(int index)
    {
        if (index == 1)
        {
            counter++;
            camCount++;
        }
        if (index == 2)
        {
            counter--;
            camCount--;
        }


        print("counter = " + counter);
        CutsceneList(counter);

    }


    public void TextBox(int num)
    {

        if (num == 0)
        {
            
        }
        if (num == 1)
        {
            textBox.SetActive(true);
            text.text = "Welcome to the dancefloor!";
        }
        if (num == 2)
        {
            textBox.SetActive(true);
            text.text = "Copy my dance moves in order to score points.";
        }
        if (num == 3)
        {
            textBox.SetActive(true);
            text.text = "Use the ASDF keys to dance.";
        }
    }


    

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Night Fever")
        {
            if (counter == 4)
            {
                print("running");
                if (action == playerAction)
                {
                    instructionText.text = "Correct!";
                    StartDance();
                }
            }
        }
    }
    
    
    void StartDance()
    {
        int randomInt = Random.Range(2, 5);
        int randomCounter = randomInt;

        print("number of moves = " + randomCounter);

        if (randomCounter != 0)
        {
            RandomPose();
            randomCounter--;
        }
        KeyCheck();
        /*if (action == playerAction)
        {
            text.text = "Correct!";
            //StartDance();
        }*/

    }



    void RandomPose()
    {
        randomPose =  Random.Range(1f, 6f);

        anim.SetBool("pose1", false);
        anim.SetBool("pose2", false);
        anim.SetBool("pose3", false);
        anim.SetBool("pose4", false);
        anim.SetBool("check", false);

        instructionText.text = "";

        if (randomPose >= 1)
        {
            anim.SetBool("pose1", true);
            action = 1;
            instructionText.text = instructionText.text + " A";
            print("Dancer A");

            anim.SetBool("check", true);
        }
        if (randomPose >= 2)
        {
            anim.SetBool("pose2", true);
            action = 2;
            instructionText.text = instructionText.text + " S";
            print("Dancer S");
            anim.SetBool("check", true);
        }
        if (randomPose >= 3)
        {
            anim.SetBool("pose3", true);
            action = 3;
            instructionText.text = instructionText.text + " D";
            print("Dancer D");
            anim.SetBool("check", true);
        }
        if (randomPose >= 4)
        {
            anim.SetBool("pose4", true);
            action = 4;
            instructionText.text = instructionText.text + " F";
            print("Dancer F");
            anim.SetBool("check", true);
        }


    }



    void KeyCheck()
    {
        if (Input.GetKey(KeyCode.A))
        {
            playerAction = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerAction = 2;
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerAction = 3;
        }
        if (Input.GetKey(KeyCode.F))
        {
            playerAction = 4;
        }
    }




    void CameraMovement()
    {
        cameraPos = new[]
       {
            //new Vector3(-5.38f, 1.62f, -0.01f), // camera 0 pos
            new Vector3(-5.38f, 1.34f, 2.224f),  // camera 1 pos
            new Vector3(-6.206f, 1.257f, 2.489f),  // camera 2 pos 
            new Vector3(-5.38f, 1.34f, 2.224f),  // camera 3 pos
            new Vector3(-7.416f, 1.575f, 1.913f),  // camera 3 pos

            new Vector3(-42.1f, 9.48f, -8.28f),   // 4   - disco scene
            new Vector3(-34.65f, 6.72f, 7.89f),
            new Vector3(-34.65f, 6.72f, 7.89f),
            new Vector3(-34.65f, 6.72f, 7.89f),
            new Vector3(-42.1f, 9.48f, -8.28f)

        };

        cameraRot = new[]
        {
           // new Vector3(7.663f, 0f, 0f), //camera 0 rot
            new Vector3(0f, 0f, 0f),
            new Vector3(0f, -92.818f, 0f),
            new Vector3(0f, -92.818f, 0f),
            new Vector3(0f, -92.818f, 0f),

            new Vector3(14.326f, 31.011f, 0f),    // 4   - disco scene
            new Vector3(0.802f, 51.06f, 0.325f),
            new Vector3(0.802f, 51.06f, 0.325f),
            new Vector3(0.802f, 51.06f, 0.325f),
            new Vector3(14.326f, 31.011f, 0f)

        };
    }
    public void MoveCamera(int index)
    {
        Camera cam = Camera.main;
        cam.transform.position = cameraPos[index];
        cam.transform.rotation = Quaternion.Euler(cameraRot[index].x, cameraRot[index].y, cameraRot[index].z);
        print("Camera to index " + index);
    }
    


    
    
    
    /* void Awake()
     {
         if (instance == null)
         {
             instance = this;
             DontDestroyOnLoad(gameObject);
             print("do not destroy");
         }
         else
         {
             print("do destroy");
             Destroy(gameObject);
         }

     }*/
    
    
    /*List<CutsceneMethod> cutscenePart = new List<CutsceneMethod>();
                                                                         //cutscene divided into parts.
        cutscenePart.Add(CutscenePart1);
        cutscenePart.Add(CutscenePart2);
        /*cutscenePart.Add(CutscenePart3);
        cutscenePart.Add(CutscenePart4);
        cutscenePart.Add(CutscenePart5);
        cutscenePart.Add(CutscenePart6);
        cutscenePart.Add(CutscenePart7);*/
}