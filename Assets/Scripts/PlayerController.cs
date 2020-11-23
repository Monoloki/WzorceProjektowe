using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] Rigidbody rigidbody;

    public float speed = 6;
    public float rotationSpeed = 2;
    public float jumpHeight = 8;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        HandleMovemnet();
        HandleHorizontalRotationl();
        HandleVerticalRotationl();
        HandleJump();
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rigidbody.AddForce(Vector3.up*jumpHeight,ForceMode.VelocityChange);
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.3f);
    }

    private void HandleVerticalRotationl()
    {
        var input = Input.GetAxis("Mouse Y");
        var rotation = camera.transform.localRotation.eulerAngles;
        rotation.x -= input* rotationSpeed;
        camera.transform.localRotation = Quaternion.Euler(rotation);
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
        newVelocity.y = rigidbody.velocity.y;

        var controlFactor = Time.deltaTime * 10;
        if (!IsGrounded())
        {
            controlFactor /= 2;
        }

        rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, newVelocity, controlFactor);
    }
}
