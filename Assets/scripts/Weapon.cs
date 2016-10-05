using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public float fireRate = 0.5f;
	public float shotSpeed = 2000f;

	public float lifetime = 3f;

	public GameObject bullet;
	public Transform BulletSpawn;

	private float nextFire = 0f;

	// private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		// rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			GameObject Bullet = Instantiate (bullet, BulletSpawn.position, BulletSpawn.rotation) as GameObject;

			Bullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(shotSpeed, 0));
			Destroy (Bullet, lifetime);
		}
	}
}
