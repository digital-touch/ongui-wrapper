using UnityEngine;
using System.Collections;

public class UIButtonValidator : UIWidgetValidator
{
		///////////////////////////////////////////////////////////////////////////////////////////////////	
		
		protected UIStackLayout layout;
		protected UIButtonInteraction buttonInteraction;
    
		protected override void Awake ()
		{
				base.Awake ();
				buttonInteraction = GetComponent<UIButtonInteraction> ();
				layout = GetComponent<UIStackLayout> ();
				
		}
	
		protected override void OnDestroy ()
		{
				base.OnDestroy ();
				layout = null;
				buttonInteraction = null;
		}    
    
		///////////////////////////////////////////////////////////////////////////////////////////////////	
    
		public override void Validate ()
		{
				if (!gameObject.activeSelf) {					
						return;
				}
		
				base.Validate ();
				
				bool isSkinDirty = UIInvalidator.isInvalid (widget, UIButton.SKIN_FLAG);
				
				if (isSkinDirty) {
						validateSkinIndex ();
						
				}
		}
		
		void validateSkinIndex ()
		{
				if (buttonInteraction.isDown) {
						//Debug.Log ("Skin 0");
						layout.selectedIndex = 1;	
				} else {
						//Debug.Log ("Skin 1");
						layout.selectedIndex = 0;
				}			
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////	
}