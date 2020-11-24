using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping_enemy : MonoBehaviour
{
    GameObject[] player;
    public Rigidbody rb;
    public float nextJump = 0.0F;
    public float jumpRate = 0.1F;
    public int force;
    public float force2;
    Vector3 direction;
    public int distance = 20;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
        direction = player[0].transform.position - transform.position;
        
        // idzie do gracza jak jest dalej niż distance
        if (direction.magnitude > distance)
        {
            Debug.Log("Idzie");
            direction.Normalize();
            rb.MovePosition(direction* force2);
        }
        else
        {
            // skacze na gracza
            Debug.Log("Skacze");
            direction.Normalize();
            jump();
        }
            

        
        
        
    }

    public void jump() 
    {
        if (Time.time > nextJump)
        {
            nextJump = Time.time + jumpRate;      
            rb.AddForce(direction * force + new Vector3 (0,2,0), ForceMode.Impulse);
            player = null;
        }
    }

}
