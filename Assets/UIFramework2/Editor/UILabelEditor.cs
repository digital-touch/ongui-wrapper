using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(UILabel))]

public class UILabelEditor : UIGameObjectEditor
{
	
		public override void OnInspectorGUI ()
		{				
				drawUILabelInspector ();
		
				drawUIGameObjectInspector ();
		
				updateRoot ();
		}
			
		bool labelFoldout = true;	
	
		protected void drawUILabelInspector ()
		{		
				UILabel label = (UILabel)target;
		
				// label
				labelFoldout = EditorGUILayout.Foldout (labelFoldout, "Label");
		
				if (labelFoldout) {
			
						EditorGUI.indentLevel++;									
						
						
						EditorGUILayout.LabelField("Text:");
						Color oldColor = GUI.color;
						GUI.color = Color.white;
						label.text = EditorGUILayout.TextArea (label.text);
						GUI.color = oldColor;

			EditorGUILayout.Space();
			label.textStyle = (UITextStyle) EditorGUILayout.ObjectField("Text Style", label.textStyle, typeof(UITextStyle), true);
			EditorGUILayout.Space();

						label.explicitWidth = EditorGUILayout.Toggle ("Explicit Width", label.explicitWidth);
						label.explicitHeight = EditorGUILayout.Toggle ("Explicit Height", label.explicitHeight);
						
						EditorGUI.indentLevel--;			
				}
		}
		
		
}
