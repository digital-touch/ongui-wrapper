using UnityEngine;
using System.Collections;

public class TouchDebugger : MonoBehaviour
{
		public UIGameObject target;
			
		void Awake ()
		{
				if (target == null) {
						return;
				}		
				target.TouchBeganEvent += OnTouchBegan;
				target.TouchEndedEvent += OnTouchEnded;
		}
	
		void OnTouchBegan (UIGameObject target, UITouch touch)
		{
				Debug.Log ("OnTouchBegan");
		}
	
		void OnTouchEnded (UIGameObject target, UITouch touch)
		{
				Debug.Log ("OnTouchEnded");
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
