using UnityEngine;

public class Movement : MonoBehaviour
{
    public float swimSpeed = 5f;
    public float dashSpeed = 10f;
    public float dashCooldownDuration = 2f;
    public float dashDuration = 0.5f;
    private bool canDash = true;
    private float dashCooldownTimer = 0f;
    private float dashTimeRemaining = 0f;
    private Vector2 savedVelocity;
    private bool isDashing = false;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Dash();
    }

    private void Move()
    {
        float vertical = Input.GetAxis("Vertical");

        Vector2 move = transform.right * vertical * Time.deltaTime * swimSpeed;
        GetComponent<Rigidbody>().velocity = move;
    }

    private void Dash()
    {
        if (dashCooldown > 0)
        {
            canIDash = false;
            dashCooldown -= Time.deltaTime;
        }
        else
        {
            canIDash = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canIDash)
        {
            savedVelocity = GetComponent<Rigidbody>().velocity;
            GetComponent<Rigidbody>().velocity = transform.right * dashSpeed;
            dashCooldown = 2f;
        }
    }
}