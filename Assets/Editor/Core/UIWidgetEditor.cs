using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(UIWidget), true)]
public class UIWidgetEditor : Editor
{

		public override void OnInspectorGUI ()
		{				
				drawUIWidgetTransformInspector ();
				drawUIWidgetInspector ();
				
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
		
				UIWidget widgetTransform = (UIWidget)target;		
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
	
		protected bool
				childrenFoldout = false;
	
		protected string childrenFoldoutLabel;
	
		protected bool widgetFoldout = true;
	
	
			
			
		void drawUIWidgetInspector ()
		{		
				UIWidget widget = (UIWidget)target;
				
			
				// widget			
				widgetFoldout = EditorGUILayout.Foldout (widgetFoldout, "Widget");
			
				if (widgetFoldout) {
		
		
						widget.id = EditorGUILayout.TextField ("id", widget.id);
						widget.includeInLayout = EditorGUILayout.Toggle ("includeInLayout", widget.includeInLayout);
				
						// parent
				
						if (widget.transform.parent != null) {
								UIWidget parentWidget = widget.transform.parent.GetComponent<UIWidget> ();
								if (parentWidget != null) {
										EditorGUILayout.LabelField ("parent Widget:", parentWidget.ToString ());
										if (parentWidget.root != null) {
												EditorGUILayout.LabelField ("root:", parentWidget.root.ToString ());
										}
								}
						}
						
						EditorGUILayout.BeginHorizontal ();
						GUILayout.Label ("Depth", EditorStyles.boldLabel);
						if (GUILayout.Button ("Back")) {
								widget.toBack ();
						}
						if (GUILayout.Button ("Front")) {
								widget.toFront ();
						}
						EditorGUILayout.EndHorizontal ();
				}
				// children
		
				childrenFoldoutLabel = "children (" + widget.transform.childCount + ")";						
				childrenFoldout = EditorGUILayout.Foldout (childrenFoldout, childrenFoldoutLabel);
		
				if (childrenFoldout) {
			
						EditorGUI.indentLevel++;
			
			
						for (int i = 0; i < widget.transform.childCount; i++) {
								Transform child = widget.transform.GetChild (i);
								UIWidget childWidget = child.GetComponent<UIWidget> ();
								if (childWidget == null) {
										continue;
								}
								EditorGUILayout.LabelField (childWidget.ToString (), EditorStyles.label);
																								
			
								EditorGUI.indentLevel--;
						}
				
				}
		}
}
