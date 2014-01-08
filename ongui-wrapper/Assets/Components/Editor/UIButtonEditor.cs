using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(UIButton))]

public class UIButtonEditor : UIWidgetEditor
{
	
		public override void OnInspectorGUI ()
		{				
				base.OnInspectorGUI ();
		
				drawUIButtonInspector ();
		
				if (GUI.changed) {
						EditorUtility.SetDirty (target);
				}
		}
	
		[SerializeField]
		bool
				buttonFoldout = true;
	
	
		void drawUIButtonInspector ()
		{		
				//UIButton button = (UIButton)target;
		
				// button
				buttonFoldout = EditorGUILayout.Foldout (buttonFoldout, "Button");
		
				if (buttonFoldout) {
			
						EditorGUILayout.LabelField ("Skin Indices:", EditorStyles.boldLabel);
						EditorGUILayout.LabelField ("Normal Skin", "0");
						EditorGUILayout.LabelField ("Down Skin", "1");
			
						
				}
		}
}
