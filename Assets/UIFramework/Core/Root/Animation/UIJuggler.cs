using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIJuggler : MonoBehaviour
{

		private List<IAnimatable> animatables = new List<IAnimatable> ();
	
		private float elapsedTime = 0;
                
		public void Add (IAnimatable animatable)
		{
				animatables.Add (animatable);
				animatable.Initialize ();		
				if (animatable.AutoRemove) {
						animatable.AnimationCompleted += OnAutoRemove;
				}           
		}
		
		void OnAutoRemove (IAnimatable animatable)
		{
				animatable.AnimationCompleted -= OnAutoRemove;
				if (animatable.AutoRemove) {
						Remove (animatable);				
				}				
		}
        
		public bool Contains (IAnimatable animatable)
		{
				return animatables.Contains (animatable);
		}
        
		public void Remove (IAnimatable animatable)
		{            
				animatables.Remove (animatable);
				animatable.Dispose ();         	   
		}
        
		public void Purge ()
		{
				while (animatables.Count > 0) {
						IAnimatable animatable = animatables [0];			
						animatables.Remove (animatable);
						animatable.Dispose ();
				}
		}                       
    	
		void FixedUpdate ()
		{                           
				elapsedTime += Time.fixedDeltaTime;            
            
				for (int i=0; i<animatables.Count; ++i) {
						IAnimatable animatable = animatables [i];                  
						animatable.Update ();                                    
				}                        
		}
}
