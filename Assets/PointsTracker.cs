using UnityEngine;

public class PointsTracker : MonoBehaviour
{

    public float points;
    public float savedPoints = 0f;


    public static PointsTracker instance;

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

    // Update is called once per frame
    void Update()
    {
        //LoadPoints();
        EndRound();
        print("saved points = " + savedPoints);
        
    }

    public void LoadPoints()
    {
        float points = PlayerPrefs.GetFloat("savedPoints", 1f);
    }

    public void EndRound()
    {
        points = points + 100;
        print("Points = " + points);
        PlayerPrefs.SetFloat("savedPoints", points);
    }
}
