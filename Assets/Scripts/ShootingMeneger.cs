using UnityEngine;

public class ShootingMeneger : MonoBehaviour
{
    public GameObject laser;
    public GameObject camera;


    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Shoot");
            Instantiate(laser, transform.position, camera.transform.rotation);
        }
    }
}
