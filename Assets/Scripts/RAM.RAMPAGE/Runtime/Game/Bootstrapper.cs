// Copyright © 2019 Royal Alberta Museum

using System;
using Com.LuisPedroFonseca.ProCamera2D;
using RAM.RAMPAGE.Runtime.Spawning;
using RAM.RAMPAGE.Runtime.IO;
using RAM.RAMPAGE.Runtime.Locomotion;
using RAM.RAMPAGE.Runtime.Pawns;
using RAM.RAMPAGE.Runtime.Validation;
using UnityEngine;
using UnityEngine.Assertions;

namespace RAM.RAMPAGE.Runtime.Game
{
	
	public class Bootstrapper : MonoBehaviour, IValidatable
	{
		private static Bootstrapper __instance;
		public static Bootstrapper Instance
		{
			get
			{
				if (__instance) return __instance;
				__instance = FindObjectOfType<Bootstrapper>();

				if (!__instance)
					__instance = new GameObject("[Bootstrapper]").AddComponent<Bootstrapper>();

				return __instance;
			}
		}
		
		[SerializeField]
		private GameSettings _settings;
		public GameSettings GameSettings => _settings;

		public void Awake()
		{
			SceneBootstrapper.Instance.Init(GameSettings.Player);
			
			Pawn player = SceneBootstrapper.Instance.spawnPawn();
			
			player.Init(GameSettings.Input, GameSettings.PlayerMovement);
		}
		
		#if UNITY_EDITOR
		public void OnValidate()
		{
			 Assert.IsNotNull(Instance, "Instance of Bootstrapper required to run the game. ");
			 Assert.IsNotNull(Instance.GameSettings, "AppSettings required in Bootstrapper.");
			 Assert.IsNotNull(Instance.GameSettings.Input, "InputMap required in Bootstrapper.");
			 Assert.IsNotNull(Instance.GameSettings.PlayerMovement, "Move Settings required in Bootstrapper.");
			 Assert.IsNotNull(Instance.GameSettings.Player, "Moe Pawn required in Bootstrapper.");
		}
		#endif
		
	}
}