using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(UIWidgetTransform))]
[System.Serializable]
public class UIWidgetInteraction : MonoBehaviour
{

		protected UIWidgetTransform widgetTransform;
		protected UIWidget widget;
		
		[SerializeField]
		public bool
				isTouchable = true;
	
		protected virtual void Awake ()
		{
				widget = GetComponent<UIWidget> ();
				widgetTransform = GetComponent<UIWidgetTransform> ();
		}
		
		protected virtual void Start ()
		{
		
		}
		
		protected virtual void OnDestroy ()
		{
		
		}
	
		
		Rect tempRect = new Rect ();
		
		public virtual bool HitTest (UITouch touch)
		{				
				Vector2 global = widgetTransform.globalToLocal (touch.position);
				tempRect.Set (widgetTransform.x, widgetTransform.y, widgetTransform.width, widgetTransform.height);
				bool contains = tempRect.Contains (global);
				return contains;
		}
		
		public Action<UIWidget, UITouch> TouchBeganEvent;
		public Action<UIWidget, UITouch> TouchMovedEvent;
		public Action<UIWidget, UITouch> TouchEndedEvent;
		public Action<UIWidget, UITouch> TouchCancelledEvent;
			
		public virtual void TouchBegan (UITouch touch)
		{						
				for (int i = 0; i < transform.childCount; i++) {
						Transform child = transform.GetChild (i);
						UIWidgetInteraction childInteraction = child.GetComponent<UIWidgetInteraction> ();
						if (childInteraction == null) {
								continue;
						}			
						if (!childInteraction.isTouchable) {
								continue;
						}
						if (!childInteraction.HitTest (touch)) {
								continue;
						}
				
						childInteraction.TouchBegan (touch);
				}
				
				if (TouchBeganEvent != null) {
						TouchBeganEvent (widget, touch);
				}
				
		} 
		
		public virtual void TouchMoved (UITouch touch)
		{
				for (int i = 0; i < transform.childCount; i++) {
						Transform child = transform.GetChild (i);
						UIWidgetInteraction childInteraction = child.GetComponent<UIWidgetInteraction> ();
						if (childInteraction == null) {
								continue;
						}	
						if (!childInteraction.isTouchable) {
								continue;
						}
						if (!childInteraction.HitTest (touch)) {
								continue;
						}
						childInteraction.TouchMoved (touch);
				}
				if (TouchMovedEvent != null) {
						TouchMovedEvent (widget, touch);
				}
		} 
	
		public virtual void TouchEnded (UITouch touch)
		{
				for (int i = 0; i < transform.childCount; i++) {
						Transform child = transform.GetChild (i);
						UIWidgetInteraction childInteraction = child.GetComponent<UIWidgetInteraction> ();
						if (childInteraction == null) {
								continue;
						}	
						if (!childInteraction.isTouchable) {
								continue;
						}
						if (!childInteraction.HitTest (touch)) {
								continue;
						}
						childInteraction.TouchEnded (touch);
				}
				if (TouchEndedEvent != null) {
						TouchEndedEvent (widget, touch);
				}
		} 
	
		public virtual void TouchCancelled (UITouch touch)
		{
				for (int i = 0; i < transform.childCount; i++) {
						Transform child = transform.GetChild (i);
						UIWidgetInteraction childInteraction = child.GetComponent<UIWidgetInteraction> ();
						if (childInteraction == null) {
								continue;
						}	
						if (!childInteraction.isTouchable) {
								continue;
						}
						if (!childInteraction.HitTest (touch)) {
								continue;
						}
						childInteraction.TouchCancelled (touch);
				}
				if (TouchCancelledEvent != null) {
						TouchCancelledEvent (widget, touch);
				}
		} 
}
