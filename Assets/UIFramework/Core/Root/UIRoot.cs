using UnityEngine;
using UnityEditor;
using System.Collections;
using TouchScript;
using TouchScript.InputSources;
using TouchScript.Events;

[ExecuteInEditMode]
public class UIRoot : UIWidget
{
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public static readonly string ROOT_ID = "root";
		
		public UIRoot ():base()
		{
				id = ROOT_ID;
		}
		
		public override UIRoot root {		
				get {
						return this;
				}	
				set {						
				}
		}
	
	
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
	#if UNITY_EDITOR
	
		[MenuItem("UI/UIRoot")]
		
		#endif
	public static GameObject createUIRoot ()
		{
				GameObject root = new GameObject ("UIRoot");
				
	
				root.AddComponent<UIRoot> ();
	
				root.AddComponent<FitToScreenUILayout> ();
				root.AddComponent<TouchManager> ();
				root.AddComponent<MouseInput> ();
				root.AddComponent<UIRootEventHandler> (); 
				
				
				return root;
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////			
		
		
		TouchManager touchManager;
	
		protected override void Awake ()
		{
		
				base.Awake ();
		
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
	
		///////////////////////////////////////////////////////////////////////////////////////////////////			
}
