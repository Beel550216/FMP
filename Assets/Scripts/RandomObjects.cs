using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomObjects : MonoBehaviour
{
    [SerializeField]
    GameObject[] objects;

    [SerializeField]
    List<GameObject> objectsList = new List<GameObject>();

    void Start()
    {
        RandomSpawn();
    }

    void Update()
    {
        
    }

    void RandomSpawn()
    {
        int randomInt = Random.Range(1, 4);
        int randomNum = randomInt;

        print("Object " + randomNum + " selected");

        objects[randomNum].SetActive(true);
    }

}
