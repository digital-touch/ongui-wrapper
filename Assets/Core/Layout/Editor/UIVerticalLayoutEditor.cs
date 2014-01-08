﻿
using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(UIVerticalLayout))]
public class UIVerticalLayoutEditor : UILinearLayoutEditor
{
	
		public override void OnInspectorGUI ()
		{		
		
				base.OnInspectorGUI ();		
				drawUIVerticalLayoutGUI ();
		
				if (GUI.changed) {
						EditorUtility.SetDirty (target);
				}
		}
	
		[SerializeField]
		bool
				uiVerticalLayoutFoldout = true;
	
		void drawUIVerticalLayoutGUI ()
		{
				UIVerticalLayout layout = (UIVerticalLayout)target;
		
				// button
				uiVerticalLayoutFoldout = EditorGUILayout.Foldout (uiVerticalLayoutFoldout, "Vertical Layout");
		
				if (uiVerticalLayoutFoldout) {
			
				}
		}			
	
	
}