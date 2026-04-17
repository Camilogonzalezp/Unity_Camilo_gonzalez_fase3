using UnityEngine; // Unity core library

public class PlayerMovement : MonoBehaviour // Player class
{
    public float speed = 1f; // Base movement speed
    public float jumpForce = 1.6f; // Controlled jump force
    public float airControl = 0.2f; // Reduces movement in air

    private Rigidbody rb; // Physics reference
    private bool isGrounded; // Ground check

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get Rigidbody component
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // A and D
        float moveZ = Input.GetAxis("Vertical"); // W and S

        Vector3 move = new Vector3(moveX, 0, moveZ); // Movement vector

        // Normal movement on ground
        if (isGrounded)
        {
            rb.linearVelocity = new Vector3(move.x * speed, rb.linearVelocity.y, move.z * speed);
        }
        else
        {
            // Reduced control in air
            rb.linearVelocity = new Vector3(move.x * speed * airControl, rb.linearVelocity.y, move.z * speed * airControl);
        }

        // CONTROLLED JUMP
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z); // Reset vertical velocity
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Apply jump
        }

        // STOP movement when no input (prevents sliding)
        if (moveX == 0 && moveZ == 0 && isGrounded)
        {
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Player is grounded
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; // Player is in air
        }
    }
}