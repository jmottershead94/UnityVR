﻿/*
*
*	Prefabs Panel Class
*	===================
*
*	Created: 	2016/11/21
*	Filter:		Scripts/UI
*	Class Name: SCR_PrefabsPanel
*	Base Class: SCR_Panel
*	Author: 	1300455 Jason Mottershead
*
*	Purpose:	This will allow the menu to choose if the user wants to use any
*				standard assets, or there own assets.
*
*/

/* Unity includes here. */
using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Win32;

/* Prefabs panel IS A panel, therefore inherits from it. */
public class SCR_PrefabsPanel : SCR_Panel 
{

	/* Attributes. */
	private string filePathToStandardPrefabs = "";
	[SerializeField]	private List<GameObject> prefabs = null;
	[SerializeField]	List<Texture2D> prefabPreviews = null;

	/* Methods. */
	/*
	*
	*	Overview
	*	--------
	*	This will be called before initialisation.
	*
	*/
	new private void Awake()
	{
		
		filePathToStandardPrefabs = "Assets/Prefabs/";
		prefabs = new List<GameObject>();
		prefabPreviews = new List<Texture2D>();
		AddPrefabs(filePathToStandardPrefabs);

	}

	private void AddPrefabs(string filePath)
	{

		/* Loading prefabs from the standard file path. */
		string searchPattern = "*";
		SearchOption searchOption = SearchOption.AllDirectories;
		string[] filePaths = Directory.GetFiles(filePath, searchPattern, searchOption);

		if(filePaths.Length > 0)
		{
			foreach(string path in filePaths)
			{
				if(path.EndsWith(".meta")) continue;

				GameObject tempPrefab = AssetDatabase.LoadAssetAtPath(path, typeof(GameObject)) as GameObject;
				prefabPreviews.Add(AssetPreview.GetAssetPreview(tempPrefab));

				if(tempPrefab != null)
				{
					prefabs.Add(tempPrefab);
				}
			}
		}

		/* Loading prefabs from resources folder. */
		GameObject[] resourcePrefabs = Resources.LoadAll<GameObject>("Prefabs");

		if(resourcePrefabs.Length > 0)
		{
			foreach(GameObject tempPrefab in resourcePrefabs)
			{
				prefabPreviews.Add(AssetPreview.GetAssetPreview(tempPrefab));
				prefabs.Add(tempPrefab);
			}
		}

		for(int i = 0; i < prefabPreviews.Count; i++)
		{
			GameObject prefabPreview = Resources.Load("Standard VR Assets/PRE_PrefabButton", typeof (GameObject)) as GameObject;
			prefabPreview = Instantiate(prefabPreview, transform.position, Quaternion.identity) as GameObject;
			prefabPreview.name = prefabs[i].name;
			prefabPreview.transform.SetParent(transform);

			Transform label = transform.FindChild("Label").transform;
			prefabPreview.transform.position = new Vector3(label.position.x + (i * 0.5f), label.position.y - 1.25f, label.position.z - 0.3f);
			prefabPreview.GetComponent<Renderer>().materials[0].mainTexture = (Texture)prefabPreviews[i];
		}

	}

	void Start () 
	{
		//AddPrefabs(filePathToStandardPrefabs);
	}

	void Update () 
	{}

	public List<GameObject> Prefabs
	{
		get { return prefabs;}
	}

}