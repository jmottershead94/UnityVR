﻿using UnityEngine;
using System.Collections;

namespace IndieJayVR
{
	namespace Examples
	{
		namespace FPS
		{
			/// <summary>
			/// Provides access to common game functionality.
			/// </summary>
			public class SCR_GameControl
			{
				private static bool paused = false;
				private static bool gameOver = false;

				/// <summary>
				/// Locks the cusor.
				/// </summary>
				public static void LockCursor()
				{
					Cursor.lockState = CursorLockMode.Locked;
					Cursor.visible = false;
				}

				/// <summary>
				/// Unlocks the cursor.
				/// </summary>
				public static void UnlockCursor()
				{
					Cursor.lockState = CursorLockMode.None;
					Cursor.visible = true;
				}

				/// <summary>
				/// Follows the mouse.
				/// </summary>
				/// <param name="transform">Transform to follow the mouse.</param>
				public static void FollowMouse(Transform transform)
				{
					Camera cam = Camera.main;
					Vector3 screenPoint = cam.WorldToScreenPoint(transform.position);
					Vector3 offset = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
					transform.position = offset;
				}

				/// <summary>
				/// Gets or sets a value indicating if the game is paused.
				/// </summary>
				/// <value><c>true</c> if paused; otherwise, <c>false</c>.</value>
				public static bool IsPaused
				{
					get { return paused; }
					set { paused = value; }
				}

				/// <summary>
				/// Gets or sets a value indicating is game over.
				/// </summary>
				/// <value><c>true</c> if the game is over; otherwise, <c>false</c>.</value>
				public static bool IsGameOver
				{
					get{ return gameOver; }
					set{ gameOver = value; }
				}
			}
		}
	}
}