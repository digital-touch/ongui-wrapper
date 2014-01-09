using UnityEngine;
using System.Collections;

public class UIButtonInteraction : UIWidgetInteraction
{
		bool _isDown = false;

		public bool isDown {
				get {
						return _isDown;
				}
				set {
						if (_isDown == value) {
								return;
						}
						_isDown = value;
			
						UIInvalidator.invalidate (widget, UIButton.SKIN_FLAG);			
				}
		}
	
		protected override void Awake ()
		{
				base.Awake ();
				TouchBeganEvent += OnTouchBegan;			
		}		
		
		protected override void OnDestroy ()
		{
				widget.root.GetComponent<UIWidgetInteraction> ().TouchEndedEvent -= OnTouchEnded;
				base.OnDestroy ();
									
		}

		void OnTouchBegan (UIWidget widget, UITouch touch)
		{						
				if (isDown) {
						return;
				}
				isDown = true;
				
				widget.root.GetComponent<UIWidgetInteraction> ().TouchEndedEvent += OnTouchEnded;
		} 
	
		void OnTouchEnded (UIWidget widget, UITouch touch)
		{
		
				if (!isDown) {
						return;
				}
				isDown = false;
				widget.root.GetComponent<UIWidgetInteraction> ().TouchEndedEvent -= OnTouchEnded;
		
		}
}
