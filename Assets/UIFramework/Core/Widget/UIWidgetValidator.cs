using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class UIWidgetValidator : UIWidgetBehaviour
{
		
		public virtual void Validate ()
		{		
				if (!gameObject.activeSelf) {					
						return;
				}	
		
				validateTransformParent ();
				ValidateSize ();
				//ValidateChildren ();				
		
				validateLayout ();
		}
		
		void validateLayout ()
		{
				UILayout[] widgetLayouts = GetComponents<UILayout> ();	
		
				for (int i = 0; i < widgetLayouts.Length; i++) {
						UILayout widgetLayout = widgetLayouts [i];
						widgetLayout.Layout ();						
				}
		}
					
		void ValidateSize ()
		{
				bool isPositionDirty = UIInvalidator.isInvalid (widget, UIWidget.POSITION_FLAG);
				bool isSizeDirty = UIInvalidator.isInvalid (widget, UIWidget.SIZE_FLAG);
				if (isPositionDirty || isSizeDirty) {
						widgetTransform.screenBounds.Set (widgetTransform.x, widgetTransform.y, widgetTransform.width, widgetTransform.height);
						
				}
		}
		
		
		Transform lastTransformParent;
	
		void validateTransformParent ()
		{
				if (lastTransformParent == transform.parent) {
						return;
				}
				if (lastTransformParent != null) {
						//Removed
				}
				lastTransformParent = transform.parent;
				if (lastTransformParent != null) {
						//Added					
				}				
		}
	
//		void ValidateChildren ()
//		{
//				for (int i = 0; i < transform.childCount; i++) {
//						Transform child = transform.GetChild (i);		
//			
//						UIWidgetValidator widgetValidator = child.GetComponent<UIWidgetValidator> ();
//						if (widgetValidator == null) {
//								continue;
//						}
//			
//						if (widgetValidator.gameObject.activeSelf) {
//								widgetValidator.Validate ();
//						}												
//				}
//		}
}
