using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public GameObject shot;
	public Transform ShotSpawn;

	public float fireRate = 0.5f;
	private float nextFire = 0f;

	public float shotSpeed = 2000f;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			GameObject Bullet = Instantiate (shot, ShotSpawn.position, ShotSpawn.rotation) as GameObject;

			Bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(shotSpeed, this.transform.rotation.eulerAngles.z));
		}
	}
}
