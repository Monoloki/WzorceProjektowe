using UnityEngine;

public class Jumping_enemy : MonoBehaviour
{
    public GameObject[] player;
    public Rigidbody rb;
    public float nextJump = 0.0F;
    public float jumpRate1;
    public float jumpRate2;
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
            //rb.MovePosition(player[0].transform.position* Time.deltaTime);
            jump(0, jumpRate1);
        }
        else
        {
            // skacze na gracza
            Debug.Log("Skacze");
            direction.Normalize();
            jump(600, jumpRate2);
        }  
    }

    public void jump(float jumpHeight,float jumpRate) 
    {
        if (Time.time > nextJump)
        {
            
            nextJump = Time.time + jumpRate;      
            rb.AddForce(direction * force + new Vector3 (0, jumpHeight, 0), ForceMode.Impulse);
            player = null;
        }
    }

}
