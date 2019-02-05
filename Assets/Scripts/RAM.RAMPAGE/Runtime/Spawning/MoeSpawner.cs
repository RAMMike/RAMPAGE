using System;
using RAM.RAMPAGE.Runtime.Pawns;
using UnityEngine;
using Zenject;

namespace RAM.RAMPAGE.RAM.RAMPAGE.Runtime.Spawning
{
	public class MoeSpawner : MonoBehaviour
	{
		
		
		[SerializeField]
		private Settings _settings;
		public Settings MoeSpawnerSettings => _settings;
		
		[Serializable]
		public class Settings
		{
			[SerializeField]
			private Transform _spawnPoint;
			public Transform SpawnPoint => _spawnPoint;

			[SerializeField]
			private Pawn _moe;
			public Pawn Moe => _moe;
		}
	}
}