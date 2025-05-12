using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsTracker : MonoBehaviour
{

    public float points;
    public float savedPoints = 0f;

    public TMP_Text pointsText;

    public static PointsTracker instance;

    [SerializeField] List<GameObject> triviaRounds = new List<GameObject>();
    public int triviaRound = 0;

    void Awake()
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

        LoadPoints();
    }


    void Start()
    {
        print("Current points = " + points);
    }

    public void LoadPoints()
    {
        PlayerPrefs.GetFloat("savedPoints", 1f);
    }

    public void EndRound()
    {
        print("Points = " + points);

        savedPoints = savedPoints + points;
        PlayerPrefs.SetFloat("savedPoints", 1f);
    }

    public void AddPoints(int amount)
    {
        points = points + amount;
    }

    public void Resetpoints()
    {
        points = 0f;
        PlayerPrefs.SetFloat("savedPoints", 0f);
    }

    public void UpdateText()
    {
        string currentPoints = points.ToString();
        pointsText.text = currentPoints;
    }

    public void Rounds()
    {
        GameObject questions = triviaRounds[triviaRound];


        questions.SetActive(true);
        print("Loaded Round: " + triviaRound);

        triviaRound++;                                     //
    }


    /*public void Fullresetpoints()
    {
        points = 0f;
        savedPoints = 0f;
        PlayerPrefs.SetFloat("savedPoints", 1f);

        print("Points = " + points);
        print("savedPoints = " + savedPoints);
    }*/
}
