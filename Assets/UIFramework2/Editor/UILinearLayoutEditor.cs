
using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(UILinearLayout))]
public class UILinearLayoutEditor : UILayoutEditor
{
	
		public override void OnInspectorGUI ()
		{		
		
				base.OnInspectorGUI ();		
				drawUILinearLayoutInspector ();
		
				if (GUI.changed) {
						EditorUtility.SetDirty (target);
				}
		}
	
		[SerializeField]
		bool
				uilinearLayoutFoldout = true;
	
		protected void drawUILinearLayoutInspector ()
		{
				UILinearLayout layout = (UILinearLayout)target;
		
				// button
				uilinearLayoutFoldout = EditorGUILayout.Foldout (uilinearLayoutFoldout, "Linear Layout");
		
				if (uilinearLayoutFoldout) {
			
						layout.gap = EditorGUILayout.IntField ("Gap:", layout.gap);
						
				}
		}			
	
	
}