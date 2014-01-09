
using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(UIHorizontalLayout))]
public class UIHorizontalLayoutEditor : UILinearLayoutEditor
{
	
		public override void OnInspectorGUI ()
		{		
		
				base.OnInspectorGUI ();		
				drawUIHorizontalLayoutGUI ();
		
				if (GUI.changed) {
						EditorUtility.SetDirty (target);
				}
		}
	
//		[SerializeField]
//		bool
//				uiHorizontalLayoutFoldout = true;
	
		void drawUIHorizontalLayoutGUI ()
		{
//				UIHorizontalLayout layout = (UIHorizontalLayout)target;
//		
//				// button
//				uiHorizontalLayoutFoldout = EditorGUILayout.Foldout (uiHorizontalLayoutFoldout, "Horizontal Layout");
//		
//				if (uiHorizontalLayoutFoldout) {
//			
//				}
		}			
	
	
}