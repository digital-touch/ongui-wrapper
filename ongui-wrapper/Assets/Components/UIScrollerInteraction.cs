using UnityEngine;
using System.Collections;

public class UIScrollerInteraction : UIWidgetInteraction
{
		Vector2 startPosition;
		Vector2 deltaPosititon;
		Vector2 lastPosition;

		protected override void Awake ()
		{
				base.Awake ();
				TouchBeganEvent += OnTouchBegan;
				TouchMovedEvent += OnTouchMoved;
				TouchEndedEvent += OnTouchEnded;
		}
		
		protected override void OnDestroy ()
		{
				TouchBeganEvent -= OnTouchBegan;
				TouchMovedEvent -= OnTouchMoved;
				TouchEndedEvent -= OnTouchEnded;
				base.OnDestroy ();
		}

		void OnTouchBegan (UIWidget target, UITouch touch)
		{
				lastPosition = touch.position;
				startPosition = touch.position;				

		}	
		
		void OnTouchMoved (UIWidget target, UITouch touch)
		{
				UIScroller scroller = (UIScroller)widget;
				deltaPosititon = lastPosition - touch.position;
				lastPosition = touch.position;
				scroller.scrollPositionX -= deltaPosititon.x;
				scroller.scrollPositionY -= deltaPosititon.y;

		}
		
		void OnTouchEnded (UIWidget target, UITouch touch)
		{
				ThrowScroll ();
		}
		
		bool isThrowing = false;
		
		void Update ()
		{
				if (isThrowing) {
						UIScroller scroller = (UIScroller)widget;
			
						scroller.scrollPositionX -= deltaPosititon.x / 8;
						scroller.scrollPositionY -= deltaPosititon.y / 8;
						deltaPosititon *= 0.95f;
						
						if (deltaPosititon.magnitude == 0) {
								isThrowing = false;
						}
				}
		}
		
		void ThrowScroll ()
		{		
				if ((deltaPosititon.magnitude > 0) && !isThrowing) {
						isThrowing = true;
						
				}
		}
}
