using UnityEngine;
using System.Collections;

public class PressAlphaChanger : TouchDebugger
{

		public float alphaNormal = 1f;
		public float alphaPressed = 0.5f;

		override protected void OnTouchBegan (UIGameObject target, UITouch touch)
		{
				target.alpha = alphaPressed;	
		}
	
		override protected void OnTouchEnded (UIGameObject target, UITouch touch)
		{
				target.alpha = alphaNormal;	
		}
}
