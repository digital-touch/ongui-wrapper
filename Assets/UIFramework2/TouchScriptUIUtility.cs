using UnityEngine;
using System.Collections;
using TouchScript;

public static class TouchScriptUIUtility
{
	
		public static UITouch toUITouch (TouchPoint touchPoint)
		{
				UITouch touch = new UITouch ();
				
				touch.id = touchPoint.Id;
				
				Vector2 position = Vector2.zero;
				
				position.x = (int)touchPoint.Position.x;
				position.y = (int)(Screen.height - touchPoint.Position.y);
				
				touch.position = position;
				
				return touch;
		}
	
}
