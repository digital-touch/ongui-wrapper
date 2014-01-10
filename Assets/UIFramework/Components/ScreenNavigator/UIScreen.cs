using UnityEngine;
using UnityEditor;
using System.Collections;
using System;

public class UIScreen : UIWidget
{
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
	#if UNITY_EDITOR
	
		[MenuItem("UI/UIScreen")]
		public static GameObject createUIScreen ()
		{
				GameObject widget = new GameObject ("UIScreen");
		
				widget.AddComponent<UIWidgetTransform> ();				
				widget.AddComponent<UIScreen> ();
				widget.AddComponent<UIWidgetValidator> ();
				widget.AddComponent<UIWidgetRenderer> ();
				widget.AddComponent<UIWidgetInteraction> ();
				widget.AddComponent<FitToScreenUILayout> ();								
				widget.transform.parent = Selection.activeTransform;
				return widget;
		}
	
	#endif
	
		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public float scale = 1.0f;	
	
		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
		UIScreenNavigator _navigator;
	
		public UIScreenNavigator navigator {				
				get {
						return (UIScreenNavigator)parent;
				}
		}
	
		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
		public Action<UIScreen> ShowTransitionStartEvent;
		public Action<UIScreen> ShowTransitionCompleteEvent;
	
		public virtual void FireShowTransitionStart (UIScreen screen)
		{
				if (ShowTransitionStartEvent != null) {
						ShowTransitionStartEvent (screen);
				}
		}
	
		public virtual void FireShowTransitionComplete (UIScreen screen)
		{
				if (ShowTransitionCompleteEvent != null) {
						ShowTransitionCompleteEvent (screen);
				}
		}	

		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
		public Action<UIScreen> HideTransitionStartEvent;
		public Action<UIScreen> HideTransitionCompleteEvent;
	
		public virtual void FireHideTransitionStart (UIScreen screen)
		{
				if (HideTransitionStartEvent != null) {
						HideTransitionStartEvent (screen);
				}
		}
	
		public virtual void FireHideTransitionComplete (UIScreen screen)
		{
				if (HideTransitionCompleteEvent != null) {
						HideTransitionCompleteEvent (screen);
				}
		}	

		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}
