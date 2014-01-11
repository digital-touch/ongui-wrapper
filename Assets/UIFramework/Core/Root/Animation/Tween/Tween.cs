using UnityEngine;
using System.Collections;
using System;

public abstract class Tween : MonoBehaviour
{	
		public Action<Tween> UpdatedEvent;
		public Action<Tween> StartedEvent;
		public Action<Tween> CompletedEvent;
	
		public float elapsedTime = 0;
		public float delay = 0;
		public float duration = 1;

		public EaseDelegate easingFunction = Linear.EaseNone;
	
		public object value;
	
		public bool isTweening = false;
	
		public bool isPaused = false;	
		
		protected virtual void Awake ()
		{
					
		}
	
		public void Play ()
		{		
				isTweening = true;
				UITweener.Add (this);
		}
	
		public void Stop ()
		{
				isTweening = false;
				UITweener.Remove (this);				
		}
	
		public void Finish ()
		{		
				elapsedTime = duration;
				if (CompletedEvent != null) {
						CompletedEvent (this);
				}
		}
	
		public virtual void Reset ()
		{
				elapsedTime = delay * -1;		
		}
		
		public void Update ()
		{
				if (isTweening && !isPaused) {			
						
						if (elapsedTime >= 0) {
								float time = (elapsedTime >= 0) ? elapsedTime : 0;
								UpdateValue (time);					
								if (UpdatedEvent != null) {
										UpdatedEvent (this);
								}	
						} else {
								UpdateValue (0);					
								if (UpdatedEvent != null) {
										UpdatedEvent (this);
								}
						}
			
						elapsedTime += Time.deltaTime;
			
						if (elapsedTime >= duration) {
								UpdateValue (duration);					
								Stop ();								
								Finish ();
								return;
						}
				}		
		}
	
		
		public virtual T UpdateValue<T> (float time, T value) where T : class
		{
				return null;
		}
	
		protected abstract void UpdateValue (float time);
		
		
}
