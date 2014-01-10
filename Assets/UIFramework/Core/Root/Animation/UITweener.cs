using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class UITweener
{

		private static List<Tween> tweens = new List<Tween> ();
	
		private static float elapsedTime = 0;
                
		public static void Add (Tween tween)
		{
				tweens.Add (tween);				
				tween.CompletedEvent += OnAutoRemove;				           
		}
		
		static void OnAutoRemove (Tween tween)
		{
				tween.CompletedEvent -= OnAutoRemove;
				Remove (tween);				
		}
        
		public static bool Contains (Tween tween)
		{
				return tweens.Contains (tween);
		}
        
		public static void Remove (Tween tween)
		{            
				tweens.Remove (tween);				
		}
        
		public static void Purge ()
		{
				while (tweens.Count > 0) {
						Tween tween = tweens [0];			
						tweens.Remove (tween);						
				}
		}                       
    	
		public static void validate ()
		{                           
				elapsedTime += Time.fixedDeltaTime;            
            
				for (int i=0; i<tweens.Count; ++i) {
						Tween tween = tweens [i];                  
						tween.Update ();                                    
				}                        
		}
}
