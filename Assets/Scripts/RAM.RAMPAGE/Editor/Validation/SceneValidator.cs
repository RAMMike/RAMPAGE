using System;
using RAM.RAMPAGE.Runtime.Game;
using RAM.RAMPAGE.Runtime.Validation;
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
				ValidateObject(Bootstrapper.Instance);
				ValidateObject(SceneBootstrapper.Instance);
			}
			
			finally
			{
				UnityEngine.Assertions.Assert.raiseExceptions = raiseExceptions;
			}
			
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

		private static void ValidateObject(IValidatable validatable)
		{
			try
			{
				validatable.OnValidate();
			}
			catch (Exception)
			{
				
				LogError($"{validatable.name} validated unsuccessfully.");

				throw;
			}

			Log($"<color=green>{validatable.name} validated successfully.</color>");
		}
	}
}