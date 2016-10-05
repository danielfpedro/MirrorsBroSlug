using UnityEngine;
using System.Collections;

public class Arm : MonoBehaviour {

	public Camera cam;

	private Vector3 mousePos;
	private Vector3 objectPos;
	private float angle;

	private int flip = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 5.23f;

		Vector3 objectPos = cam.WorldToScreenPoint (transform.position);
		mousePos.x = mousePos.x - objectPos.x;
		mousePos.y = mousePos.y - objectPos.y;

		float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		// Não gira além de 90 graus
		if (angle < 90f && angle > -90f)
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
		// if (angle < 90f && angle > -90f || 1 == 1) {
		// 	print(angle);

		// 	Hero hero = GameObject.Find("hero").GetComponent<Hero>();

		// 	if (!hero.facingRight)
		// 		if ((angle > 90f && angle < 180f) && (angle > -180f && angle < -90f))
		// 			transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 180));
		// 	else
		// 		if (angle < 90f && angle > -90f)
		// 			transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
		// }
		
	}
}
