using UnityEngine;
using System.Collections;

public class UIScroller : UIGameObject
{
	
		public override void Awake ()
		{
				base.Awake ();
				TouchBeganEvent += OnTouchBegan;
		
				ChildAddedToRootEvent += OnAddedToRoot;		
				ChildRemovedFromRootEvent += OnRemovedFromRoot;
				if (root != null) {
						initializeRootTouchListeners ();
				} 
		}
	
		void OnAddedToRoot (UIGameObject child)
		{
				initializeRootTouchListeners ();
		}
				
		void initializeRootTouchListeners ()
		{
				root.TouchMovedEvent += OnTouchMoved;
				root.TouchEndedEvent += OnTouchEnded;
		}
		
		void disposeRootTouchListeners ()
		{
				root.TouchMovedEvent -= OnTouchMoved;
				root.TouchEndedEvent -= OnTouchEnded;
		}
		
		void OnRemovedFromRoot (UIGameObject child)
		{
				disposeRootTouchListeners ();
		}
	
		protected override void OnDestroy ()
		{
				if (root != null) {
						disposeRootTouchListeners ();
				}
				base.OnDestroy ();
		}
		
		public bool isScrolling = false;
		
		Vector2 startTouchPosition;
		Vector2 startScrollPosition;
		void OnTouchBegan (UIGameObject target, UITouch touch)
		{
				if (isScrolling) {
						return;
				}
				isScrolling = true;
				startTouchPosition = touch.position;				
				
				UILinearLayout layout = GetComponent<UILinearLayout> ();
		
				startScrollPosition = layout.scrollPosition;
		}
		
		void OnTouchMoved (UIGameObject target, UITouch touch)
		{
				if (!isScrolling) {
						return;
				}
				
				UILinearLayout layout = GetComponent<UILinearLayout> ();
		
				Vector2 delta = startTouchPosition - touch.position;
		
				layout.scrollPosition = startScrollPosition + delta;
		}
	
		void OnTouchEnded (UIGameObject target, UITouch touch)
		{
				if (!isScrolling) {
						return;
				}
				isScrolling = false;
				
		}
}
