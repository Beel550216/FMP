using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Target : MonoBehaviour
{

    [SerializeField] List<GameObject> targetSets = new List<GameObject>();


     void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("arrow"))
        {
            print("Colided");

            if (gameObject.activeSelf == true)
            {
                gameObject.SetActive(false);
            }

        }
    }
}
