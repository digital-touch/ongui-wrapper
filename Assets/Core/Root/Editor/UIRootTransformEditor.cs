using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(UIRootTransform))]
public class UIRootTransformEditor : Editor
{
	
		public override void OnInspectorGUI ()
		{								
				drawUIRootTransformInspector ();
		
				if (GUI.changed) {
						EditorUtility.SetDirty (target);
				}				
		}
	
		protected bool boundsFoldout = true;
	
		void drawUIRootTransformInspector ()
		{				
				UIWidgetTransform widgetTransform = (UIWidgetTransform)target;
		
				// bounds
				boundsFoldout = EditorGUILayout.Foldout (boundsFoldout, "Position");
		
				if (boundsFoldout) {
						EditorGUILayout.LabelField ("width", widgetTransform.width.ToString ());
						EditorGUILayout.LabelField ("height", widgetTransform.height.ToString ());
				}		
		}
}
