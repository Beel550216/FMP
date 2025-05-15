using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsTracker : MonoBehaviour
{

    public float points;
    public float savedPoints = 0f;

    public static PointsTracker instance;

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

        print("current points -" + points);
    }

    /*public void Resetpoints()
    {
        points = 0f;
        PlayerPrefs.SetFloat("savedPoints", 0f);
    }*/


    /*public void Fullresetpoints()
    {
        points = 0f;
        savedPoints = 0f;
        PlayerPrefs.SetFloat("savedPoints", 0f);

        print("Points = " + points);
        print("savedPoints = " + savedPoints);
    }*/
}
