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
			
						label.textStyle = (UITextStyle)EditorGUILayout.ObjectField ("TextStyle", label.textStyle, typeof(UITextStyle), true);
						
						label.backgroundSkin = (UIGameObject)EditorGUILayout.ObjectField ("BackgroundSkin", label.backgroundSkin, typeof(UIGameObject), true);
						
						label.explicitWidth = EditorGUILayout.Toggle ("Explicit Width", label.explicitWidth);
						
						EditorGUILayout.Space ();
						
						label.paddingLeft = EditorGUILayout.IntField ("Padding Left", label.paddingLeft);
						label.paddingRight = EditorGUILayout.IntField ("Padding Right", label.paddingRight);
						label.paddingTop = EditorGUILayout.IntField ("Padding Top", label.paddingTop);
						label.paddingBottom = EditorGUILayout.IntField ("Padding Bottom", label.paddingBottom);
						
						EditorGUI.indentLevel--;			
				}
		}
}
