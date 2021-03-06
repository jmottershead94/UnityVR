﻿using UnityEngine;
using System.Collections;

public class SCR_TransformButton : SCR_3DButton 
{

	/* Attributes. */
	[Header ("Transform Button Properties")]
	[SerializeField]	private SCR_SceneEditor.TransformState state = SCR_SceneEditor.TransformState.translation;
	private Material defaultMaterial = null;
	private Material clickedMaterial = null;

	/* Methods. */
	/*
	*
	*	Overview
	*	--------
	*	This will be called before initialisation.
	*
	*/
	new protected void Awake()
	{

		base.Awake();

		defaultMaterial = GetComponent<MeshRenderer>().materials[0];
		clickedMaterial = Resources.Load("Materials/MAT_FadedBlack") as Material;

	}

	/*
	*
	*	Overview
	*	--------
	*	This will allow us to define a specific button response.
	*
	*/
	override public void ButtonPressResponse()
	{
		
		/* Sets the new transform state. */
		sceneEditor.CurrentTransformState = state;

	}

	/*
	*
	*	Overview
	*	--------
	*	This will be called every frame.
	*
	*/
	new private void Update()
	{

		base.Update();

		if(sceneEditor.CurrentTransformState == state)
		{

			SCR_AppearenceChanger.ChangeMaterial(gameObject, clickedMaterial);

		}
		else
		{

			SCR_AppearenceChanger.ChangeMaterial(gameObject, defaultMaterial);

		}

	}

}