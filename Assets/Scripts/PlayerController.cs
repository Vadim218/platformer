using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public GameObject respawn;
	public enum ProjectAxis { onlyX = 0, xAndY = 1 };
	public ProjectAxis projectAxis = ProjectAxis.onlyX;
	public float speed = 150;
	public float addForce = 7;
	public bool isFacingRight = true;
	private KeyCode leftButton;
	private KeyCode rightButton;
	private KeyCode upButton;
	private KeyCode downButton;
	private KeyCode addForceButton;
	private Vector3 direction;
	private float vertical;
	private float horizontal;
	private Rigidbody2D body;
	private float rotationY;
	private bool jump;

    public void Dead()
    {
        transform.position = respawn.transform.position;
        Camera.main.GetComponent<CameraMove>().Dead();
    }

    void OnCollisionStay2D(Collision2D coll)
	{
		if (coll.transform.tag == "Ground")
		{
			body.drag = 0;
			jump = true;

		}
	}

	void OnCollisionExit2D(Collision2D coll)
	{
		if (coll.transform.tag == "Ground")
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
			if (Input.GetKey(addForceButton) && jump)
			{
				body.velocity = new Vector2(0, addForce);
			}
		}
	}

	void Flip()
	{
		if (projectAxis == ProjectAxis.onlyX && !UI.isPaused)
		{
			isFacingRight = !isFacingRight;
			GetComponent<SpriteRenderer>().flipX = isFacingRight;
		}
	}

	async void Control(){
		await Task.Delay(1);
		leftButton = Settings.left;
		rightButton = Settings.right;
		upButton = Settings.up;
		downButton = Settings.down;
		addForceButton = Settings.jump;
	}

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.fixedAngle = true;

        if (projectAxis == ProjectAxis.xAndY)
        {
            body.gravityScale = 0;
            body.drag = 10;
        }

        Control();
    }

    // Страшно:
    void Update()
	{
		if (Input.GetKey(upButton)) 
			vertical = 1;
		else 
			if (Input.GetKey(downButton)) 
				vertical = -1; 
			else
				vertical = 0;

		if (Input.GetKey(leftButton)) 
			horizontal = -1;
		else 
			if (Input.GetKey(rightButton)) 
				horizontal = 1; 
			else 
				horizontal = 0;

		if (projectAxis == ProjectAxis.onlyX)
			direction = new Vector2(horizontal, 0);
		else
		{
			if (Input.GetKeyDown(addForceButton)) 
				speed += addForce; 
			else 
				if (Input.GetKeyUp(addForceButton)) 
					speed -= addForce;
			direction = new Vector2(horizontal, vertical);
		}

		if (horizontal > 0 && !isFacingRight)
            Flip();
        else 
        	if (horizontal < 0 && isFacingRight)
            	Flip();
	}
}
