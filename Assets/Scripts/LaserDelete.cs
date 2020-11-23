using UnityEngine;

public class LaserDelete : MonoBehaviour
{
    float time = 1.5f;

    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            Destroy(gameObject);
        }
    }
}
