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
						widgetInvalidatior.setDirty (UIButton.SKIN_FLAG);			
				}
		}
	
		protected UIWidgetInvalidator widgetInvalidatior;
	
		protected override void Awake ()
		{
				base.Awake ();
				widgetInvalidatior = GetComponent<UIWidgetInvalidator> ();
				TouchBeganEvent += OnTouchBegan;			
		}		
		
		protected override void OnDestroy ()
		{
				widget.root.GetComponent<UIWidgetInteraction> ().TouchEndedEvent -= OnTouchEnded;
				base.OnDestroy ();
				widgetInvalidatior = null;							
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
