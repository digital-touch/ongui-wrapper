using UnityEngine;
using System.Collections;
using System;
using TouchScript;
using TouchScript.InputSources;
using TouchScript.Events;

[ExecuteInEditMode]
public class UIRoot : UIGameObject
{

		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		#if UNITY_EDITOR
	
		[UnityEditor.MenuItem ("UI/UIRoot")]
		public static GameObject CreateUIRoot ()
		{
				GameObject gameObject = new GameObject ("GameObject");
				gameObject.name = "UIRoot";
		
				UIRoot uIRoot = gameObject.AddComponent<UIRoot> ();
								
				uIRoot.width = Screen.width;
				uIRoot.height = Screen.height;						
   
				gameObject.AddComponent<TouchManager> ();
				gameObject.AddComponent<MouseInput> ();
		
				gameObject.AddComponent<FitToScreenUILayout> ();
		
				return gameObject;
		}
		#endif	
    
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		override public UIRoot root {
				get {
						return this;
				}				
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
		public Action<UIGameObject> ChildAddedEvent;
	
		public void FireChildAddedEvent (UIGameObject child)
		{
				if (ChildAddedEvent != null) {
						ChildAddedEvent (child);
				}				
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////

		public Action<UIGameObject> ChildRemovedEvent;
	
		public void FireChildRemovedEvent (UIGameObject child)
		{
				if (ChildRemovedEvent != null) {
						ChildRemovedEvent (child);
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		override protected void Update ()
		{
				UITweener.Advance ();
				if (Screen.width != width || Screen.height != height) {
						updateLayout ();
				}
				base.Update ();
		}		
		
		///////////////////////////////////////////////////////////////////////////////////////////////////

		protected virtual void OnGUI ()
		{
				draw (this);
		}
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		protected override void Awake ()
		{
				base.Awake ();
				initializeTouchManager ();
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////

		protected override void OnDestroy ()
		{
				base.OnDestroy ();
				disposeTouchManager ();
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		TouchManager touchManager;
	
		void initializeTouchManager ()
		{
				touchManager = TouchManager.Instance;
				if (touchManager == null) {
						return;
				}	
				touchManager.TouchesBegan += OnTouchesBegan;
				touchManager.TouchesMoved += OnTouchesMoved;
				touchManager.TouchesEnded += OnTouchesEnded;
				touchManager.TouchesCancelled += OnTouchesCancelled;		
		}
		
		void disposeTouchManager ()
		{
		
				if (touchManager == null) {
						return;
				}
		
				touchManager.TouchesBegan -= OnTouchesBegan;
				touchManager.TouchesMoved -= OnTouchesMoved;
				touchManager.TouchesEnded -= OnTouchesEnded;
				touchManager.TouchesCancelled -= OnTouchesCancelled;
		
				touchManager = null;
		
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
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
	
		///////////////////////////////////////////////////////////////////////////////////////////////////		
}
