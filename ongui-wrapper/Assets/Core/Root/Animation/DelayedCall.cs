using UnityEngine;
using System.Collections;

public delegate void Callback();
public delegate void CallbackWithParameter();

public class DelayedCall : Animatable {
	
	public float elapsedTime;
	public float delay;
	public float duration;
	public bool isRunning = false;
	
	Callback callback;
	
	public DelayedCall():base(true) {
		this.duration = 1;
		this.delay = 0;		
	}
	
	public DelayedCall(float duration):base(true) {
		this.duration = duration;
		this.delay = 0;		
	}
	
	public DelayedCall(float duration, float delay):base(true) {
		this.duration = duration;
		this.delay = delay;		
	}
	
	public DelayedCall(Callback callback, float duration, float delay):base(true) {
		this.duration = duration;
		this.delay = delay;
		this.callback = callback;
	}
	
	public DelayedCall(Callback callback, float duration):base(true) {
		this.duration = duration;
		this.delay = 0;
		this.callback = callback;
	}
	
	public DelayedCall(Callback callback):base(true) {
		this.duration = 1;
		this.delay = 0;
		this.callback = callback;
	}
	
	public void Run() {		
		isRunning = true;
	}
	
	public void Stop() {
		isRunning = false;
	}
	
	public void Finish() {		
		elapsedTime = duration;
	}
	
	public void Reset() {
		elapsedTime = -delay;		
	}
		
	override public void Update () {
		if (isRunning) {			
						
			elapsedTime+=Time.deltaTime;
			
			if (elapsedTime >= duration) {				
				Finish();
				Stop();
				Complete();
				if (callback != null) {
					callback();
				}
				return;
			}
		}		
	}	
	
	public override void Initialize() {
	}
	
	public override void Dispose() {
	}
}


