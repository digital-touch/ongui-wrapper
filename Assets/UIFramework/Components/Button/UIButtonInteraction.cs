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
			
						UIInvalidator.invalidate (gameObject, UIButton.SKIN_FLAG);			
				}
		}
	
		protected override void Awake ()
		{
				base.Awake ();
				widget.AddedToRootEvent += OnAddedToRoot;
				widget.RemovedFromRootEvent += OnRemovedFromRoot;
		}
		
		protected override void OnDestroy ()
		{
				base.OnDestroy ();
				widget.AddedToRootEvent -= OnAddedToRoot;
				widget.RemovedFromRootEvent -= OnRemovedFromRoot;
		}
			
		void OnAddedToRoot (UIWidget widget)
		{
				TouchBeganEvent += OnTouchBegan;	
				this.widget.root.GetComponent<UIWidgetInteraction> ().TouchEndedEvent += OnTouchEnded;		
		}		
		
		void OnRemovedFromRoot (UIWidget widget)
		{
				TouchBeganEvent -= OnTouchBegan;	
				this.widget.root.GetComponent<UIWidgetInteraction> ().TouchEndedEvent -= OnTouchEnded;		
		}		
		
		

		void OnTouchBegan (UIWidget widget, UITouch touch)
		{						
				if (isDown) {
						return;
				}
				isDown = true;
				
				
		} 
	
		void OnTouchEnded (UIWidget widget, UITouch touch)
		{		
				if (!isDown) {
						return;
				}
				isDown = false;				
		
		}
}
