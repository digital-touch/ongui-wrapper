using UnityEngine;
using System.Collections;
using TouchScript;
using TouchScript.Events;

[System.Serializable]
public class UIRootInteraction : UIWidgetInteraction
{
		TouchManager touchManager;
	
		protected override void Awake ()
		{
				base.Start ();
		}
		protected override void Start ()
		{
				
				base.Start ();
				
				touchManager = TouchManager.Instance;
				if (touchManager == null) {
						return;
				}	
				touchManager.TouchesBegan += OnTouchesBegan;
				touchManager.TouchesMoved += OnTouchesMoved;
				touchManager.TouchesEnded += OnTouchesEnded;
				touchManager.TouchesCancelled += OnTouchesCancelled;
		}
	
		protected override void OnDestroy ()
		{
				
				base.OnDestroy ();
		
				if (touchManager == null) {
						return;
				}
				
				touchManager.TouchesBegan -= OnTouchesBegan;
				touchManager.TouchesMoved -= OnTouchesMoved;
				touchManager.TouchesEnded -= OnTouchesEnded;
				touchManager.TouchesCancelled -= OnTouchesCancelled;
		
				touchManager = null;
						
		}
	
	
		void OnTouchesBegan (object sender, TouchEventArgs e)
		{
		
				if (!isTouchable) {
						return;
				}				
				foreach (TouchPoint touchPoint in e.TouchPoints) {
						UITouch touch = TouchScriptUIUtility.toUITouch (touchPoint);
						TouchBegan (touch);
				}
		}		
		
		void OnTouchesMoved (object sender, TouchEventArgs e)
		{
				foreach (TouchPoint touchPoint in e.TouchPoints) {
						UITouch touch = TouchScriptUIUtility.toUITouch (touchPoint);
						TouchMoved (touch);
				}
		}		
    
		void OnTouchesEnded (object sender, TouchEventArgs e)
		{
				foreach (TouchPoint touchPoint in e.TouchPoints) {
						UITouch touch = TouchScriptUIUtility.toUITouch (touchPoint);
						TouchEnded (touch);
				}
		}		
    
		void OnTouchesCancelled (object sender, TouchEventArgs e)
		{
				foreach (TouchPoint touchPoint in e.TouchPoints) {
						UITouch touch = TouchScriptUIUtility.toUITouch (touchPoint);
						TouchCancelled (touch);
				}
		}
}
