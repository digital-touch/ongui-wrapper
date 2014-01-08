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
