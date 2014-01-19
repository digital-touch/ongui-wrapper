
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(UIVerticalLayout))]
public class UIVerticalLayoutEditor : UILinearLayoutEditor
{
	
		public override void OnInspectorGUI ()
		{		
		
				base.OnInspectorGUI ();		
				drawUIVerticalLayoutInspector ();
		
				if (GUI.changed) {
						EditorUtility.SetDirty (target);
				}
		}
	
//		[SerializeField]
//		bool
//				uiVerticalLayoutFoldout = true;
	
		protected void drawUIVerticalLayoutInspector ()
		{
//				UIVerticalLayout layout = (UIVerticalLayout)target;
//		
//				// button
//				uiVerticalLayoutFoldout = EditorGUILayout.Foldout (uiVerticalLayoutFoldout, "Vertical Layout");
//		
//				if (uiVerticalLayoutFoldout) {
//			layout.
//				}
		}			
	
	
}