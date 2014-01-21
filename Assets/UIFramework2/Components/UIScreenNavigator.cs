using UnityEngine;

using System.Collections;

public class UIScreenNavigator : UIGameObject
{
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
	#if UNITY_EDITOR
	
		[UnityEditor.MenuItem("UI/UIScreenNavigator")]
		public static GameObject createUIScreenNavigator ()
		{
				GameObject widget = new GameObject ("UIScreenNavigator");
		
			
				widget.AddComponent<UIScreenNavigator> ();				
				widget.AddComponent<FitToScreenUILayout> ();								
				widget.transform.parent = UnityEditor.Selection.activeTransform;
				return widget;
		}
	
	#endif
	
		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
		public string defaultScreenID;
		public UIScreen activeScreen;
		public float transitionDuration = 2f;
		public float showTransitionDelay = 1.0f;
		public float hideTransitionDelay = 1.0f;
		public EaseDelegate showEasingFunction = Quad.EaseOut;
		public EaseDelegate hideEasingFunction = Quad.EaseOut;
		
		protected override void Awake ()
		{
				base.Awake ();
		
				for (int i = 0; i < transform.childCount; i++) {
						Transform child = transform.GetChild (i);						
						UIGameObject childWidget = child.GetComponent<UIGameObject> ();
						
						childWidget.x = width;
						childWidget.isVisible = false;			
						childWidget.isTouchable = false;			
				}		
		}	
	
		private Vector2Tween showTween;
	
		public UIScreen showNextScreen (string screenID, UIScreenTransitionType transitionType)
		{		
				if (activeScreen != null) {	
						hideScreen (activeScreen.name, transitionType);			
				}
		
				return showScreen (screenID, transitionType);
		}
	
		public UIScreen showScreen (string screenID, UIScreenTransitionType transitionType)
		{		
				UIScreen screen = activeScreen = getScreenByID (screenID);		
				UIGameObject screenTransform = screen.GetComponent<UIGameObject> ();
				
				if (transitionType == UIScreenTransitionType.RIGHT_TO_LEFT) {
						screenTransform.x = width;		 
				} else {
						screenTransform.x = -width; 
				}
		
				screenTransform.isVisible = true;		
		
				if (showTween != null) {			
						showTween.Stop ();						
						destroyShowTween ();
				}
				
				screen.FireShowTransitionStart (screen);		
		
				
				showTween = screen.gameObject.AddComponent<MoveTween> ();
				showTween.valueFrom = new Vector2 (screenTransform.x, screenTransform.y);
				showTween.valueTo = new Vector2 (0, screenTransform.y);
				showTween.duration = transitionDuration;
				showTween.delay = showTransitionDelay;
				showTween.easingFunction = showEasingFunction;					
				
				showTween.CompletedEvent += OnShowAnimationCompleted;
								
				showTween.Play ();
				return screen;
		}
		
		void destroyShowTween ()
		{
				showTween.CompletedEvent -= OnShowAnimationCompleted;			
				Destroy (showTween);
				showTween = null;
		}
	
		void OnShowAnimationCompleted (UITween tween)
		{
				destroyShowTween ();
				
				UIScreen screen = tween.GetComponent<UIScreen> ();
				
				screen.isTouchable = true;				
				screen.FireShowTransitionComplete (screen);										
		}
	
		private Vector2Tween hideTween;
	
		public UIScreen hideScreen (string screenID, UIScreenTransitionType transitionType)
		{
				UIScreen screen = getScreenByID (screenID);
				UIGameObject screenTransform = screen.GetComponent<UIGameObject> ();
		
				float xTo = 0;
				if (transitionType == UIScreenTransitionType.RIGHT_TO_LEFT) {
						xTo = -Screen.width;
				} else {
						xTo = Screen.width;
				}
		
				if (hideTween != null) {	
						destroyHideTween ();		
						hideTween.Stop ();
						destroyHideTween ();
				}
				
				screen.FireHideTransitionStart (screen);
				
				hideTween = screen.gameObject.AddComponent<MoveTween> ();
				hideTween.valueFrom = new Vector2 (screenTransform.x, screenTransform.y);
				hideTween.valueTo = new Vector2 (xTo, screenTransform.y);
				hideTween.duration = transitionDuration;
				hideTween.delay = hideTransitionDelay;
				hideTween.easingFunction = hideEasingFunction;					
			                 
				hideTween.CompletedEvent += OnHideAnimationCompleted;
			                 
				hideTween.Play ();
			                 

				return screen;
		}
		
		void destroyHideTween ()
		{
				hideTween.CompletedEvent -= OnHideAnimationCompleted;			
				Destroy (hideTween);
				hideTween = null;
		}
	
		void OnHideAnimationCompleted (UITween tween)
		{		
				destroyHideTween ();
				
				UIScreen screen = tween.GetComponent<UIScreen> ();
				
				
		
				screen.isVisible = false; 
				screen.isTouchable = false; 
		
					
				screen.FireHideTransitionComplete (screen);
				
		}
	
	
		public UIScreen getScreenByID (string screenID)
		{
				return (UIScreen)getChildById (screenID);
		}	
}

public enum UIScreenTransitionType
{
		LEFT_TO_RIGHT,
		RIGHT_TO_LEFT
}