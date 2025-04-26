using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public Animator anim;
    public Animator playerAnim;
    public int counter;
    public int camCount;
    public GameObject textBox;
    public GameObject next;
    public GameObject back;
    public GameObject skip;
    public GameObject nextGame;
    public GameObject instructions;
    public GameObject playerActions;
    public GameObject EndScreen;

    public TMP_Text text;
    public TMP_Text wellDoneText;
    public TMP_Text instructionText;
    public TMP_Text playerActionText;
    public TMP_Text roundNumberText;
    public TMP_Text pointsText;
    public TMP_Text totalPointsText;

    private int action;          //
    private int playerAction;    //

    private float randomPose;    //

    public int sceneCount;

    public int pointsTotal = 0;
    int discoPoints = 0;
    public int round = 0;

    Vector3[] cameraPos;
    Vector3[] cameraRot;


    string[] speech;
    public string speechText;

    [SerializeField] List<GameObject> targetSets = new List<GameObject>();
    public int targetCount = 0;
    //List<string> speech = new List<string>();


    void Start()
    {
        CameraMovement();
        SceneCheck();

        List();
        //print(speech[1] + "- test");
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

        if (SceneManager.GetActiveScene().name == "Stage")
        {
            print("Stage");
            playerAnim.SetBool("idle", true);

            camCount = 9;
            counter = 5;
            CutsceneList(5);

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

        if (SceneManager.GetActiveScene().name == "Maze")
        {
            print("Maze");
        }

    }

    public void SceneCounter(int num)
    {
        sceneCount = num;
        print("There have been " + sceneCount + " scenes");
    }


    void CutsceneList(int num)
    {
        print("num =" + num);
        
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

        if (num == 5)
        {
            print("working");                    //
        }

    }



    public void Animate(int num)
    {   
        if(num == 0)
        {
            anim.SetBool("pose1", false);
            anim.SetBool("pose2", false);
            anim.SetBool("pose3", false);
            anim.SetBool("pose4", false);
            anim.SetBool("cutscene", false);
        }
        if(num == 1)
        {
            anim.SetBool("cutscene", true);
        }
        if (num == 2)
        {
            anim.SetBool("pose2", true);
            anim.SetBool("cutscene", false);
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

        if (num == 6 || num == 8)
        {
            anim.SetBool("start", true);
        }
        if (num == 7)
        {
            anim.SetBool("point", true);
        }
        if (num == 9 || num == 10 || num == 11)
        {
            anim.SetBool("look sideways", true);
        }
        if (num == 12)
        {
            anim.SetBool("look sideways", false);
        }

        if (num >= 6 && num <= 12 && num != 7)
        {
            anim.SetBool("point", false);
            anim.SetBool("talk", false);
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
            if(camCount >= 5)
            {
                counter--;
                camCount--; 
            }
            
        }

        if (index == 3)
        {
            print("skip pressed");
            skip.SetActive(false);
            next.SetActive(true);
            counter = 12;
            camCount = 16;
        }
        print("counter = " + counter);
        CutsceneList(counter);

        string speechText = speech[counter];
        text.text = (speechText);

        print(speech[counter]);
    }


    public void TextBox(int num)
    {
        if (num == 1 || num == 6)
        {
            textBox.SetActive(true);
        }
        if (num == 7)
        {
            skip.SetActive(true);
            next.SetActive(false);
        }
        if (num == 8)
        {
            skip.SetActive(false);
            next.SetActive(true);
        }
        if (num == 9)
        {
            back.SetActive(true);
        }

    }

    public void List()
    {
        speech = new[]
        {
            new string(""),
            new string("Welcome to the dancefloor!"),
            new string("Copy my dance moves in order to score points."),
            new string("Use the ASDF keys to dance."),
            new string(""),
            new string(""),

            new string("Welcome to Lii Party!"),
            new string("Have you played Lii Party before?"),
            new string("Ok, I'll explain how it works!"),
            new string("The aim of the game is to collect as many points as you can"),
            new string("You can accumulate points through the minigame rounds!"),
            new string("There are 3 minigames today"),
            new string("Okay..."),
            new string("Are you ready to start?"),

        };

    }
    

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Night Fever")
        {
            if (counter == 4)
            {

                if (round != 7)
                {
                    if (action == playerAction)
                    {
                        WellDone();
                        instructionText.text = "Correct!";
                        discoPoints = discoPoints + 10;
                        print("Points for this minigame = " + discoPoints);

                        //Animate(0);

                        StartDance();

                    }
                    KeyCheck();

                }
                /*if (round == 7)
                {
                    instructionText.text = instructionText.text + " Well done!";
                }*/ // -error
                //print("running");

                EndOfRound();

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
            //randomCounter--;
        }
        KeyCheck();

    }



    void RandomPose()
    {
        randomPose =  Random.Range(1f, 6f);

        Animate(0);

        instructionText.text = "";

        if (randomPose >= 1)            //&& randomPose < 2
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
        print("Keychecking");

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


    public void WellDone()
    {
        float randomMessage = Random.Range(1f, 5f);

        if (randomMessage > 1)
        {
            wellDoneText.text = "Nice!";
        }
        if (randomMessage > 2 && randomMessage < 3)
        {
            wellDoneText.text = "Groovy!";
        }
        if (randomMessage > 3 && randomMessage < 4)
        {
            wellDoneText.text = "Yes!";
        }
        if (randomMessage > 4 && randomMessage <= 5)
        {
            wellDoneText.text = "Go!";
        }

        round++;
        print("round = " + round);
        string roundNumber = round.ToString();
        roundNumberText.text = roundNumber;
    }

    void EndOfRound()
    {
        if (round == 7)
        {
            instructionText.text = " Well done!";
            
            anim.SetBool("check", false);
            anim.SetBool("clap", true);
            
            counter = 5;
            instructions.SetActive(false);
            EndScreen.SetActive(true);
            next.SetActive(true);

            pointsTotal = pointsTotal + discoPoints;

            pointsText.text = discoPoints.ToString();
            totalPointsText.text = pointsTotal.ToString();
        }
        

    }

    public void nextTargets()
    {
        GameObject target = targetSets[targetCount];
        target.SetActive(true);
        print("Loaded targets: " + targetCount);
    }



    void CameraMovement()
    {
        cameraPos = new[]
       {
            //new Vector3(-5.38f, 1.62f, -0.01f), // camera 0 pos
            new Vector3(-5.38f, 1.34f, 2.224f),  // camera 1 pos
            new Vector3(-6.206f, 1.257f, 2.489f),  // camera 2 pos 
            new Vector3(-5.38f, 1.34f, 2.224f),  // camera 3 pos
            new Vector3(-7.416f, 1.575f, 1.913f),  // camera 4 pos

            new Vector3(-42.1f, 9.48f, -8.28f),   // 5   - disco scene
            new Vector3(-34.65f, 6.72f, 7.89f),
            new Vector3(-34.65f, 6.72f, 7.89f),
            new Vector3(-34.65f, 6.72f, 7.89f),
            new Vector3(-42.1f, 9.48f, -8.28f),

            new Vector3(-17.02f, 11.764f, -19.45f),
            new Vector3(3.754f, 10.366f, -14.728f),
            new Vector3(3.754f, 10.366f, -14.728f), //
            new Vector3(0.34f, 10.79f, -21.25f),
            new Vector3(0.27f, 10.79f, -11.329f),
            new Vector3(0.27f, 10.79f, -11.329f),
            new Vector3(0.433f, 10.708f, -12.355f),

            new Vector3(0.784f, 10.708f, -15.641f),
            new Vector3(0.784f, 10.708f, -15.641f)
            //new Vector3(3.754f, 10.366f, -14.728f),


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
            new Vector3(14.326f, 31.011f, 0f),

            new Vector3(0f, 47.794f, 0f),        // 9   - stage scene
            new Vector3(0f, 42.915f, 0f),
            new Vector3(0f, 42.915f, 0f),
            new Vector3(0f, 42.915f, 0f),
            new Vector3(0f, 80.962f, 0f),
            new Vector3(0f, 80.962f, 0f),
            new Vector3(0f, 80.962f, 0f),
            new Vector3(0f, 67.794f, 0f),
            new Vector3(0f, 67.794f, 0f),

            //new Vector3(0f, 42.915f, 0f),

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