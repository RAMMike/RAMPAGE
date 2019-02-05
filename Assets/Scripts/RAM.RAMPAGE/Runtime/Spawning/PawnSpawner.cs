using System;
using RAM.RAMPAGE.Runtime.Locomotion;
using RAM.RAMPAGE.Runtime.Pawns;
using UnityEngine;
using Zenject;

namespace RAM.RAMPAGE.Runtime.Spawning
{
	public class PawnSpawner : MonoBehaviour
	{
		public Pawn spawn(Pawn pawn)
		{
			Pawn newPawn = Instantiate(pawn);
			newPawn.Transform.position = transform.position;
			
			return newPawn;
		}
	}
}