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
	
		override public UIRoot root {
				get {
						return this;
				}				
		}				
		
		///////////////////////////////////////////////////////////////////////////////////////////////////	
		
		List<UIGameObject> invalidatedObjects = new List<UIGameObject> (); 						
		
		public void invalidateTarget (UIGameObject target)
		{				
				if (invalidatedObjects.IndexOf (target) == -1) {
						invalidatedObjects.Add (target);
				}
				
#if UNITY_EDITOR	
				if (invalidatedObjects.Count > 0) {
						UnityEditor.EditorUtility.SetDirty (this);	
				}
#endif
		}				
	
		protected virtual void Update ()
		{
				if (width != Screen.width || height != Screen.height) {
						invalidate ();
				}			
		
				if (UITweener.numTweens > 0) {
						UITweener.Advance ();
						#if UNITY_EDITOR
						//UnityEditor.EditorUtility.SetDirty (gameObject);
						#endif
				}				
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////

		protected virtual void OnGUI ()
		{
		
				
				while (invalidatedObjects.Count > 0) {
						UIGameObject target = invalidatedObjects [0];
						invalidatedObjects.RemoveAt (0);
						
						target.validate ();
						
				}
		
				draw (this);
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public override void Awake ()
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
				if (!isTouchable) {
						return;
				}
				foreach (TouchPoint touchPoint in e.TouchPoints) {
						UITouch touch = TouchScriptUIUtility.toUITouch (touchPoint);
						TouchMoved (touch);
				}
		}		
	
		void OnTouchesEnded (object sender, TouchEventArgs e)
		{
				if (!isTouchable) {
						return;
				}
				foreach (TouchPoint touchPoint in e.TouchPoints) {
						UITouch touch = TouchScriptUIUtility.toUITouch (touchPoint);
						TouchEnded (touch);
				}
		}		
	
		void OnTouchesCancelled (object sender, TouchEventArgs e)
		{
				if (!isTouchable) {
						return;
				}
				foreach (TouchPoint touchPoint in e.TouchPoints) {
						UITouch touch = TouchScriptUIUtility.toUITouch (touchPoint);
						TouchCancelled (touch);
				}
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////		
}
