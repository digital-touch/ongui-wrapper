using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(UIWidget), true)]
public class UIWidgetEditor : Editor
{

		public override void OnInspectorGUI ()
		{				
				drawUIWidgetInspector ();
				
				if (GUI.changed) {
						EditorUtility.SetDirty (target);
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
										EditorGUILayout.LabelField ("root:", parentWidget.root.ToString ());
								}
						}
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
