using UnityEngine;
using System.Collections;

public class FloatTween : UITween
{
		public float targetValue {
				set {
						this.value = value;
				}
				get {
						return (float)this.value;
				}
		}
	
		public float valueFrom;
	
		public float valueChange;		
	
		public float valueTo {
				set {
						valueChange = value - valueFrom;
				}
		}
	
		public override void Reset ()
		{
				targetValue = valueFrom;
				base.Reset ();
		}
	
		protected override void UpdateValue (float time)
		{				
				targetValue = (float)easingFunction (time, valueFrom, valueChange, duration);				
		}
	
	
}
