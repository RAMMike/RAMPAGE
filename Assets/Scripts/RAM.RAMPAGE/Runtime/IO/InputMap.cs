using UnityEngine;

namespace RAM.RAMPAGE.Runtime.IO
{
	[CreateAssetMenu(fileName = "Moe Input Map", menuName = "RAM.RAMPAGE/IO/Moe Input Map")]
	public class InputMap : ScriptableObject
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