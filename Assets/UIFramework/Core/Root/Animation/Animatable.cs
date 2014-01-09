using UnityEngine;
using System.Collections;
using System;

public abstract class Animatable : MonoBehaviour
{

		public Action<Animatable> AnimationCompletedEvent;    
		public Action<Animatable> AnimationAddedEvent;
		public Action<Animatable> AnimationRemovedEvent;
	
		private bool _autoRemove = false;
		
		public bool AutoRemove {
				set {
						_autoRemove = value;
				}
				get {
						return _autoRemove;
				}
		}
	
		public Animatable (bool autoRemove)
		{
				this.AutoRemove = autoRemove;
		}
	
		public Animatable ()
		{
				this.AutoRemove = true;
		}
	
		protected abstract void Update ();
	
		public void FireAnimationCompleted ()
		{
				if (AnimationCompletedEvent != null) {
						AnimationCompletedEvent (this);
				}
		}	
}
