using UnityEngine;
using System.Collections;

public class TouchDebugger : MonoBehaviour
{
		UIGameObject target;
			
		void Awake ()
		{
				if (target == null) {
						target = gameObject.GetComponent<UIGameObject> ();
				}		
				
				target.TouchBeganEvent += OnTouchBegan;
				target.TouchEndedEvent += OnTouchEnded;
		}
	
		protected virtual void OnTouchBegan (UIGameObject target, UITouch touch)
		{
				
		}
	
		protected virtual void OnTouchEnded (UIGameObject target, UITouch touch)
		{
				
		}
	
		void OnDestroy ()
		{
				if (target == null) {
						return;
				}		
				target.TouchBeganEvent -= OnTouchBegan;
				target.TouchEndedEvent -= OnTouchEnded;
		}
	
}
