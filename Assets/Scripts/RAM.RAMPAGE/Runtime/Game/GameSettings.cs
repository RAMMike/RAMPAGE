using System;
using Com.LuisPedroFonseca.ProCamera2D;
using RAM.RAMPAGE.Runtime.Spawning;
using RAM.RAMPAGE.Runtime.IO;
using RAM.RAMPAGE.Runtime.Locomotion;
using RAM.RAMPAGE.Runtime.Pawns;
using UnityEngine;

namespace RAM.RAMPAGE.Runtime.Game
{
	[CreateAssetMenu
	(
		fileName = "Game Settings",
		menuName = "RAMPAGE/Game/Game Settings"
	)]
	public class GameSettings : ScriptableObject
	{
		[SerializeField]
		private Pawn _player;

		public Pawn Player => _player;

		[SerializeField]
		private PlayerInputHandler.Settings _input;

		public PlayerInputHandler.Settings Input => _input;

		[SerializeField]
		private PawnMoveHandler.Settings _playerMovement;

		public PawnMoveHandler.Settings PlayerMovement => _playerMovement;

	}
}