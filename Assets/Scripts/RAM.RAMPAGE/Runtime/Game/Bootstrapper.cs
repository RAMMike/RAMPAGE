// Copyright © 2019 Royal Alberta Museum

using System;
using Com.LuisPedroFonseca.ProCamera2D;
using RAM.RAMPAGE.RAM.RAMPAGE.Runtime.Spawning;
using RAM.RAMPAGE.Runtime.IO;
using RAM.RAMPAGE.Runtime.Locomotion;
using RAM.RAMPAGE.Runtime.Pawns;
using UnityEngine;
using UnityEngine.Assertions;

namespace RAM.RAMPAGE.Runtime.Game
{
	public class Bootstrapper : MonoBehaviour
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
		private Settings _settings;
		public Settings AppSettings => _settings;

		public void Awake()
		{
			Pawn moe = Instantiate(AppSettings.MoePawn); // should happen in moe spawner
			moe.Position = AppSettings.MoeSpawner.transform.position; // should happen in moe spawner
			
			
			moe.Init(AppSettings.InputMap, AppSettings.MoveSettings);
			
			
			#if PROCAMERA2D
			AppSettings.renderSettings.camera.AddCameraTarget(moe.Transform);
			#else
			AppSettings.renderSettings.camera.transform.SetParent(moe.Transform);
			#endif
		}
		
		
		
		
		[Serializable]
		public class Settings
		{
			[SerializeField]
			private InputMap _inputMap;
			public InputMap InputMap => _inputMap;

			[SerializeField]
			private PawnMoveHandler.Settings _moveSettings;
			public PawnMoveHandler.Settings MoveSettings => _moveSettings;

			[SerializeField]
			private MoeSpawner _moeSpawner;
			public MoeSpawner MoeSpawner => _moeSpawner;

			[SerializeField]
			private  Pawn _moePawn;
			public Pawn MoePawn => _moePawn;

			public RenderSettings renderSettings;
			

			[Serializable]
			public class RenderSettings
			{
				#if PROCAMERA2D
				public ProCamera2D camera;
				#else
				public Camera camera;
				#endif
			}

		}
		
		#if UNITY_EDITOR
		public void OnValidate()
		{
			 Assert.IsNotNull(Instance, "Instance of Bootstrapper required to run the game. ");
			 Assert.IsNotNull(Instance.AppSettings, "AppSettings required in Bootstrapper.");
			 Assert.IsNotNull(Instance.AppSettings.InputMap, "InputMap required in Bootstrapper.");
			 Assert.IsNotNull(Instance.AppSettings.MoveSettings, "Move Settings required in Bootstrapper.");
			 Assert.IsNotNull(Instance.AppSettings.MoeSpawner, "MoeSpawner required in Bootstrapper.");
			 Assert.IsNotNull(Instance.AppSettings.MoePawn, "Moe Pawn required in Bootstrapper.");
			 
			 Assert.IsNotNull(Instance._settings.renderSettings.camera,  "A camera is required to operate in the scene.");
		}
		#endif
		
	}
}