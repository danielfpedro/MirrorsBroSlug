using UnityEngine;
using System.Collections;

public class SmoothCamera : MonoBehaviour {

	public float dampTime = 0.02f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;

	void start()
	{
		
	}

	// Update is called once per frame
	void Update () 
	{
		Camera cam = GetComponent<Camera>();
		if (target)
		{
			Vector3 point = cam.WorldToViewportPoint(target.position);
			Vector3 delta = target.position - cam.ViewportToWorldPoint(new Vector3(0.5f, 0.3f, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}
	}
}
