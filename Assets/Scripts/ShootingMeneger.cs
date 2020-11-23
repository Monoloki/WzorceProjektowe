using System;
using UnityEngine;

public class ShootingMeneger : MonoBehaviour
{
    public GameObject laser;
    public GameObject camera;
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
            Debug.Log("Shoot");
            Instantiate(laser, transform.position + new Vector3(1, 0, 1), camera.transform.rotation);
        }
    }
}
