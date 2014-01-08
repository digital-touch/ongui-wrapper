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
				base.Validate ();
				
				bool isSkinDirty = widgetInvalidator.isDirty (UIButton.SKIN_FLAG);
				
				if (isSkinDirty) {
						validateSkinIndex ();
						widgetInvalidator.clearDirty (UIButton.SKIN_FLAG);
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