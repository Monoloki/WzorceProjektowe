using UnityEngine;

public class ShootingMeneger : MonoBehaviour
{
    public GameObject laser;
    public GameObject cam;
    public GameObject carabine;
    private float fireRate = 0.15F;
    private float nextFire = 0.0F;

    void Update()
    { 
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            //Debug.Log("Shoot");
            Instantiate(laser, carabine.transform.position, cam.transform.rotation);
        }
    }
}
