
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(UIVerticalLayout))]
public class UIVerticalLayoutEditor : UILinearLayoutEditor
{
	
		public override void OnInspectorGUI ()
		{		
		
				drawUIVerticalLayoutInspector ();
		drawUILinearLayoutInspector ();
		drawUIScrollableLayoutInspector ();
		drawUILayoutInspector ();
		
		if (GUI.changed) {
			UILinearLayout layout = (UILinearLayout)target;			
			EditorUtility.SetDirty (layout.transform.root.gameObject);
		}
		}
	

		bool
				uiVerticalLayoutFoldout = true;
	
		protected void drawUIVerticalLayoutInspector ()
		{
				UIVerticalLayout layout = (UIVerticalLayout)target;
		
				// button
				uiVerticalLayoutFoldout = EditorGUILayout.Foldout (uiVerticalLayoutFoldout, "Vertical Layout");
		
				if (uiVerticalLayoutFoldout) {
						EditorGUILayout.LabelField ("Max Scroll Position", "x: " + (int)layout.maxScrollPosition.x + ", y: " + (int)layout.maxScrollPosition.y);
				}
		}			
	
	
}