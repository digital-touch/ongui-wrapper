using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(UITextStyle), true)]
public class UITextStyleEditor : Editor
{
	
		public override void OnInspectorGUI ()
		{				
				drawUITextStyleInspector ();
				drawFontMetricsInspector ();
		
				if (GUI.changed) {
						EditorUtility.SetDirty (target);
				}
		}
	
		protected bool fontMetricsFoldout = true;	
	
		protected void drawFontMetricsInspector ()
		{		
				UITextStyle textStyle = (UITextStyle)target;
		
				// label
				fontMetricsFoldout = EditorGUILayout.Foldout (fontMetricsFoldout, "Font Metrics");
		
				if (fontMetricsFoldout) {
			
						EditorGUI.indentLevel++;									
			
						EditorGUILayout.LabelField ("highestBaseLineCount", textStyle.fontMetrics.highestBaseLineCount.ToString ());
						EditorGUILayout.LabelField ("baseLine", textStyle.fontMetrics.baseLine.ToString ());
						EditorGUILayout.LabelField ("ascend", textStyle.fontMetrics.ascend.ToString ());
						EditorGUILayout.LabelField ("descend", textStyle.fontMetrics.descend.ToString ());
			
						EditorGUI.indentLevel--;			
				}
		}
	
		
		protected bool textStyleFoldout = true;	
	
		protected void drawUITextStyleInspector ()
		{		
				UITextStyle textStyle = (UITextStyle)target;
		
				// label
				textStyleFoldout = EditorGUILayout.Foldout (textStyleFoldout, "Text STyle");
		
				if (textStyleFoldout) {
			
						EditorGUI.indentLevel++;									
			
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
			
						EditorGUI.indentLevel--;			
				}
		}
}
