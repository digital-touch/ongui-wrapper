using UnityEngine;
using System.Collections;

public class MoveTween : Vector2Tween
{	
		protected override void UpdateValue (float time)
		{
				base.UpdateValue (time);
				target.x = (int)targetValue.x;
				target.y = (int)targetValue.y;
		}
	
	
}
