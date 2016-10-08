using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

	public float maxSpeed = 50f;
	public float maxSpeedFalling = 5f;

	private float speed;

	bool grounded = false;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public Transform groundCheck;

	private Rigidbody2D rb;

	private float nextJump = 0f;

	public float jumpForce = 40f;
	public float jumpRate = 1f;

	private bool facingRight;

	// Use this for initialization
	void Start () { 
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	}
	void FixedUpdate() {
		// Checo se está no chão
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

		if (grounded && Input.GetButton("Jump") && Time.time > nextJump) {
			print("Pular");
			nextJump = Time.time + jumpRate;
			rb.AddForce(new Vector2(0, jumpForce));
		}		

		float move = Input.GetAxis("Horizontal");

		if (!grounded) {
			speed = maxSpeedFalling;
		} else {
			speed = maxSpeed;
		}

		if (move > 0 && !facingRight)
			flip();
		else if (move < 0 && facingRight)
			flip();

		rb.velocity = new Vector2(move * speed, rb.velocity.y);
	}
	void flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
