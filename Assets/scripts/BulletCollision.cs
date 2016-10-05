using UnityEngine;
using System.Collections;

public class BulletCollision : MonoBehaviour {

	public bool rebound = false;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (rb.velocity.x == 0){
			Destroy(this.gameObject);
		}
	}
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Enemy") {	
			Destroy(this.gameObject);
		}
	}

}
