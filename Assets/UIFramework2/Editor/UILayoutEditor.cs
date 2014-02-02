
using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(UILayout), true)]
public class UILayoutEditor : Editor
{
	
		public override void OnInspectorGUI ()
		{				
				drawUILayoutInspector ();
				
				if (GUI.changed) {
						EditorUtility.SetDirty (target);
				}
		}
	
		[SerializeField]
		bool
				layoutFoldout = true;
		
		protected void drawUILayoutInspector ()
		{
				UILayout layout = (UILayout)target;
				
				// button
				layoutFoldout = EditorGUILayout.Foldout (layoutFoldout, "Layout");
		
				if (layoutFoldout) {
			
						EditorGUI.indentLevel++;
			
						EditorGUILayout.LabelField ("Content Size:", layout.contentSize.x + "x" + layout.contentSize.y, EditorStyles.boldLabel);
						
						EditorGUI.indentLevel--;
				}
		}			
		
	
}