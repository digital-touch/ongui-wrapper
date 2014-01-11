using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class UIWidgetRenderer : MonoBehaviour
{
		protected UIWidget widget;
		protected UIWidget widgetTransform;
		
		protected virtual void Awake ()
		{
				widget = GetComponent<UIWidget> ();
				widgetTransform = GetComponent<UIWidget> ();
		}
		
		
	
		protected virtual void OnDestroy ()
		{
				widget = null;
				widgetTransform = null;
		}
							
		public virtual void Draw (UIWidget parentWidget)
		{
				
				GUI.BeginGroup (widgetTransform.screenBounds);
				
				DrawChildren (parentWidget);
				
				GUI.EndGroup ();
		}

		protected  void DrawChildren (UIWidget parentWidget)
		{
				for (int i = 0; i < transform.childCount; i++) {
						DrawChild (i, parentWidget);
				}
		}
		
		protected  void DrawChild (int i, UIWidget parentWidgetTransform)
		{
				Transform child = transform.GetChild (i);
		
				UIWidgetRenderer widgetRenderer = child.GetComponent<UIWidgetRenderer> ();
		
				if (widgetRenderer == null) {
						return;
				}						
		
				UIWidget childWidgetTransform = widgetRenderer.GetComponent<UIWidget> ();
		
				if (!childWidgetTransform.isVisible) {
						return;
				}												
		
				if (childWidgetTransform.isInvisible) {
						return;
				}
		
				if (!child.gameObject.activeSelf) {					
						return;
				}
		
				Color old = GUI.color;
		
				Color newColor = GUI.color;// * widgetRenderer.tint;
				newColor.a = GUI.color.a * childWidgetTransform.alpha * parentWidgetTransform.alpha;
				GUI.color = newColor;
		
				if (childWidgetTransform.rotation != 0f || (childWidgetTransform.scale.x != 1 && childWidgetTransform.scale.y != 1)) {
						Matrix4x4 matrix = GUI.matrix;						
			
						GUIUtility.RotateAroundPivot (childWidgetTransform.rotation, childWidgetTransform.rotationPivotPoint);
						GUIUtility.ScaleAroundPivot (childWidgetTransform.scale, childWidgetTransform.scalePivotPoint);
			
						widgetRenderer.Draw (widgetTransform);
			
						GUI.matrix = matrix;
				} else {
						widgetRenderer.Draw (widgetTransform);
				}
		
				GUI.color = old;
		}
	
}
