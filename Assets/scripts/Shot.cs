using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

	public float speed = 2000f;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.AddForce(new Vector2(speed, 80f * speed));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
