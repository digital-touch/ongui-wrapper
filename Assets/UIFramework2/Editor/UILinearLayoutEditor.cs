﻿
using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(UILinearLayout))]
public class UILinearLayoutEditor : UILayoutEditor
{
	
		public override void OnInspectorGUI ()
		{		
		
				base.OnInspectorGUI ();		
				drawUILinearLayoutInspector ();
		
				if (GUI.changed) {
						UILinearLayout layout = (UILinearLayout)target;			
						EditorUtility.SetDirty (layout.transform.root.gameObject);
				}
		}
	
		[SerializeField]
		bool
				uilinearLayoutFoldout = true;
	
		protected void drawUILinearLayoutInspector ()
		{
				UILinearLayout layout = (UILinearLayout)target;
		
				// button
				uilinearLayoutFoldout = EditorGUILayout.Foldout (uilinearLayoutFoldout, "Linear Layout");
		
				if (uilinearLayoutFoldout) {
			
						EditorGUI.indentLevel++;
			
						layout.gap = EditorGUILayout.IntField ("Gap:", layout.gap);
						
						EditorGUI.indentLevel--;
						
				}
		}			
	
	
}