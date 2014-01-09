using UnityEngine;
using System.Collections;

public abstract class Tween : Animatable
{
	
		public delegate void TweenUpdatedHandler (Tween tween,object value);
	
		public event TweenUpdatedHandler TweenUpdated;
	
		public float elapsedTime;
		public float delay;
		public float duration;

		public EaseDelegate easingFunction;
	
		public object value;
	
		public bool isTweening = false;
	
		public bool isPaused = false;	
		
		public Tween ():base(true)
		{
				this.duration = 1;
				this.delay = 0;
				this.easingFunction = Linear.EaseNone;
		}
	
		public Tween (float duration):base(true)
		{
				this.duration = duration;
				this.delay = 0;
				this.easingFunction = Linear.EaseNone;
		}
	
		public Tween (float duration, float delay):base(true)
		{
				this.duration = duration;
				this.delay = delay;
				this.easingFunction = Linear.EaseNone;
		}
	
		public Tween (float duration, float delay, EaseDelegate easingFunction):base(true)
		{
				this.duration = duration;
				this.delay = delay;
				this.easingFunction = easingFunction;
		}
	
		public virtual void Play ()
		{		
				isTweening = true;
		}
	
		public virtual void Stop ()
		{
				isTweening = false;
		}
	
		public virtual void Pause ()
		{		
				isPaused = true;
		}
	
		public virtual void Resume ()
		{
				isPaused = false;
		}
	
		public virtual void Finish ()
		{		
				elapsedTime = duration;
		}
	
		public virtual void Reset ()
		{
				elapsedTime = delay * -1;		
		}
		
		override public void Update ()
		{
				if (isTweening && !isPaused) {			
						
						if (elapsedTime >= 0) {
								float time = (elapsedTime >= 0) ? elapsedTime : 0;
								UpdateValue (time);					
								FireTweenUpdated ();			
						} else {
								UpdateValue (0);					
								FireTweenUpdated ();
						}
			
						elapsedTime += Time.deltaTime;
			
						if (elapsedTime >= duration) {
								UpdateValue (duration);					
								Finish ();
								Stop ();
								Complete ();
								return;
						}
				}		
		}
	
		public void FireTweenUpdated ()
		{
				if (TweenUpdated != null) {
						TweenUpdated (this, value);
				}
		}
		protected abstract void UpdateValue (float time);
		
		
}
