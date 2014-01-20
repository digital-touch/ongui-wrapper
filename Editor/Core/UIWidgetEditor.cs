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
		
				UIWidget widget = (UIWidget)target;		
				// transform
				transformFoldout = EditorGUILayout.Foldout (transformFoldout, "Transform");
		
				if (transformFoldout) {
			
						widget.isVisible = EditorGUILayout.Toggle ("visible", widget.isVisible);
						widget.isTouchable = EditorGUILayout.Toggle ("Touchable", widget.isTouchable);
						widget.alpha = EditorGUILayout.Slider ("alpha", widget.alpha, 0f, 1f);
						widget.tint = EditorGUILayout.ColorField ("tint", widget.tint);
				}
		
				// bounds
				boundsFoldout = EditorGUILayout.Foldout (boundsFoldout, "Position");
		
				if (boundsFoldout) {
						widget.x = EditorGUILayout.IntField ("x", widget.x);
						widget.y = EditorGUILayout.IntField ("y", widget.y);
						widget.width = EditorGUILayout.IntField ("width", widget.width);
						widget.height = EditorGUILayout.IntField ("height", widget.height);
				}
		
				// rotation
		
				rotationFoldout = EditorGUILayout.Foldout (rotationFoldout, "Rotation");
				if (rotationFoldout) {
						widget.rotation = EditorGUILayout.Slider ("angle", widget.rotation, 0, 360);						
						widget.rotationPivotPoint = EditorGUILayout.Vector2Field ("pivot", widget.rotationPivotPoint);
			
				}
		
				// scale
		
				scaleFoldout = EditorGUILayout.Foldout (scaleFoldout, "Scale");
				if (scaleFoldout) {
			
						widget.scale = EditorGUILayout.Vector2Field ("value", widget.scale);
						widget.scalePivotPoint = EditorGUILayout.Vector2Field ("pivot", widget.scalePivotPoint);
			
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
