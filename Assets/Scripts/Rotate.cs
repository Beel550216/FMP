using UnityEngine;

public class Rotate : MonoBehaviour
{
    float degreesPerSecond = 20;

    private void Update()
    {
        if (gameObject.tag == "lights")
        {
            transform.Rotate(new Vector3(0, degreesPerSecond, 0) * Time.deltaTime);
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, degreesPerSecond) * Time.deltaTime);

        }
        
    }
}