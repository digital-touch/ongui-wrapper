using UnityEngine;
using UnityEditor;
using System.Collections;
	
[CustomEditor(typeof(AnchorUILayoutData))]
public class UIAnchorLayoutDataEditor : Editor
{
		
		public override void OnInspectorGUI ()
		{		
						
				drawUIAnchorLayoutDataGUI ();
			
				if (GUI.changed) {
						EditorUtility.SetDirty (target);
				}
		}

		void drawUIAnchorLayoutDataGUI ()
		{
				AnchorUILayoutData data = (AnchorUILayoutData)target;
			
				data.leftAnchor = GUILayout.Toggle (data.leftAnchor, "Left");
				if (data.leftAnchor) {
						EditorGUI.indentLevel++;
						data.leftTarget = (UIWidget)EditorGUILayout.ObjectField ("Target", data.leftTarget, typeof(UIWidget), true);
						data.left = EditorGUILayout.IntField ("Offset", data.left);
						EditorGUI.indentLevel--;
				}
				data.topAnchor = GUILayout.Toggle (data.topAnchor, "Top");
				
				if (data.topAnchor) {
						EditorGUI.indentLevel++;
						data.topTarget = (UIWidget)EditorGUILayout.ObjectField ("Target", data.topTarget, typeof(UIWidget), true);
						data.top = EditorGUILayout.IntField ("Offset", data.top);
						EditorGUI.indentLevel--;
				}
				data.rightAnchor = GUILayout.Toggle (data.rightAnchor, "Right");
				
				if (data.rightAnchor) {
						EditorGUI.indentLevel++;
						data.rightTarget = (UIWidget)EditorGUILayout.ObjectField ("Target", data.rightTarget, typeof(UIWidget), true);
						data.right = EditorGUILayout.IntField ("Offset", data.right);
						EditorGUI.indentLevel--;
				}
				data.bottomAnchor = GUILayout.Toggle (data.bottomAnchor, "Bottom");
			
				if (data.bottomAnchor) {
						EditorGUI.indentLevel++;
						data.bottomTarget = (UIWidget)EditorGUILayout.ObjectField ("Target", data.bottomTarget, typeof(UIWidget), true);
						data.bottom = EditorGUILayout.IntField ("Offset", data.bottom);
						EditorGUI.indentLevel--;
				}

				//
				data.verticalAnchor = GUILayout.Toggle (data.verticalAnchor, "Vertical");
			
				if (data.verticalAnchor) {
						EditorGUI.indentLevel++;
						data.verticalTarget = (UIWidget)EditorGUILayout.ObjectField ("Target", data.verticalTarget, typeof(UIWidget), true);
						data.vertical = EditorGUILayout.IntField ("Offset", data.vertical);
						EditorGUI.indentLevel--;
				}
				data.horizontalAnchor = GUILayout.Toggle (data.horizontalAnchor, "Horizontal");
				
				if (data.horizontalAnchor) {
						EditorGUI.indentLevel++;
						data.horizontalTarget = (UIWidget)EditorGUILayout.ObjectField ("Target", data.horizontalTarget, typeof(UIWidget), true);
						data.horizontal = EditorGUILayout.IntField ("Offset", data.horizontal);
						EditorGUI.indentLevel--;
				}

		}			
		
		
}