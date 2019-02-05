// Copyright © 2019 Royal Alberta Museum

using System;
using System.Collections;
using System.Collections.Generic;
using RAM.RAMPAGE.Runtime.IO;
using RAM.RAMPAGE.Runtime.Pawns;
using UnityEngine;

namespace RAM.RAMPAGE.Runtime.Locomotion
{
	public class PawnMoveHandler
	{
		private readonly Pawn _pawn;
		private readonly InputState _input;
		private readonly Settings _settings;

		public PawnMoveHandler(Pawn pawn, InputState input, Settings settings)
		{
			_pawn = pawn;
			_input = input;
			_settings = settings;
		}

		public void FixedTick()
		{
			if (_input.IsJumping)
				_pawn.AddForce(_settings.JumpForce * Vector2.up, ForceMode2D.Impulse);
			
			if (_input.IsMovingRight)
				_pawn.Velocity = new Vector2(_settings.MoveVelocity, _pawn.Velocity.y);
		}

		[Serializable]
		public class Settings
		{
			[SerializeField]
			private float _moveVelocity = 20f;
			public float MoveVelocity => _moveVelocity;

			[SerializeField]
			private float _jumpForce = 10f;
			public float JumpForce => _jumpForce;
		}
	}
}