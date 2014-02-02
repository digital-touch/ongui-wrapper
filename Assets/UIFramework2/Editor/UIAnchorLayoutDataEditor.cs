using UnityEngine;
using UnityEditor;
using System.Collections;
	
[CustomEditor(typeof(AnchorUILayoutData))]
public class UIAnchorLayoutDataEditor : Editor
{
		
		public override void OnInspectorGUI ()
		{		
						
				drawUIAnchorLayoutDataInspector ();
			
				if (GUI.changed) {
				
						UIGameObject uiGameObject = ((AnchorUILayoutData)target).GetComponent<UIGameObject> ();
			
						if (uiGameObject.root == null) {
								return;
						}
						EditorUtility.SetDirty (uiGameObject.root);
				}
		}

		protected void drawUIAnchorLayoutDataInspector ()
		{
				AnchorUILayoutData data = (AnchorUILayoutData)target;
			
				data.leftAnchor = GUILayout.Toggle (data.leftAnchor, "Left");
				if (data.leftAnchor) {
						EditorGUI.indentLevel++;
						EditorGUILayout.BeginHorizontal ();
						data.leftTarget = (UIGameObject)EditorGUILayout.ObjectField ("Target", data.leftTarget, typeof(UIGameObject), true);
						data.left = EditorGUILayout.IntField ("Offset", data.left);
						EditorGUILayout.EndHorizontal ();
						EditorGUI.indentLevel--;
				}
				data.topAnchor = GUILayout.Toggle (data.topAnchor, "Top");
				
				if (data.topAnchor) {
						EditorGUI.indentLevel++;
						EditorGUILayout.BeginHorizontal ();
						data.topTarget = (UIGameObject)EditorGUILayout.ObjectField ("Target", data.topTarget, typeof(UIGameObject), true);
						data.top = EditorGUILayout.IntField ("Offset", data.top);
						EditorGUILayout.EndHorizontal ();
						EditorGUI.indentLevel--;
				}
				data.rightAnchor = GUILayout.Toggle (data.rightAnchor, "Right");
				
				if (data.rightAnchor) {
						EditorGUI.indentLevel++;
						EditorGUILayout.BeginHorizontal ();
						data.rightTarget = (UIGameObject)EditorGUILayout.ObjectField ("Target", data.rightTarget, typeof(UIGameObject), true);
						data.right = EditorGUILayout.IntField ("Offset", data.right);
						EditorGUILayout.EndHorizontal ();
						EditorGUI.indentLevel--;
				}
				data.bottomAnchor = GUILayout.Toggle (data.bottomAnchor, "Bottom");
			
				if (data.bottomAnchor) {
						EditorGUI.indentLevel++;
						EditorGUILayout.BeginHorizontal ();
						data.bottomTarget = (UIGameObject)EditorGUILayout.ObjectField ("Target", data.bottomTarget, typeof(UIGameObject), true);
						data.bottom = EditorGUILayout.IntField ("Offset", data.bottom);
						EditorGUILayout.EndHorizontal ();
						EditorGUI.indentLevel--;
				}

				//
				data.verticalAnchor = GUILayout.Toggle (data.verticalAnchor, "Vertical");
			
				if (data.verticalAnchor) {
						EditorGUI.indentLevel++;
						EditorGUILayout.BeginHorizontal ();
						data.verticalTarget = (UIGameObject)EditorGUILayout.ObjectField ("Target", data.verticalTarget, typeof(UIGameObject), true);
						data.vertical = EditorGUILayout.IntField ("Offset", data.vertical);
						EditorGUILayout.EndHorizontal ();
						EditorGUI.indentLevel--;
				}
				data.horizontalAnchor = GUILayout.Toggle (data.horizontalAnchor, "Horizontal");
				
				if (data.horizontalAnchor) {
						EditorGUI.indentLevel++;
						EditorGUILayout.BeginHorizontal ();
						data.horizontalTarget = (UIGameObject)EditorGUILayout.ObjectField ("Target", data.horizontalTarget, typeof(UIGameObject), true);
						data.horizontal = EditorGUILayout.IntField ("Offset", data.horizontal);
						EditorGUILayout.EndHorizontal ();
						EditorGUI.indentLevel--;
				}

		}			
		
		
}