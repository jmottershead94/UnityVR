﻿using UnityEngine;
using System.Collections;

public class SCR_LightButton : SCR_3DButton
{

	/* Attributes. */
	enum LightType
	{
		Point,
		Spot,
		Directional
	};

	[Header("Type of Light")]
	[SerializeField]	private LightType type = LightType.Point;
	private string lightName = "";

	/* Methods. */
	new protected void Awake()
	{
		base.Awake();

		switch(type)
		{
			case LightType.Point:
			{
				lightName = "Point Light Source";
				break;
			}
			case LightType.Spot:
			{
				lightName = "Spot Light Source";
				break;
			}
			case LightType.Directional:
			{
				lightName = "Directional Light Source";
				break;
			}
		}
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

		/* Spawns in a primitive game object at the spawn point. */
		GameObject gameObject = new GameObject(lightName);
		gameObject.transform.position = spawner.position;
		gameObject.transform.SetParent(sceneEditor.transform);
		Light lightComponent = gameObject.AddComponent<Light>();
		SCR_PersistentObject saveObjectComponent = gameObject.AddComponent<SCR_PersistentObject>();


		switch(type)
		{
			case LightType.Point:
			{
				lightComponent.type = UnityEngine.LightType.Point;
				lightComponent.intensity = 8.0f;
				break;
			}
			case LightType.Spot:
			{
				lightComponent.type = UnityEngine.LightType.Spot;
				gameObject.transform.Rotate(90.0f, 0.0f, 0.0f);
				lightComponent.intensity = 8.0f;
				break;
			}
			case LightType.Directional:
			{
				lightComponent.type = UnityEngine.LightType.Directional;
				break;
			}
		}
	}
}