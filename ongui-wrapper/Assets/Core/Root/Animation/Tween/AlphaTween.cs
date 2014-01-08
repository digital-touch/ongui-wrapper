using UnityEngine;
using System.Collections;

public class AlphaTween : FloatTween
{

		public UIWidgetTransform target;
	
		public AlphaTween (UIWidgetTransform target, float valueFrom, float valueTo, float duration):base(valueFrom,valueTo,duration)
		{						
				this.target = target;
		}
	
		public AlphaTween (UIWidgetTransform target, float valueFrom, float valueTo, float duration, float delay):base(valueFrom,valueTo,duration,delay)
		{				
				this.target = target;
		}
	
		public AlphaTween (UIWidgetTransform target, float valueFrom, float valueTo, float duration, float delay, EaseDelegate easingFunction):base(valueFrom,valueTo,duration,delay,easingFunction)
		{				
				this.target = target;
		}
	
		protected override void UpdateValue (float time)
		{
				base.UpdateValue (time);
				target.alpha = ((float)targetValue);
		}
	
}
