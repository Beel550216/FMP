using UnityEngine;

public class Rotate : MonoBehaviour
{
    float degreesPerSecond = 20;

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, degreesPerSecond) * Time.deltaTime);
    }
}
