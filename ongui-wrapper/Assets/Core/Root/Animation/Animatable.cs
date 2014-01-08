using UnityEngine;
using System.Collections;

public abstract class Animatable : IAnimatable {

	public event AnimationCompletedHandler AnimationCompleted;    
    public event AnimationAddedHandler AnimationAdded;
	public event AnimationRemovedHandler AnimationRemoved;
	
	private bool _autoRemove = false;
		
	public bool AutoRemove {
		set {
			_autoRemove = value;
		}
		get {
			return _autoRemove;
		}
	}
	
	public Animatable(bool autoRemove) {
		this.AutoRemove = autoRemove;
	}
	
	public Animatable() {
		this.AutoRemove = true;
	}
	
	public abstract void Update ();
	
	public void FireAnimationCompleted() {
		if (AnimationCompleted!=null) {
			AnimationCompleted(this);
		}
	}
	
	public void FireAnimationAdded() {
		if (AnimationAdded!=null) {
			AnimationAdded(this);
		}
	}
	
	public void FireAnimationRemoved() {
		if (AnimationRemoved!=null) {
			AnimationRemoved(this);
		}
	}
	
	public void Complete() {
		FireAnimationCompleted();
	}
	
	public abstract void Initialize();
	public abstract void Dispose();
}
