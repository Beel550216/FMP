using UnityEngine;
 using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;

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
   

    

    public void Quit()
    {
        Application.Quit();
    }
    
    public void LoadSceneName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}