using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class target : MonoBehaviour
{
    public GameObject target1;
    public GameObject target2;
    public LevelManager LM;
    public int targetNum;

    public void Start()
    {
        LM = GameObject.Find("Level Manager").GetComponent<LevelManager>();
    }

     void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("arrow"))
        {
            if(gameObject.tag == "target")
            {  
                print("Colided");

                if (gameObject.activeSelf == true)
                {
                    gameObject.SetActive(false);
                }

            }
            else
            {
                print("missed");
                Destroy(other.gameObject);
            }
            
        }

        if (gameObject.activeSelf == false && target1.activeSelf == false && target2.activeSelf == false)      //&& target2.activeSelf == false
        {
            LM.targetCount = targetNum;
            LM.nextTargets();
        }
    }

}
