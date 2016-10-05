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

	public bool facingRight = true;

	public float jumpForce = 40f;

	private Rigidbody2D rb;
	private Animator anim;

	private float nextJump = 0f;
	public float jumpRate = 1f;

	// Use this for initialization
	void Start () { 
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();

		anim.SetBool ("FacingRight", true);
	}
	
	// Update is called once per frame
	void Update () {
	}
	void FixedUpdate() {
		// Checo se está no chão
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);
		// print(grounded);

		if (grounded && Input.GetButton("Jump") && Time.time > nextJump) {
			print("Pular");
			nextJump = Time.time + jumpRate;
			anim.SetBool("Ground", false);
			rb.AddForce(new Vector2(0, jumpForce));
		}		

		float move = Input.GetAxis("Horizontal");
		anim.SetFloat ("Speed", Mathf.Abs(move));

		if (Input.GetButton ("Dash")) {
			print ("Dashing");
			GetComponent<BoxCollider2D> ().size = new Vector2 (0.8f, 0.8f);
			GetComponent<BoxCollider2D> ().offset = new Vector2 (0, -0.6f);
		} else {
			GetComponent<BoxCollider2D> ().size = new Vector2 (0.8f, 2f);
			GetComponent<BoxCollider2D> ().offset = new Vector2 (0, 0);
		}

		if (!grounded) {
			speed = maxSpeedFalling;
		} else {
			speed = maxSpeed;
		}

		anim.SetBool ("FacingRight", facingRight);

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
