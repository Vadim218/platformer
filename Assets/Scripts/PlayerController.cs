using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public GameObject respawn;
	public enum ProjectAxis { onlyX = 0, xAndY = 1 };
	public ProjectAxis projectAxis = ProjectAxis.onlyX;
	public float speed = 150;
	public float jumpForce = 5;
	public bool isFacingRight = true;
	private Vector3 direction;
	private float vertical;
	private float horizontal;
	private Rigidbody2D body;
	private bool jump;
	private Animator anim;

    public void Dead()
    {
        transform.position = respawn.transform.position;
        Camera.main.GetComponent<CameraMove>().Dead();
    }

    void OnCollisionStay2D(Collision2D col)
	{
		if (col.transform.tag == "Ground")
		{
			body.drag = 0;
			jump = true;

		}
	}

	void OnCollisionExit2D(Collision2D col)
	{
		if (col.transform.tag == "Ground")
		{
			body.drag = 0;
			jump = false;
		}
	}

	void FixedUpdate()
	{
		body.AddForce(direction * body.mass * speed);

		if (Mathf.Abs(body.velocity.x) > speed / 100f)
		{
			body.velocity = new Vector2(Mathf.Sign(body.velocity.x) * speed / 100f, body.velocity.y);
		}

		if (projectAxis == ProjectAxis.xAndY)
		{
			if (Mathf.Abs(body.velocity.y) > speed / 100f)
			{
				body.velocity = new Vector2(body.velocity.x, Mathf.Sign(body.velocity.y) * speed / 100f);
			}
		}
		else
		{
			if (Input.GetKey(Settings.jump) && jump)
			{
				body.velocity = new Vector2(0, jumpForce);
			}
		}
	}

	void Flip()
	{
		if (projectAxis == ProjectAxis.onlyX && !UI.isPaused)
		{
			isFacingRight = !isFacingRight;
			GetComponent<SpriteRenderer>().flipX = !isFacingRight;
		}
	}

    void Start()
    {
    	anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        body.fixedAngle = true;

        if (projectAxis == ProjectAxis.xAndY)
        {
            body.gravityScale = 0;
            body.drag = 10;
        }
    }

    // Страшно:
    void Update()
	{
		if (Input.GetKey(Settings.up)) 
			vertical = 1;
		else 
			if (Input.GetKey(Settings.down)) 
				vertical = -1; 
			else
				vertical = 0;

		if (Input.GetKey(Settings.left)) 
			horizontal = -1;
		else 
			if (Input.GetKey(Settings.right)) 
				horizontal = 1; 
			else 
				horizontal = 0;

		anim.SetBool("isRunning", horizontal != 0);

		if (projectAxis == ProjectAxis.onlyX)
			direction = new Vector2(horizontal, 0);
		else
		{
			if (Input.GetKeyDown(Settings.jump)) 
				speed += jumpForce; 
			else 
				if (Input.GetKeyUp(Settings.jump)) 
					speed -= jumpForce;
			direction = new Vector2(horizontal, vertical);
		}

		if (horizontal > 0 && !isFacingRight)
            Flip();
        else 
        	if (horizontal < 0 && isFacingRight)
            	Flip();
	}
}