using UnityEngine;
using System.Collections;

public class Vector2Tween : Tween {
	
	public Vector2 targetValue {
		set {
			this.value = value;
		}
		get {
			return (Vector2) this.value;
		}
	}
	
	public Vector2 valueFrom;
	
	public Vector2 valueChange;		
	
	public Vector2Tween (Vector2 valueFrom, Vector2 valueTo, float duration):base(duration) {		
		this.valueFrom = valueFrom;
		this.valueChange = valueTo - valueFrom;
		
		Reset();
	}
	
	public Vector2Tween (Vector2 valueFrom, Vector2 valueTo, float duration, float delay):base(duration, delay) {		
		
		this.valueFrom = valueFrom;
		this.valueChange = valueTo - valueFrom;
		
		Reset();
				
	}
	
	public Vector2Tween (Vector2 valueFrom, Vector2 valueTo, float duration, float delay, EaseDelegate easingFunction):base(duration, delay, easingFunction) {				
		
		this.valueFrom = valueFrom;
		this.valueChange = valueTo - valueFrom;
		
		Reset();
	}	
	
	public new void Reset() {
		base.Reset();
		targetValue = valueFrom;
	}
	
	protected override void UpdateValue(float time) {
		Vector2 output = targetValue;
				
		output.x = (float) easingFunction(time, valueFrom.x, valueChange.x, duration);
		output.y = (float) easingFunction(time, valueFrom.y, valueChange.y, duration);		
		//Debug.Log(":" + this + ", output: " + output + ", to:" + valueFrom+valueChange);
		targetValue = output;
	}
	
	public override void Initialize() {
	}
	
	public override void Dispose() {
	}
}
