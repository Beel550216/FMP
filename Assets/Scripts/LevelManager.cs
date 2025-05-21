using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Analytics;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public PointsTracker pT;
    public AudioManager aM;

    public Animator anim;
    public Animator playerAnim;
    public Animator creditAnim;
    public int counter;
    public int camCount;
    public GameObject textBox;
    public GameObject next;
    public GameObject back;
    public GameObject skip;
    public GameObject yes;
    public GameObject nextGame;
    public GameObject instructions;
    public GameObject playerActions;
    public GameObject EndScreen;
    public GameObject credits;
    public GameObject finalPoints;
    public GameObject prizeBox;
    public GameObject skipCredits;

    public TMP_Text text;
    public TMP_Text wellDoneText;
    public TMP_Text instructionText;
    public TMP_Text prizeText;                     //formerly, player action
    public TMP_Text roundNumberText;
    public TMP_Text pointsText;
    public TMP_Text totalPointsText;

    private int action;          //
    private int playerAction;    //

    private float randomPose;    //

    public int sceneCount;

    public int round = 0;

    Vector3[] cameraPos;
    Vector3[] cameraRot;


    string[] speech;
    public string speechText;

    [SerializeField] List<GameObject> targetSets = new List<GameObject>();
    public int targetCount = 0;

    [SerializeField] List<GameObject> triviaRounds = new List<GameObject>();
    //List<string> speech = new List<string>();
    [SerializeField] List<GameObject> prizes = new List<GameObject>();


    void Start()
    {
        pT = GameObject.Find("Points tracker").GetComponent<PointsTracker>();
        aM = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
        CameraMovement();
        SceneCheck();
        
        List();
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

            print("Trivia round -" + pT.triviaRound);

            if (pT.triviaRound <= 0)
            {
                ResetPoints();
                camCount = 9;      //29
                counter = 5;        //42
                CutsceneList(5);
                //pT.triviaRound = 3;
                //pT.savedPoints = 650;
            }
            
            if (pT.triviaRound == 1)
            {
                camCount = 9;
                //textBox.SetActive(true);
                counter = 20;
                CutsceneList(5);
            }

            if (pT.triviaRound == 2)
            {
                camCount = 9;
                //textBox.SetActive(true);
                counter = 28;
                CutsceneList(5);
            }

            if (pT.triviaRound == 3)
            {
                camCount = 29;
                //textBox.SetActive(true);
                counter = 41;
                CutsceneList(5);
            }

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

    /*public void SceneCounter(int num)
    {
        sceneCount = num;
        print("There have been " + sceneCount + " scenes");
    }*/


    void CutsceneList(int num)
    {
        print("num =" + num);
        
        //camCount++;
        MoveCamera(camCount);
        Animate(counter);
        TextBox(counter);


        if (num == 2 || num == 10)
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

        if (num == 9)
        {
            back.SetActive(false);  
        }
        /*if (num == 13)
        {
            back.SetActive(false);
            next.SetActive(false);
            //yes.SetActive(true);
        }*/

        if (num == 17)
        {
            back.SetActive(false);
            next.SetActive(false);
            yes.SetActive(true);
        }

        if (num == 20)
        {
            back.SetActive(false);
            next.SetActive(false);
            textBox.SetActive(false);

            if (pT.triviaRound >= 1)
            {
                nextGame.SetActive(true);
            }
            
        }

        if (num == 25)
        {
            if (pT.triviaRound == 1)
            {
                //textBox.SetActive(false);
                back.SetActive(false);
                next.SetActive(false);
                yes.SetActive(true);
            }
            
        }

        if (num == 27)
        {
            if (pT.triviaRound > 2)
            {
                //textBox.SetActive(false);
                back.SetActive(false);
                next.SetActive(false);
                yes.SetActive(true);
            }
            if (pT.triviaRound == 2)
            {
                back.SetActive(false);
                next.SetActive(false);
                textBox.SetActive(false);
                nextGame.SetActive(true);
            }
            
        }

        if (num == 28)
        {
            if (pT.triviaRound != 3)
            {
                back.SetActive(false);
                next.SetActive(false);
                textBox.SetActive(false);
                nextGame.SetActive(true);
            }

        }

        if (num == 34)
        {
            textBox.SetActive(false);
            back.SetActive(false);
            next.SetActive(false);
            yes.SetActive(true);

        }

        if (num == 40)
        {
            back.SetActive(false);
            next.SetActive(false);
            textBox.SetActive(false);

            if (pT.triviaRound == 3)
            {
                nextGame.SetActive(true);
            }

        }

        if (num == 45)
        {
            textBox.SetActive(false);
            finalPoints.SetActive(true);

            totalPointsText.text = pT.savedPoints.ToString();
            aM.playSFX(6);
        }

        if (num == 46)
        {
            textBox.SetActive(true);
            finalPoints.SetActive(false);

        }
        if (num == 50)
        {
            Prize();
            prizeBox.SetActive(true);
        }
        if (num == 51)
        {
            prizeBox.SetActive(false);
        }

        /*if (num == 51)
        {
            next.SetActive(true);
        }*/

        if (num == 54)
        {
            next.SetActive(false);
            textBox.SetActive(false);

            credits.SetActive(true);
            creditAnim.SetBool("credits", true);
            aM.playSFX(6);
            skipCredits.SetActive(true);

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

        if (num == 6 || num == 8 || num == 41)
        {
            anim.SetBool("start", true);
        }
        if (num == 7)
        {
            anim.SetBool("point", true);
        }
        if (num == 9 || num == 10 || num == 11 || num == 14)
        {
            anim.SetBool("start", false);
            anim.SetBool("look sideways", true);
        }
        if (num == 12)
        {
            anim.SetBool("look sideways", false);
        }

        if (num >= 6 || num <= 12 || num != 7 || num == 15)
        {
            anim.SetBool("point", false);
            anim.SetBool("talk", false);
        }

        if (num == 15 || num == 42)
        {
            anim.SetBool("look sideways", true);
        }

        if (num == 18 || num == 43 || num == 54)
        {
            anim.SetBool("look sideways", false);
            anim.SetBool("with paper", true);
        }

        if (num == 19 || num == 51)
        {
            anim.SetBool("with paper", false);
        }

        if (num >= 28 && num <= 35)
        {
            anim.SetBool("start", true);
            anim.SetBool("talk", false);
            anim.SetBool("look sideways", false);
            anim.SetBool("with paper", true);
        }

        if (num == 36)
        {
            anim.SetBool("talk", true);
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
            back.SetActive(true);
            counter = 15;
            camCount = 19;
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

        if (num == 43)
        {
            textBox.SetActive(false);
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
            //new string("Okay..."),
            //new string("Are you ready to start?"),

            new string("Before each minigame, there is a trivia round."),
            new string("These questions will test your knowledge on all things 70s."),
            new string("Each correct answer will earn you 20 points."),
            new string("The first trivia round is called 'Blockbuster'!"),
            new string("This round is all about films"),
            new string("Are you ready to start?"),

            new string("Well done"),
            new string("Now it's time for the first minigame!"),
            new string("Let's test your shooting skills in archery."),

            new string("Welcome back!"),
            new string("You took a while in that game..."),
            //new string("The points have been added to your total"),
            new string("The next trivia round is called 'Vinyl Records'!"),
            new string("This round is all about the record breaking songs and musicians of the 70s!"),
            new string("Each correct answer adds 20 points to your score"),
            //new string("Good Luck"),

            new string("Okay, now it's onto the next minigame!"),
            new string("This minigame takes place at a busy festival, so try not to get lost..."),    // add in a joke or something. Idk. Like "I hope you remembered your tickets or something alluding to the item becoming lost).
            
            new string(" "),
            new string("Welcome back, we thought we'd lost you..."),
            //new string("Don't lose it again"),
            new string("We are over halfway through todays show."),
            new string("Soon our contestant will go up against our professional dancer"),
            new string("But before that, it's time for our final trivia round..."),
            new string("'That's life'"),
            new string("This round is a culture round about life in the 70s"),
            new string("Let's begin!"),

            new string("great"),
            new string("That was the last trivia round, but there is still one more chance to gain points..."),
            new string("As it's time for the final minigame"),
            new string("Your points will be revealed once you return"),
            new string("Our contestant will now go up against our professional dancer"),
            new string("Good Luck!"),

            new string("Well Done!"),                     //44?
            new string("That was our final minigame, so now it's time to see how many points you earned!"),
            new string("I can announce that your points total is..."),
            new string(""),
            new string("Good job"),
            new string("Let's see what prize these points convert to"),
            new string("The higher the points, the better the prize"),
            new string("Tonight, you will be going home with..."),
            new string(""),
            new string("Congratulations!"),
            new string("Join us next week where another contestant will battle the rounds of Lii Party"),
            new string("Goodnight!"),
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
                        pT.AddPoints(10);

                        //Animate(0);

                        StartDance();

                    }
                    KeyCheck();

                }
                else
                {
                    EndOfRound();
                }

                

            }
        }

        if (SceneManager.GetActiveScene().name == "Stage")
        {
            UpdateText();
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

    public void EndOfRound()
    {
        if (round == 7)
        {
            instructionText.text = " Well done!";
            
            Animate(0);
            anim.SetBool("check", false);
            anim.SetBool("clap", true);
            
            counter = 5;
            instructions.SetActive(false);
            EndScreen.SetActive(true);

            //pT.EndRound();

            pointsText.text = pT.points.ToString();
            //totalPointsText.text = pT.savedPoints.ToString();
        }
        if(SceneManager.GetActiveScene().name == "Maze" || SceneManager.GetActiveScene().name == "Target Practice")
        {
            EndScreen.SetActive(true);
            pT.EndRound();

            pointsText.text = pT.points.ToString();
            totalPointsText.text = pT.savedPoints.ToString();
        }
        
        pT.EndRound();


    }

    public void nextTargets()
    {
        GameObject target = targetSets[targetCount];
        target.SetActive(true);
        print("Loaded targets: " + targetCount);
    }

    public void LoadRound()
    {
        GameObject questions = triviaRounds[pT.triviaRound];


        questions.SetActive(true);
        print("Loaded Round: " + pT.triviaRound);

        pT.triviaRound++;
    }

    public void UpdateText()
    {
        string currentPoints = pT.points.ToString();
        pointsText.text = currentPoints;
    }

    public void AddButtonPoints()
    {
        pT.AddPoints(20);
        print("Correct Answer");
    }

    public void ClearPoints()
    {
        pT.points = 0f;
        print("points" + pT.points);
    }

    public void ResetPoints()
    {
        pT.points = 0f;
        print("points" + pT.points);
        pT.savedPoints = 0f;
        print("saved points" + pT.savedPoints);
    }

    public void NextScene()
    {
        print("trivia round " + pT.triviaRound);

        if (pT.triviaRound <= 1)
        {
            LoadSceneName("Target Practice");
        }
        if (pT.triviaRound == 2)
        {
            LoadSceneName("Maze");
        }
        if (pT.triviaRound == 3)
        {
            LoadSceneName("Night fever");
        }
    }


    public void Prize()
    {
        if (pT.savedPoints >= 400 && pT.savedPoints < 600)
        {
            prizeText.text = "A camera!";
            GameObject prize = prizes[0];
            prize.SetActive(true);
        }
        if (pT.savedPoints >= 600 && pT.savedPoints < 630)
        {
            prizeText.text = "A microwave!";
            GameObject prize = prizes[1];
            prize.SetActive(true);
        }
        if (pT.savedPoints >= 630 && pT.savedPoints < 650)
        {
            prizeText.text = "A guitar!";
            GameObject prize = prizes[2];
            prize.SetActive(true);
        }
        if (pT.savedPoints >= 650 && pT.savedPoints < 690)
        {
            prizeText.text = "A popcorn machine!";
            GameObject prize = prizes[3];
            prize.SetActive(true);
        }
        if (pT.savedPoints >= 700)
        {
            //grandprize
            prizeText.text = "A car!";
            GameObject prize = prizes[4];
            prize.SetActive(true);
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
            new Vector3(0.27f, 10.79f, -11.329f),

            new Vector3(0.784f, 10.708f, -15.641f),
            new Vector3(0.784f, 10.708f, -15.641f),

            new Vector3(0.46f, 10.708f, -12.29f),
            new Vector3(0.46f, 10.708f, -12.29f),
            new Vector3(0.46f, 10.708f, -12.29f),
            new Vector3(0.46f, 10.708f, -12.29f),

            new Vector3(0.784f, 10.708f, -15.641f),
            new Vector3(0.784f, 10.708f, -15.641f),
            new Vector3(0.784f, 10.708f, -15.641f),// 25
            new Vector3(0.784f, 10.708f, -15.641f),

            //new Vector3(3.754f, 10.366f, -14.728f),

            new Vector3(-3.63f, 4.18f, -13.88f),  // 27 - archery scene
            new Vector3(-3.63f, 4.18f, -17.44f),


            new Vector3(-17.02f, 11.764f, -19.45f), // 29
            new Vector3(0.27f, 10.79f, -11.329f),
            new Vector3(0.27f, 10.79f, -11.329f),
            new Vector3(0.784f, 10.708f, -15.641f),
            new Vector3(0.784f, 10.708f, -15.641f),
            new Vector3(0.784f, 10.708f, -15.641f),
            new Vector3(0.784f, 10.708f, -15.641f),
            new Vector3(0.27f, 10.79f, -11.329f),
            new Vector3(0.27f, 10.79f, -11.329f),
            new Vector3(0.27f, 10.79f, -11.329f),
            new Vector3(-1.726f, 10.708f, -14.628f),
            new Vector3(0.27f, 10.79f, -11.329f),
            new Vector3(0.27f, 10.79f, -11.329f),
            new Vector3(0.27f, 10.79f, -11.329f),
            new Vector3(-17.02f, 11.764f, -19.45f),

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

            new Vector3(0f, 72.942f, 0f),
            new Vector3(0f, 72.942f, 0f),
            new Vector3(0f, 67.794f, 0f),
            new Vector3(0f, 72.942f, 0f),
            new Vector3(0f, 72.942f, 0f),
            new Vector3(0f, 72.942f, 0f),
            new Vector3(0f, 72.942f, 0f),
            new Vector3(0f, 72.942f, 0f),
            new Vector3(0f, 72.942f, 0f),

            //new Vector3(0f, 42.915f, 0f),
            new Vector3(5.259f, 0f, 0f),   //  27 - archery scene
            new Vector3(5.259f, 0f, 0f),


            new Vector3(0f, 80.962f, 0f),       // 29
            new Vector3(0f, 80.962f, 0f),
            new Vector3(0f, 80.962f, 0f),
            new Vector3(0f, 67.794f, 0f),
            new Vector3(0f, 67.794f, 0f),
            new Vector3(0f, 67.794f, 0f),
            new Vector3(0f, 80.962f, 0f),
            new Vector3(0f, 80.962f, 0f),
            new Vector3(0f, 80.962f, 0f),
            new Vector3(0f, 200f, 0f),
            new Vector3(0f, 80.962f, 0f),
            new Vector3(0f, 80.962f, 0f),
            new Vector3(0f, 80.962f, 0f),
            new Vector3(0f, 47.794f, 0f),
            
        };
    }
    public void MoveCamera(int index)
    {
        Camera cam = Camera.main;
        cam.transform.position = cameraPos[index];
        cam.transform.rotation = Quaternion.Euler(cameraRot[index].x, cameraRot[index].y, cameraRot[index].z);
        print("Camera to index " + index);
    }

}