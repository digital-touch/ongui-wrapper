using UnityEngine;
using UnityEditor;
using System.Collections;

public class UIScreenNavigator : UIWidget
{
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
	#if UNITY_EDITOR
	
		[MenuItem("UI/UIScreenNavigator")]
		public static GameObject createUIScreenNavigator ()
		{
				GameObject widget = new GameObject ("UIScreenNavigator");
		
				widget.AddComponent<UIWidgetTransform> ();				
				widget.AddComponent<UIScreenNavigator> ();
				widget.AddComponent<UIWidgetValidator> ();
				widget.AddComponent<UIWidgetRenderer> ();
				widget.AddComponent<UIWidgetInteraction> ();
				widget.AddComponent<FitToScreenUILayout> ();								
				widget.transform.parent = Selection.activeTransform;
				return widget;
		}
	
	#endif
	
		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
		public string defaultScreenID;
		public UIScreen activeScreen;
		public float transitionDuration = 0.2f;
		public float showTransitionDelay = 0.0f;
		public float hideTransitionDelay = 0.0f;
		public EaseDelegate showEasingFunction = Quad.EaseOut;
		public EaseDelegate hideEasingFunction = Quad.EaseOut;
		
		protected override void Awake ()
		{
				base.Awake ();
		
				for (int i = 0; i < transform.childCount; i++) {
						Transform child = transform.GetChild (i);
						UIScreen screen = child.GetComponent<UIScreen> ();
						UIWidgetTransform childTransform = child.GetComponent<UIWidgetTransform> ();
						UIWidgetInteraction childInteraction = child.GetComponent<UIWidgetInteraction> ();
						childTransform.x = widgetTransform.width;
						childTransform.isVisible = false;			
						childInteraction.isTouchable = false;			
				}		
		}	
	
		private Vector2Tween showTween;
	
		public UIScreen showNextScreen (string screenID, UIScreenTransitionType transitionType)
		{		
				if (activeScreen != null) {	
						hideScreen (activeScreen.id, transitionType);			
				}
		
				return showScreen (screenID, transitionType);
		}
	
		public UIScreen showScreen (string screenID, UIScreenTransitionType transitionType)
		{		
				UIScreen screen = activeScreen = getScreenByID (screenID);		
				UIWidgetTransform screenTransform = screen.GetComponent<UIWidgetTransform> ();
				
				if (transitionType == UIScreenTransitionType.RIGHT_TO_LEFT) {
						screenTransform.x = widgetTransform.width;		 
				} else {
						screenTransform.x = -widgetTransform.width; 
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
	
		void OnShowAnimationCompleted (Tween tween)
		{
				destroyShowTween ();
				
				UIScreen screen = tween.GetComponent<UIScreen> ();
				UIWidgetInteraction screenInteraction = tween.GetComponent<UIWidgetInteraction> ();
				screenInteraction.isTouchable = true;				
				screen.FireShowTransitionComplete (screen);										
		}
	
		private Vector2Tween hideTween;
	
		public UIScreen hideScreen (string screenID, UIScreenTransitionType transitionType)
		{
				UIScreen screen = getScreenByID (screenID);
				UIWidgetTransform screenTransform = screen.GetComponent<UIWidgetTransform> ();
		
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
	
		void OnHideAnimationCompleted (Tween tween)
		{		
				destroyHideTween ();
				
				UIScreen screen = tween.GetComponent<UIScreen> ();
				UIWidgetInteraction screenInteraction = tween.GetComponent<UIWidgetInteraction> ();
				UIWidgetTransform screenTransform = tween.GetComponent<UIWidgetTransform> ();
		
				screenTransform.isVisible = false; 
				screenInteraction.isTouchable = false; 
		
					
				screen.FireHideTransitionComplete (screen);
				
		}
	
	
		public UIScreen getScreenByID (string screenID)
		{
				return (UIScreen)widgetTransform.getChildById (screenID);
		}	
}

public enum UIScreenTransitionType
{
		LEFT_TO_RIGHT,
		RIGHT_TO_LEFT
}