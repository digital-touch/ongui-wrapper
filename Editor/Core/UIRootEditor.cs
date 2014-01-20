using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(UIRoot))]
public class UIRootEditor : Editor
{
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
		public override void OnInspectorGUI ()
		{				
				drawUIRootInspector ();
		
				if (GUI.changed) {
						EditorUtility.SetDirty (target);
				}
		}
	
		protected bool boundsFoldout = true;
	
		void drawUIRootTransformInspector ()
		{				
				UIWidget widgetTransform = (UIWidget)target;
		
				// bounds
				boundsFoldout = EditorGUILayout.Foldout (boundsFoldout, "Position");
		
				if (boundsFoldout) {
						EditorGUILayout.LabelField ("width", widgetTransform.width.ToString ());
						EditorGUILayout.LabelField ("height", widgetTransform.height.ToString ());
				}		
		}
	
		[SerializeField]
		bool
				childrenFoldout = false;
	
		string childrenFoldoutLabel;
	
		void drawUIRootInspector ()
		{		
				UIWidget widget = (UIWidget)target;
		
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
