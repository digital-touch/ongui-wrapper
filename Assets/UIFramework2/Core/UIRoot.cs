using UnityEngine;
using System.Collections;
using System.Collections.Generic;
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
		
				UIRoot uiRoot = gameObject.AddComponent<UIRoot> ();
								
				uiRoot.width = Screen.width;
				uiRoot.height = Screen.height;						
   
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
	
		protected override void Update ()
		{
				if (width != Screen.width || height != Screen.height) {
						invalidate ();
				}				
				base.Update ();
				if (UITweener.numTweens > 0) {
						UITweener.Advance ();
						#if UNITY_EDITOR
						//UnityEditor.EditorUtility.SetDirty (gameObject);
						#endif
				}
				validate ();
		}
		
		List<UIGameObject> invalidatedObjects = new List<UIGameObject> (); 						
		
		public void invalidate (UIGameObject target)
		{				
				if (invalidatedObjects.IndexOf (target) == -1) {
						invalidatedObjects.Add (target);
				}
				if (invalidatedObjects.Count > 0) {
						#if UNITY_EDITOR	
						UnityEditor.EditorUtility.SetDirty (this);	
						#endif
				}
				//Debug.Log ("invalidate");
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
