using UnityEngine;
using System.Collections;

public class UIScrollerInteraction : UIWidgetInteraction
{
		Vector3 startPosition;
		Vector3 deltaPosititon;
		Vector3 lastPosition;

		Vector2 scrollPosition = Vector2.zero;

		protected override void Awake ()
		{
				TouchBeganEvent += OnTouchBegan;
				TouchMovedEvent += OnTouchMoved;
		}

		void OnTouchBegan (UIWidget target, UITouch touch)
		{
				lastPosition = Input.mousePosition;
				startPosition = Input.mousePosition;				

		}	
		
		void OnTouchMoved (UIWidget target, UITouch touch)
		{
				deltaPosititon = lastPosition - Input.mousePosition;
				lastPosition = Input.mousePosition;
				scrollPosition -= (Vector2)deltaPosititon;

		}
}
