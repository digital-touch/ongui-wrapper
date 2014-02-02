	using UnityEngine;
	using UnityEditor;
	using System.Collections;
	
[CustomEditor(typeof(UIButton))]
	
	public class UIButtonEditor : UIGameObjectEditor
	{
		
		public override void OnInspectorGUI ()
		{				
			drawUIButtonInspector ();			
			drawUIGameObjectInspector ();			
			updateRoot ();
		}
		
		bool buttonFoldout = true;	
		
		protected void drawUIButtonInspector ()
		{		
		UIButton button = (UIButton)target;
			
			// button
			buttonFoldout = EditorGUILayout.Foldout (buttonFoldout, "Button");
			
			if (buttonFoldout) {
				
				EditorGUI.indentLevel++;									
								
			button.skin = (UIButtonSkin) EditorGUILayout.ObjectField("Button skin", button.skin, typeof(UIButtonSkin), true);				

			button.label = (UILabel) EditorGUILayout.ObjectField("Button label", button.label, typeof(UILabel), true);				

			if (button.label != null) {
			EditorGUILayout.LabelField("Label:");
			Color oldColor = GUI.color;
			GUI.color = Color.white;
			button.label.text = EditorGUILayout.TextArea (button.label.text);
			GUI.color = oldColor;
			}

				EditorGUI.indentLevel--;			
			}
		}
		
		
	}
