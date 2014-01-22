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
									
						
						Color oldColor = GUI.color;
						GUI.color = Color.white;
						label.text = EditorGUILayout.TextArea (label.text);
						GUI.color = oldColor;
			
						label.explicitWidth = EditorGUILayout.Toggle ("Explicit Width", label.explicitWidth);
						
						EditorGUI.indentLevel--;			
				}
		}
}
