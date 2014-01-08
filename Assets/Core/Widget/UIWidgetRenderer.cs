using UnityEngine;
using System.Collections;

[RequireComponent(typeof(UIWidget))]
[ExecuteInEditMode]
public class UIWidgetRenderer : MonoBehaviour
{
		protected UIWidget widget;
		protected UIWidgetTransform widgetTransform;
		
		protected virtual void Awake ()
		{
				widget = GetComponent<UIWidget> ();
				widgetTransform = GetComponent<UIWidgetTransform> ();
		}
		
		
	
		protected virtual void OnDestroy ()
		{
				widget = null;
				widgetTransform = null;
		}
							
		public virtual void Draw (UIWidgetTransform parentWidgetTransform)
		{
				
				GUI.BeginGroup (widgetTransform.screenBounds);
				
				for (int i = 0; i < transform.childCount; i++) {
						Transform child = transform.GetChild (i);
			
						UIWidgetRenderer widgetRenderer = child.GetComponent<UIWidgetRenderer> ();
						
						if (widgetRenderer == null) {
								continue;
						}						
						
						UIWidgetTransform childWidgetTransform = widgetRenderer.GetComponent<UIWidgetTransform> ();
			
						if (!childWidgetTransform.isVisible) {
								continue;
						}												
						
						if (childWidgetTransform.isInvisible) {
								continue;
						}
						
						if (!child.gameObject.activeSelf) {					
								continue;
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
				GUI.EndGroup ();
				
			
		}
		
		
	
}
