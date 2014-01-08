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
			
				data.leftAnchor = EditorGUILayout.Toggle ("Left", data.leftAnchor);
				if (data.leftAnchor) {
						data.leftTarget = (UIWidget)EditorGUILayout.ObjectField ("Target", data.leftTarget, typeof(UIWidget), true);
						data.left = EditorGUILayout.IntField ("Offset", data.left);
				}

				data.topAnchor = EditorGUILayout.Toggle ("Top", data.topAnchor);
				if (data.topAnchor) {
						data.topTarget = (UIWidget)EditorGUILayout.ObjectField ("Target", data.topTarget, typeof(UIWidget), true);
						data.top = EditorGUILayout.IntField ("Offset", data.top);
				}

				data.rightAnchor = EditorGUILayout.Toggle ("Right", data.rightAnchor);
				if (data.rightAnchor) {
						data.rightTarget = (UIWidget)EditorGUILayout.ObjectField ("Target", data.rightTarget, typeof(UIWidget), true);
						data.right = EditorGUILayout.IntField ("Offset", data.right);
				}

				data.bottomAnchor = EditorGUILayout.Toggle ("Bottom", data.bottomAnchor);
				if (data.bottomAnchor) {
						data.bottomTarget = (UIWidget)EditorGUILayout.ObjectField ("Target", data.bottomTarget, typeof(UIWidget), true);
						data.bottom = EditorGUILayout.IntField ("Offset", data.bottom);
				}

				//

				data.verticalAnchor = EditorGUILayout.Toggle ("Vertical", data.verticalAnchor);
				if (data.verticalAnchor) {
						data.verticalTarget = (UIWidget)EditorGUILayout.ObjectField ("Target", data.verticalTarget, typeof(UIWidget), true);
						data.vertical = EditorGUILayout.IntField ("Offset", data.vertical);
				}
		
				data.horizontalAnchor = EditorGUILayout.Toggle ("Horizontal", data.horizontalAnchor);
				if (data.horizontalAnchor) {
						data.horizontalTarget = (UIWidget)EditorGUILayout.ObjectField ("Target", data.horizontalTarget, typeof(UIWidget), true);
						data.horizontal = EditorGUILayout.IntField ("Offset", data.horizontal);
				}

		}			
		
		
}