using UnityEngine;
using System.Collections;

public class FloatTween : Tween {

	public float targetValue {
		set {
			this.value = value;
		}
		get {
			return (float) this.value;
		}
	}
	
	public float valueFrom;
	
	public float valueChange;		
	
	public FloatTween (float valueFrom, float valueTo, float duration): base(duration) {
		
		this.valueFrom = valueFrom;
		this.valueChange = valueTo - valueFrom;
		
		Reset();
	}
	
	public FloatTween (float valueFrom, float valueTo, float duration, float delay): base(duration, delay) {
		
		this.valueFrom = valueFrom;
		this.valueChange = valueTo - valueFrom;
		
		Reset();
	}
	
	public FloatTween (float valueFrom, float valueTo, float duration, float delay, EaseDelegate easingFunction):base(duration, delay, easingFunction) {
		
		this.valueFrom = valueFrom;
		this.valueChange = valueTo - valueFrom;
		
		Reset();
	}
	
	public override void Reset() {
		targetValue = valueFrom;
		base.Reset();
	}
	
	protected override void UpdateValue(float time) {				
		targetValue = (float) easingFunction(time, valueFrom, valueChange, duration);				
	}
	
	public override void Initialize() {
	}
	
	public override void Dispose() {
	}
}
