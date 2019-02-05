 // Copyright © 2019 Royal Alberta Museum
 
using System;
using Com.LuisPedroFonseca.ProCamera2D;
using RAM.RAMPAGE.Runtime.Pawns;
using RAM.RAMPAGE.Runtime.Spawning;
using RAM.RAMPAGE.Runtime.Validation;
using UnityEngine;
using UnityEngine.Assertions;

namespace RAM.RAMPAGE.Runtime.Game
{
	public class SceneBootstrapper : MonoBehaviour, IValidatable
	{
		private static SceneBootstrapper __instance;
		public static SceneBootstrapper Instance
		{
			get
			{
				if (__instance) return __instance;
				__instance = FindObjectOfType<SceneBootstrapper>();

				if (!__instance)
					__instance = new GameObject("[Scene Bootstrapper]").AddComponent<SceneBootstrapper>();

				return __instance;
			}
		}

		[SerializeField]
		private Settings _settings;
		public Settings SceneSettings => _settings;

		private Pawn _playerPrefab;
		private Pawn _activePlayer;

		public void Init(Pawn playerPrefab)
		{
			_playerPrefab = playerPrefab;
		}

		public Pawn spawnPawn()
		{
			_activePlayer = SceneSettings.PawnSpawner.spawn(_playerPrefab);

			return _activePlayer;
		}

		private void Start()
		{
			#if PROCAMERA2D
			SceneSettings.MainCam.AddCameraTarget(_activePlayer.Transform);
			#else
			AppSettings.renderSettings.camera.transform.SetParent(moe.Transform);
			#endif
		}

		#if UNITY_EDITOR
		public void OnValidate()
		{
			Assert.IsNotNull(Instance.SceneSettings.PawnSpawner, "PawnSpawner required in SceneBootstrapper.");
			Assert.IsNotNull(Instance.SceneSettings.MainCam, "A camera is required to operate in the scene.");
		}
		#endif
		
		
		// These are all scene-specific settings that should not dwell inside a ScriptableObject
		[Serializable]
		public class Settings
		{
			[SerializeField]
			private PawnSpawner pawnSpawner;
			public PawnSpawner PawnSpawner => pawnSpawner;
			
			#if PROCAMERA2D
			[SerializeField]
			private ProCamera2D _proCamera2D;
			public ProCamera2D MainCam => _proCamera2D;
			#else
			[SerializeField]
			private Camera _camera;
			public Camera MainCam => _camera;
			#endif
		}
	}
}