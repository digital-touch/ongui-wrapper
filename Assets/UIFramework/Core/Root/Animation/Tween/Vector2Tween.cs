using UnityEngine;
using System.Collections;

public class Vector2Tween : Tween
{
	
		public Vector2 targetValue {
				set {
						this.value = value;
				}
				get {
						return (Vector2)this.value;
				}
		}
	
		public Vector2 valueFrom;
	
		public Vector2 valueChange;		
	
		public Vector2 valueTo {
				set {
						valueChange = value - valueFrom;
				}
		}
		protected override void Awake ()
		{
				base.Awake ();
				value = Vector2.zero;
				Reset ();
		}
	
		public override void Reset ()
		{
				base.Reset ();
				targetValue = valueFrom;
		}
	
		protected override void UpdateValue (float time)
		{
				Vector2 output = targetValue;
				
				output.x = (float)easingFunction (time, valueFrom.x, valueChange.x, duration);
				output.y = (float)easingFunction (time, valueFrom.y, valueChange.y, duration);		
				//Debug.Log(":" + this + ", output: " + output + ", to:" + valueFrom+valueChange);
				targetValue = output;
		}
	
		
}
