using UnityEngine;
using System.Collections;

public class FadeOutTween : AlphaTween
{

		public FadeOutTween (UIWidgetTransform target, float duration):base(target, 1,0,duration)
		{								
		}
	
		public FadeOutTween (UIWidgetTransform target, float duration, float delay):base(target,1,0,duration,delay)
		{				
	
		}
	
		public FadeOutTween (UIWidgetTransform target, float duration, float delay, EaseDelegate easingFunction):base(target,1,0,duration,delay,easingFunction)
		{				
	
		}	
}
