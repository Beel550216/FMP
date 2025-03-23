using UnityEngine;
 using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;

    public Animator anim;
    public int counter;
    public int camCount;

    Vector3[] cameraPos;
    Vector3[] cameraRot;
   

    void Start()
    {
        CameraMovement();
        SceneCheck();
        
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

        if (SceneManager.GetActiveScene().name == "Target Practice")
        {
            print("Target Practice");

        }


        if (SceneManager.GetActiveScene().name == "Night Fever")
        {
            print("NIGHT FEVER!");
            
            counter = 0;
            camCount = 3;               // counter for the camera movement
            CutsceneList(0);
        }

    }



    void CutsceneList(int num)
    {

        camCount++;
        MoveCamera(camCount);
        Animate(counter);

    }



    public void Animate(int num)
    {   
        if(num == 0)
        {
            anim.SetBool("pose1", false);
        }
        if(num == 1)
        {
            anim.SetBool("pose1", true);
        }
        
    }

    public void ButtonPress()
    {
        counter++;
        print("counter = " + counter);
        CutsceneList(counter);

    }











    void CameraMovement()
    {
        cameraPos = new[]
       {
            //new Vector3(-5.38f, 1.62f, -0.01f), // camera 0 pos
            new Vector3(-5.38f, 1.34f, 2.224f),  // camera 1 pos
            new Vector3(-6.206f, 1.257f, 2.489f),  // camera 2 pos 
            new Vector3(-5.38f, 1.34f, 2.224f),  // camera 3 pos
            new Vector3(-7.416f, 1.575f, 1.913f),  // camera 3 pos

            new Vector3(-42.1f, 9.48f, -8.28f),   // 4   - disco scene
            new Vector3(-34.65f, 6.72f, 7.89f)

        };

        cameraRot = new[]
        {
           // new Vector3(7.663f, 0f, 0f), //camera 0 rot
            new Vector3(0f, 0f, 0f),
            new Vector3(0f, -92.818f, 0f),
            new Vector3(0f, -92.818f, 0f),
            new Vector3(0f, -92.818f, 0f),

            new Vector3(14.326f, 31.011f, 0f),    // 4   - disco scene
            new Vector3(0.802f, 51.06f, 0.325f)

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