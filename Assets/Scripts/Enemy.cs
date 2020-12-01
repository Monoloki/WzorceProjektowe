using UnityEngine;

public class Enemy : MonoBehaviour
{
    int maxHealth = 3;
    int currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            currentHealth--;
        }
    }
}
