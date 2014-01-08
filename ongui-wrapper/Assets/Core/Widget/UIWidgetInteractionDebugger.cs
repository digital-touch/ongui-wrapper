using UnityEngine;
using System.Collections;

public class UIWidgetInteractionDebugger : MonoBehaviour
{
		UIWidgetInteraction interaction;
			
		void Awake ()
		{
				interaction = GetComponent<UIWidgetInteraction> ();
				interaction.TouchBeganEvent += OnTouchesBegan;
				interaction.TouchMovedEvent += OnTouchesMoved;
				interaction.TouchEndedEvent += OnTouchesEnded;
				interaction.TouchCancelledEvent += OnTouchesCancelled;
		}
	
		void OnDestroy ()
		{
				if (interaction == null) {
						return;
				}
				interaction.TouchBeganEvent -= OnTouchesBegan;
				interaction.TouchMovedEvent -= OnTouchesMoved;
				interaction.TouchEndedEvent -= OnTouchesEnded;
				interaction.TouchCancelledEvent -= OnTouchesCancelled;
		}
		public bool isTouched;
	
		public Vector2 beganPosition;
		public Vector2 movedPosition;
		public Vector2 endedPosition;
	
		void OnTouchesBegan (UIWidget widget, UITouch touch)
		{
				isTouched = true;
				beganPosition = touch.position;
		}		
	
		void OnTouchesMoved (UIWidget widget, UITouch touch)
		{
				movedPosition = touch.position;
		}		
	
		void OnTouchesEnded (UIWidget widget, UITouch touch)
		{
				isTouched = false;
				endedPosition = touch.position;
		}		
	
		void OnTouchesCancelled (UIWidget widget, UITouch touch)
		{
				endedPosition = touch.position;
		}	
}
