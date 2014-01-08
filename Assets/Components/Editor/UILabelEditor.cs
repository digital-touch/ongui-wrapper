using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(UILabel))]

public class UILabelEditor : UIWidgetEditor
{
	
		public override void OnInspectorGUI ()
		{				
				drawUILabelInspector ();
		
				base.OnInspectorGUI ();		
		
				if (GUI.changed) {
						EditorUtility.SetDirty (target);
				}
		}
			
		bool labelFoldout = true;	
	
		void drawUILabelInspector ()
		{		
				UILabel label = (UILabel)target;
		
				// label
				labelFoldout = EditorGUILayout.Foldout (labelFoldout, "Label");
		
				if (labelFoldout) {
			
						
						EditorGUILayout.LabelField ("Text:");
						
						Color oldColor = GUI.color;
						GUI.color = Color.white;
						label.text = EditorGUILayout.TextArea (label.text);
						GUI.color = oldColor;
			
						label.textStyle = (UITextStyle)EditorGUILayout.ObjectField ("TextStyle", label.textStyle, typeof(UITextStyle), true);
						
						
				}
		}
}
