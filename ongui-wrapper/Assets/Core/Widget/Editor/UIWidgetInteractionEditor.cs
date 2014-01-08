using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(UIWidgetInteraction), true)]
public class UIWidgetInteractionEditor : Editor
{
	
		public override void OnInspectorGUI ()
		{				
				drawUIWidgetInteractionInspector ();
		
				if (GUI.changed) {
						EditorUtility.SetDirty (target);
				}
		}
	
		void drawUIWidgetInteractionInspector ()
		{		
				UIWidgetInteraction widget = (UIWidgetInteraction)target;
		
				// id
		
				widget.isTouchable = EditorGUILayout.Toggle ("Touchable", widget.isTouchable);
		
		}
}
