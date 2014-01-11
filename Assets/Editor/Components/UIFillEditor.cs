using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(UIFill))]

public class UIFillEditor : UIWidgetEditor
{
	
		public override void OnInspectorGUI ()
		{				
				drawUIFillInspector ();
		
				base.OnInspectorGUI ();
		
				if (GUI.changed) {
						EditorUtility.SetDirty (target);
				}
		}
	
		[SerializeField]
		bool
				fillFoldout = true;
	
	
		void drawUIFillInspector ()
		{		
				UIFill fill = (UIFill)target;
		
				// button
				fillFoldout = EditorGUILayout.Foldout (fillFoldout, "Texture Fill");
		
				if (fillFoldout) {
			
						fill.textureSize = EditorGUILayout.IntField ("Size:", fill.textureSize);
						fill.textureColor = EditorGUILayout.ColorField ("Color:", fill.textureColor);
			
				}
		}
}
