// Copyright © 2019 Royal Alberta Museum

using RAM.RAMPAGE.Runtime.IO;
using RAM.RAMPAGE.Runtime.Locomotion;
using UnityEngine;
using UnityEngine.Assertions;

namespace RAM.RAMPAGE.Runtime.Pawns
{
	public class Pawn : MonoBehaviour
	{
		private PlayerInputHandler _playerInput;
		private PawnMoveHandler _moveHandler;
		
		public Transform Transform { get; private set; }
		public Collider2D Collider2D { get; private set; }
		public Rigidbody2D Rigidbody2D { get; private set; }
		public SpriteRenderer SpriteRenderer { get; private set; }
		public GroundCheck GroundCheck { get; private set; }

		public Vector3 Position
		{
			get => Transform.position;
			set => Transform.position = value;
		}

		public Quaternion Rotation
		{
			get => Transform.rotation;
			set => transform.rotation = value;
		}

		public Vector2 Velocity
		{
			get => Rigidbody2D.velocity;
			set => Rigidbody2D.velocity = value;
		}

		public bool Grounded => GroundCheck.Grounded;

		public void AddForce(Vector2 value, ForceMode2D forceMode2D) { Rigidbody2D.AddForce(value, forceMode2D); }
		 
		public void Init(PlayerInputHandler.Settings settings, PawnMoveHandler.Settings moveSettings)
		{
			InputState state = new InputState();
			_playerInput = new PlayerInputHandler(state, settings);
			_moveHandler = new PawnMoveHandler(this, state, moveSettings);

		}
		
		private void InitComponents()
		{
			Transform      = GetComponent<Transform>();
			Collider2D     = GetComponent<Collider2D>();
			Rigidbody2D    = GetComponent<Rigidbody2D>();
			SpriteRenderer = GetComponent<SpriteRenderer>();
			GroundCheck    = GetComponentInChildren<GroundCheck>();
		}
		
		private void Awake()
		{
			InitComponents();
		}

		private void Update()
		{
			_playerInput.Tick();			
		}

		private void FixedUpdate()
		{
			_moveHandler.FixedTick();
		}
		
		#if UNITY_EDITOR
		private void OnValidate()
		{
			Assert.IsNotNull(GetComponent<Collider2D>(), "Please add a Collider2D to this.");
			Assert.IsNotNull(GetComponent<Rigidbody2D>(), "Please add a Rigidbody2D to this.");
			Assert.IsNotNull(GetComponent<SpriteRenderer>(), "Please add a SpriteRenderer to this.");
		}
		#endif
	}
}