using UnityEngine;

public class Movement : MonoBehaviour
{
    public float swimSpeed = 5f;
    public float dashSpeed;
    
    // Update is called once per frame
    void Update()
    {
        move();
        dash();
    }

    public void move()
    {
        float vertical = Input.GetAxis("Vertical");
        
        Vector2 move =(transform.right * vertical * Time.deltaTime * swimSpeed);
        move = vertical * transform.right;
        transform.Translate(move, Space.World);
    }

    public void dash()
    {
        if(dashCooldown > 0)
        {
            canIDash = false;
            dashCooldown -= Time.deltaTime;
            //if I put saved velocity here, it will continue to move at savedVelocity until dashCooldown = 0? so it can't go here? right?
        }
        if(dashCooldown <= 0)
        {
            canIDash = true;
            //if I put savedVelocity here it doesn't return to savedVelocity until dashCooldown <=0 so... it doesn't go here either right...?
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) && canIDash == true)
        {
            //saves velocity prior to dashing
            savedVelocity = GetComponent<Rigidbody>().velocity;
            //this part is the actual dash itself
            GetComponent<Rigidbody>().velocity =  new Vector2(GetComponent<Rigidbody>().velocity.x*3f, GetComponent<Rigidbody>().velocity.y);
            //sets up a cooldown so you have to wait to dash again
            dashCooldown = 2;
        }
    }
}