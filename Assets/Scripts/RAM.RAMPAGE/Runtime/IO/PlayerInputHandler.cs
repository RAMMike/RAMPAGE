// Copyright © 2019 Royal Alberta Museum

using System;
using UnityEngine;
using static UnityEngine.Input;

namespace RAM.RAMPAGE.Runtime.IO
{
	public class PlayerInputHandler
	{

		private readonly InputState _inputState;
		private readonly Settings _settings;

		public PlayerInputHandler(InputState inputState, Settings settings)
		{
			_inputState = inputState;
			_settings = settings;
			_inputState.IsMovingRight = true;
		}

		public void Tick()
		{
			_inputState.IsJumping = GetKeyDown(_settings.Key_Jump); // || GetAxis(_settings.Axis_Jump) > 0;
			_inputState.IsShooting = GetAxis(_settings.Axis_Shoot) > 0 || GetKey(_settings.Key_Shoot);
		}

		[Serializable]
		public class Settings
		{
			[SerializeField]
			private string _axis_Jump = "Jump";
			public string Axis_Jump => _axis_Jump;
		
			[SerializeField]
			private string _axis_Shoot = "Shoot";
			public string Axis_Shoot => _axis_Shoot;

			[SerializeField]
			private KeyCode _key_jump = KeyCode.Space;
			public KeyCode Key_Jump => _key_jump;

			[SerializeField]
			private KeyCode _key_Shoot = KeyCode.Z;
			public KeyCode Key_Shoot => _key_Shoot;	
		}
	}
}