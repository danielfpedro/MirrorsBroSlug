using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public ParticleSystem blood;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D col){
        
		if (col.gameObject.tag == "Bullet") {	
			print(col.contacts[0]);
			// print("Foi acertado.");
			
			
			foreach(ContactPoint2D hit in col.contacts)
			{
				Vector2 hitPoint = hit.point;
				ParticleSystem bloodParticle = Instantiate(blood, new Vector3(hitPoint.x, hitPoint.y, 0), Quaternion.identity) as ParticleSystem;
				Destroy(bloodParticle.gameObject, 4f);
			}
		}
	}
	// function OnCollisionEnter(col: Collision){
	// 	if (col.transform.tag == "Enemy"){
	// 	var contact = col.contacts[0]; // get the first contact point info // find the necessary rotation...
	// 	var rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
	// 	 Instantiate(bloodPrefab, contact.point, rot); 
}
