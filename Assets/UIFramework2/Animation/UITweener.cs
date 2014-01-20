using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class UITweener
{
		private static List<UITween> tweens = new List<UITween> ();
	
		private static float elapsedTime = 0;
                
		public static void Add (UITween tween)
		{
				tweens.Add (tween);				
				tween.CompletedEvent += OnAutoRemove;				           
		}
		
		static void OnAutoRemove (UITween tween)
		{
				tween.CompletedEvent -= OnAutoRemove;
				Remove (tween);				
		}
        
		public static bool Contains (UITween tween)
		{
				return tweens.Contains (tween);
		}
        
		public static void Remove (UITween tween)
		{            
				tweens.Remove (tween);				
		}
        
		public static void Purge ()
		{
				while (tweens.Count > 0) {
						UITween tween = tweens [0];			
						tweens.Remove (tween);						
				}
		}                       
    	
		public static void Advance ()
		{                           
				elapsedTime += Time.fixedDeltaTime;            
            
				for (int i=0; i<tweens.Count; ++i) {
						UITween tween = tweens [i];                  
						tween.Advance ();                                    
				}                        
		}
}
