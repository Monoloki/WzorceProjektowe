using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Rigidbody rb;
    public Text mytext;
    public GameObject lose;

    public float speed = 8;
    public float rotationSpeed = 2;
    public float jumpHeight = 6;

    int hp = 15;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        mytext.text = "HEALTH:" + hp;
        Time.timeScale = 1;
    }

    void Update()
    {
        HandleMovemnet();
        HandleHorizontalRotationl();
        HandleVerticalRotationl();
        HandleJump();
        Lose();
    }

    private void Lose()
    {
        if (hp == 0)
        {
            //Debug.Log("You're looser");
            lose.SetActive(true);
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(1);
            }
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up*jumpHeight,ForceMode.VelocityChange);
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.3f);
    }

    private void HandleVerticalRotationl()
    {
        var input = Input.GetAxis("Mouse Y");
        var rotation = cam.transform.localRotation.eulerAngles;
        rotation.x -= input* rotationSpeed;
        cam.transform.localRotation = Quaternion.Euler(rotation);
    }

    private void HandleHorizontalRotationl()
    {
        var input = Input.GetAxis("Mouse X");
        var rotation = transform.localRotation.eulerAngles;
        rotation.y += input* rotationSpeed;
        transform.localRotation = Quaternion.Euler(rotation);
    }

    private void HandleMovemnet()
    {
        var input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        var newVelocity = transform.rotation * input * speed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            newVelocity *= 2;
        }
        newVelocity.y = rb.velocity.y;

        var controlFactor = Time.deltaTime * 10;
        if (!IsGrounded())
        {
            controlFactor /= 2;
        }

        rb.velocity = Vector3.Lerp(rb.velocity, newVelocity, controlFactor);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            hp--;
            mytext.text = "HEALTH:" + hp;
            //Debug.Log("Player HP:" + hp);
        }
    }
}
