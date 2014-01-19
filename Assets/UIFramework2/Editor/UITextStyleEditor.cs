using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(UITextStyle), true)]
public class UITextStyleEditor : Editor
{
	
		public override void OnInspectorGUI ()
		{				
				drawUITextStyleInspector ();
		
				if (GUI.changed) {
						EditorUtility.SetDirty (target);
				}
		}
	
		protected void drawUITextStyleInspector ()
		{		
				UITextStyle textStyle = (UITextStyle)target;
		
		
				textStyle.id = EditorGUILayout.TextField ("id", textStyle.id);
				EditorGUILayout.Space ();
				textStyle.font = (Font)EditorGUILayout.ObjectField ("font", textStyle.font, typeof(Font), true);
				textStyle.fontSize = EditorGUILayout.IntField ("size", textStyle.fontSize);		
				textStyle.textColor = EditorGUILayout.ColorField ("color", textStyle.textColor);
				EditorGUILayout.Space ();
				textStyle.fontStyle = (FontStyle)EditorGUILayout.EnumPopup ("style", textStyle.fontStyle);
				EditorGUILayout.Space ();
				textStyle.textAlignment = (TextAnchor)EditorGUILayout.EnumPopup ("alignment", textStyle.textAlignment);
				EditorGUILayout.Space ();
				textStyle.wordWrap = EditorGUILayout.Toggle ("word wrap", textStyle.wordWrap);
				textStyle.richText = EditorGUILayout.Toggle ("rich text", textStyle.richText);
		
			
		
		}
}
