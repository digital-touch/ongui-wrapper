using UnityEngine;
using System.Collections;

public class FadeInTween : AlphaTween
{

		public FadeInTween (UIWidgetTransform target, float duration):base(target, 0,1,duration)
		{								
		}
	
		public FadeInTween (UIWidgetTransform target, float duration, float delay):base(target,0,1,duration,delay)
		{				
	
		}
	
		public FadeInTween (UIWidgetTransform target, float duration, float delay, EaseDelegate easingFunction):base(target,0,1,duration,delay,easingFunction)
		{				
	
		}
	
}
