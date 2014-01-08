using UnityEngine;
using System.Collections;

public class MoveTween : Vector2Tween
{	
		public UIWidgetTransform target;
	
		public MoveTween (UIWidgetTransform target, Vector2 valueFrom, Vector2 valueTo, float duration):base(valueFrom,valueTo,duration)
		{						
				this.target = target;
		}
	
		public MoveTween (UIWidgetTransform target, Vector2 valueFrom, Vector2 valueTo, float duration, float delay):base(valueFrom,valueTo,duration,delay)
		{				
				this.target = target;
		}
	
		public MoveTween (UIWidgetTransform target, Vector2 valueFrom, Vector2 valueTo, float duration, float delay, EaseDelegate easingFunction):base(valueFrom,valueTo,duration,delay,easingFunction)
		{				
				this.target = target;
		}
	
		protected override void UpdateValue (float time)
		{
				base.UpdateValue (time);
				target.x = (int)targetValue.x;
				target.y = (int)targetValue.y;
		}
	
	
}
