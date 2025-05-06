using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class target : MonoBehaviour
{
    public GameObject target1;
    public GameObject target2;
    public LevelManager LM;
    public int targetNum;

    public PointsTracker pT;

    public void Start()
    {
        LM = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        pT = GameObject.Find("Points tracker").GetComponent<PointsTracker>();
    }

     void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("arrow"))
        {
            if(gameObject.tag == "target" || gameObject.tag == "target6")
            {  
                print("Colided");

                if (gameObject.activeSelf == true)
                {
                    gameObject.SetActive(false);
                    pT.AddPoints(10);
                }

            }
            else
            {
                Destroy(other.gameObject);
            }
            
        }

        if (gameObject.activeSelf == false && target1.activeSelf == false && target2.activeSelf == false)      //&& target2.activeSelf == false
        {
            if (gameObject.tag == "target6")
            {
                LM.EndOfRound();
            }
            else
            {
                LM.targetCount = targetNum;
                LM.nextTargets();
            }

        }
    }

}
