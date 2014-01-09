using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(UIWidgetTransform))]
public class UIWidgetTransformEditor : Editor
{
	
		
	
		public override void OnInspectorGUI ()
		{								
				drawUIWidgetTransformInspector ();
				
				if (GUI.changed) {
						EditorUtility.SetDirty (target);
				}				
		}
		
		protected bool transformFoldout = true;
		protected bool boundsFoldout = true;
		protected bool colorFoldout = false;
		protected bool rotationFoldout = false;
		protected bool scaleFoldout = false;
	
		void drawUIWidgetTransformInspector ()
		{		
				
				UIWidgetTransform widgetTransform = (UIWidgetTransform)target;		
				// transform
				transformFoldout = EditorGUILayout.Foldout (transformFoldout, "Transform");
		
				if (transformFoldout) {
		
						widgetTransform.isVisible = EditorGUILayout.Toggle ("visible", widgetTransform.isVisible);
						//Debug.Log ("widgetTransform.isVisible:" + widgetTransform.isVisible);
						widgetTransform.alpha = EditorGUILayout.Slider ("alpha", widgetTransform.alpha, 0f, 1f);
						widgetTransform.tint = EditorGUILayout.ColorField ("tint", widgetTransform.tint);
				}
			
				// bounds
				boundsFoldout = EditorGUILayout.Foldout (boundsFoldout, "Position");
				
				if (boundsFoldout) {
						widgetTransform.x = EditorGUILayout.IntField ("x", widgetTransform.x);
						widgetTransform.y = EditorGUILayout.IntField ("y", widgetTransform.y);
						widgetTransform.width = EditorGUILayout.IntField ("width", widgetTransform.width);
						widgetTransform.height = EditorGUILayout.IntField ("height", widgetTransform.height);
				}
			
				// rotation
			
				rotationFoldout = EditorGUILayout.Foldout (rotationFoldout, "Rotation");
				if (rotationFoldout) {
						widgetTransform.rotation = EditorGUILayout.Slider ("angle", widgetTransform.rotation, 0, 360);						
						widgetTransform.rotationPivotPoint = EditorGUILayout.Vector2Field ("pivot", widgetTransform.rotationPivotPoint);
						
				}
			
				// scale
			
				scaleFoldout = EditorGUILayout.Foldout (scaleFoldout, "Scale");
				if (scaleFoldout) {
				
						widgetTransform.scale = EditorGUILayout.Vector2Field ("value", widgetTransform.scale);
						widgetTransform.scalePivotPoint = EditorGUILayout.Vector2Field ("pivot", widgetTransform.scalePivotPoint);
						 
				}
		
		}
}
