
using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(UIHorizontalLayout))]
public class UIHorizontalLayoutEditor : UILinearLayoutEditor
{
	
		public override void OnInspectorGUI ()
		{		
		
				base.OnInspectorGUI ();		
				drawUIHorizontalLayoutInspector ();
		
				if (GUI.changed) {
						EditorUtility.SetDirty (target);
				}
		}
	
//		[SerializeField]
//		bool
//				uiHorizontalLayoutFoldout = true;
	
		protected void drawUIHorizontalLayoutInspector ()
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