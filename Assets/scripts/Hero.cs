using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

	public float maxSpeed = 6f;
	public float maxSpeedFalling = 4f;

	private float speed;

	bool grounded = false;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public Transform groundCheck;

	bool facingRight = true;

	public float jumpForce = 40f;

	private Rigidbody2D rb;
	private Animator anim;

	// Use this for initialization
	void Start () { 
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();

		anim.SetBool ("FacingRight", true);
	}
	
	// Update is called once per frame
	void Update () {
		if (grounded && Input.GetButton("Jump")) {
			anim.SetBool("Ground", false);
			rb.AddForce(new Vector2(0, jumpForce));
		}
	}
	void FixedUpdate() {
		// Checo se está no chão
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);

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

		if (move > 0) {
			facingRight = true;
		} else {
			facingRight = false;
		}
		anim.SetBool ("FacingRight", facingRight);

			
		rb.velocity = new Vector2(move * speed, rb.velocity.y);
	}
}
