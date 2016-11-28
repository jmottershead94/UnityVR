﻿/*
*
*	Camera Class
*	============
*
*	Created: 	2016/11/21
*	Filter:		Scripts
*	Class Name: SCR_Rotate
*	Base Class: Monobehaviour
*	Author: 	1300455 Jason Mottershead
*
*	Purpose:	Camera will provide debugging/testing capabilities whilst not having 
*				access to the VR equipment at university. This will allow the user to 
*				use standard keyboard controls to navigate the scene.
*
*/

/* Unity includes here. */
using UnityEngine;
using System.Collections;

/* Look into the SteamVR class for VR character movement. */
/* Camera IS A game object, therefore inherits from it. */
public class SCR_Camera : MonoBehaviour
{

	/* Attributes. */
	[SerializeField]	private Vector3 speed = Vector3.zero;	/* This will store how fast the camera will move. */

	/* Methods. */
	/*
	*
	*	Overview
	*	--------
	*	This method will check user input to provide camera movement.
	*
	*/
	private void Controls()
	{

		/* Set the transform of the camera to look at the reference point of the user. */
		/* transform.LookAt(referencePoint.position); */

		/* If the W key has been pressed. */
		/* VR Equivalent: If the user pushes up on the left touch pad? */
		if(Input.GetKey(KeyCode.W))
		{

			/* Move the camera. */
			transform.Translate(0.0f, 0.0f, speed.z);

		}

		/* If the A key has been pressed. */
		/* VR Equivalent: If the user pushes left on the left touch pad? */
		if(Input.GetKey(KeyCode.A))
		{

			/* Move the camera. */
			transform.Translate(speed.x * -1.0f, 0.0f, 0.0f);

		}

		/* If the S key has been pressed. */
		/* VR Equivalent: If the user pushes down on the left touch pad? */
		if(Input.GetKey(KeyCode.S))
		{

			/* Move the camera. */
			transform.Translate(0.0f, 0.0f, speed.z * -1.0f);

		}

		/* If the D key has been pressed. */
		/* VR Equivalent: If the user pushes right on the left touch pad? */
		if(Input.GetKey(KeyCode.D))
		{

			/* Move the camera. */
			transform.Translate(speed.x, 0.0f, 0.0f);

		}

		/* If the look at works as expected, the z and x axis values should allow the user to navigate by looking up and pressing up. */
		/* If the E key has been pressed. */
		/* VR Equivalent: If the user holds the left hand controller trigger and pushes up on the touch up. */
		if(Input.GetKey(KeyCode.E))
		{

			/* Move the camera. */
			transform.Translate(0.0f, speed.y, 0.0f);

		}

		/* If the look at works as expected, the z and x axis values should allow the user to navigate by looking down and pressing up. */
		/* If the Q key has been pressed. */
		/* VR Equivalent: If the user holds the left hand controller trigger and pushes down on the touch up. */
		if(Input.GetKey(KeyCode.Q))
		{

			/* Move the camera. */
			transform.Translate(0.0f, speed.y * -1.0f, 0.0f);

		}

	}
	
	/*
	*
	*	Overview
	*	--------
	*	This will be called every frame.
	*
	*/
	private void Update () 
	{

		/* Handles user input for camera control. */
		Controls();

	}

}