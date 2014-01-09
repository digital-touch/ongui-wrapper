using UnityEngine;
using System.Collections;

public delegate void AnimationCompletedHandler(IAnimatable animatable);
public delegate void AnimationAddedHandler(IAnimatable animatable);
public delegate void AnimationRemovedHandler(IAnimatable animatable);

public interface IAnimatable {
		
	event AnimationCompletedHandler AnimationCompleted;    
    event AnimationAddedHandler AnimationAdded;
	event AnimationRemovedHandler AnimationRemoved;
	
	void Update ();
	
	bool AutoRemove{ get; }
	
	void Initialize();
	void Dispose();
		
}
