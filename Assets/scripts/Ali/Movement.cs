using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Literal fish movements")]
    [Range(0f, 100f)]public float swimSpeed = 5f;
    [Range(0f, 100f)]public float dashSpeed = 10f;
    [Range(0f, 100f)]public float dashCooldown = 2f;
    [Range(0f, 100f)]public float dashDuration = 0.5f;
    
    private bool canDash = true;
    private float dashCooldownTimer = 0f;
    private float dashTimeRemaining = 0f;
    private Vector3 savedVelocity;
    private bool isDashing = false;

    private void Update()
    {
        Move();
        HandleDash();
        Cooldowns();
    }

    private void Move()
    {
        if (isDashing) return;

        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(hor, ver, 0) * swimSpeed * Time.deltaTime;
        transform.Translate(move, Space.World);
    }

    private void HandleDash()
    {
        if (canDash && Input.GetKey(KeyCode.LeftShift))
        {
            StartDash();
        }

        if (isDashing)
        {
            dashTimeRemaining -= Time.deltaTime;
            if (dashTimeRemaining <= 0)
            {
                EndDash();
            }
        }
    }

    private void StartDash()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0).normalized;
        savedVelocity = direction * swimSpeed;
        transform.Translate(direction * dashSpeed * dashDuration, Space.World);
        isDashing = true;
        canDash = false;
        dashTimeRemaining = dashDuration;
        dashCooldownTimer = dashCooldown;
    }

    private void EndDash()
    {
        isDashing = false;
    }
    private void Cooldowns()
    {
        if (!canDash)
        {
            dashCooldownTimer -= Time.deltaTime;
            if (dashCooldownTimer <= 0)
            {
                canDash = true;
            }
        }
    }
}