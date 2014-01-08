
using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(UILayout), true)]
public class UILayoutEditor : Editor
{
	
		public override void OnInspectorGUI ()
		{				
				drawUILayoutGUI ();
				
				if (GUI.changed) {
						EditorUtility.SetDirty (target);
				}
		}
	
		[SerializeField]
		bool
				layoutFoldout = true;
		
		void drawUILayoutGUI ()
		{
				UILayout layout = (UILayout)target;
				
				// button
				layoutFoldout = EditorGUILayout.Foldout (layoutFoldout, "Layout");
		
				if (layoutFoldout) {
			
						EditorGUILayout.LabelField ("Content Size:", EditorStyles.boldLabel);
						EditorGUILayout.LabelField ("Width", layout.contentSize.width.ToString ());
						EditorGUILayout.LabelField ("Height", layout.contentSize.height.ToString ());
				}
		}			
		
	
}