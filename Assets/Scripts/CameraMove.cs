using System;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    Vector3[] cameraPos;
    Vector3[] cameraRot;


    void Start()
    {
        cameraPos = new[]
       {
            //new Vector3(-5.38f, 1.62f, -0.01f), // camera 0 pos
            new Vector3(-5.38f, 1.34f, 2.224f),  // camera 1 pos
            /*new Vector3(6.95f, 15f, -11.25f),  // camera 2 pos 
            new Vector3(16.43f, 20.02f, -9.88f)  // camera 3 pos */
        };

        cameraRot = new[]
        {
           // new Vector3(7.663f, 0f, 0f), //camera 0 rot
            new Vector3(0f, 0f, 0f),
            new Vector3(15.914f, -8.945f, -2.667f),
            new Vector3(29.138f, 36.66f, 0.17f)
        };
    }

    public void MoveCamera(int index)
    {
        Camera cam = Camera.main;
        cam.transform.position = cameraPos[0];
        cam.transform.rotation = Quaternion.Euler(cameraRot[index].x, cameraRot[index].y, cameraRot[index].z);
        print("Camera to index " + index);
    }

}
