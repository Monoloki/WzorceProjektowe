using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Rigidbody rb;
    public GameObject lose;
    public Slider slider;

    public float speed = 8;
    public float rotationSpeed = 2;
    public float jumpHeight = 6;

    public int maxHealth = 15;
    int currentHealth;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SetHealth();
        Time.timeScale = 1;
    }

    void Update()
    {
        HandleMovemnet();
        HandleHorizontalRotationl();
        HandleVerticalRotationl();
        HandleJump();
        Health();
    }

    private void SetHealth()
    {
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    private void Health()
    {
        slider.value = currentHealth;
        if (currentHealth <= 0)
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
            currentHealth--;
        }
    }
}
