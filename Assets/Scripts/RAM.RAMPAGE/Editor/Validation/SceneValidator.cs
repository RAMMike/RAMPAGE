using System;
using RAM.RAMPAGE.Runtime.Game;
using UnityEditor;
using static  UnityEngine.Debug;

namespace RAM.RAMPAGE.RAM.RAMPAGE.Editor.Validation
{
	public static class SceneValidator
	{

		[MenuItem(itemName: "RAMPAGE/Validate Scene %&v")]
		private static void Validate()
		{
			bool raiseExceptions = UnityEngine.Assertions.Assert.raiseExceptions;
			UnityEngine.Assertions.Assert.raiseExceptions = true;

			try
			{
				Bootstrapper.Instance.OnValidate();
			}
			catch (Exception)
			{
				LogError("Bootstrapper validated unsuccessfully.");
				throw;
			}
			finally
			{
				UnityEngine.Assertions.Assert.raiseExceptions = raiseExceptions;
			}
			
			// Validate other stuff
			
			
			
			
			
			Log("<color=green>Scene validated successfully.</color>");
			
		}
		
		[MenuItem(itemName: "RAMPAGE/Validate and Run %&r")]
		private static void ValidateAndRun()
		{
			bool raiseExceptions = UnityEngine.Assertions.Assert.raiseExceptions;
			UnityEngine.Assertions.Assert.raiseExceptions = true;
			
			try
			{
				Validate();
			}
			catch (Exception)
			{	
				LogError("Scene validation unsuccessful.");
				throw;
			}
			finally
			{
				UnityEngine.Assertions.Assert.raiseExceptions = raiseExceptions;
			}
			
			EditorApplication.isPlaying = true;
		}
	}
}