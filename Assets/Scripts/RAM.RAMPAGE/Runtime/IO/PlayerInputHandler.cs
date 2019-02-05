// Copyright © 2019 Royal Alberta Museum
using static UnityEngine.Input;

namespace RAM.RAMPAGE.Runtime.IO
{
	public class PlayerInputHandler
	{

		private readonly InputState _inputState;
		private readonly InputMap _map;

		public PlayerInputHandler(InputState inputState, InputMap map)
		{
			_inputState = inputState;
			_map = map;
			_inputState.IsMovingRight = true;
		}

		public void Tick()
		{
			_inputState.IsJumping = GetAxis(_map.Axis_Jump) > 0 || GetKey(_map.Key_Jump);
			_inputState.IsShooting = GetAxis(_map.Axis_Shoot) > 0 || GetKey(_map.Key_Shoot);
		}
	}
}