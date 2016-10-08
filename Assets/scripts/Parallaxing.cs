﻿using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour {

	public Transform[] backgrounds;
	public Camera cam;

	private float[] parallaxScales;
	public float smoothing = 1f;

	private Transform camTransform;
	
	private Vector3 previousCamPos;

	// Use this for initialization
	void Awake () {
		camTransform = cam.transform;
	}
	void Start () {
		previousCamPos = camTransform.position;

		parallaxScales = new float [backgrounds.Length];
		for (int i = 0; i < backgrounds.Length; i++) {
			parallaxScales[i] = backgrounds[i].position.z*-1;
		}
	}
	
	// Update is called once per frame
	void Update () {

		for (int i = 0; i < backgrounds.Length; i++){
			float parallax = (previousCamPos.x - camTransform.position.x) * parallaxScales[i];

			float backgroundTargetPosX = backgrounds[i].position.x + parallax;

			Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

			backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
		}

		previousCamPos = camTransform.position;
	}
}
