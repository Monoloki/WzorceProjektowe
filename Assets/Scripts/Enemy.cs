using UnityEngine;

public class Enemy : MonoBehaviour
{
    int hp = 4;

    void Update()
    {
        if (hp == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            hp--;
            //Debug.Log("Enemy" + hp);
        }
    }
}
