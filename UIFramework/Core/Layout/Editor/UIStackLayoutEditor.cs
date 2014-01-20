	using UnityEngine;
using UnityEditor;
using System.Collections;
	
[CustomEditor(typeof(UIStackLayout), true)]
public class UIStackLayoutEditor : UILayoutEditor
{
		
		public override void OnInspectorGUI ()
		{				
		
				base.OnInspectorGUI ();
		
				drawUIStackLayoutGUI ();
		
				if (GUI.changed) {
						EditorUtility.SetDirty (target);
				}
		}
	
		[SerializeField]
		bool
				uiStackLayoutFoldout = true;
	
		void drawUIStackLayoutGUI ()
		{
				UIStackLayout layout = (UIStackLayout)target;
		
				// button
				uiStackLayoutFoldout = EditorGUILayout.Foldout (uiStackLayoutFoldout, "Stack Layout");
		
				if (uiStackLayoutFoldout) {
			
						layout.selectedIndex = EditorGUILayout.IntField ("Selected Index", layout.selectedIndex);
				}
		}			
}
	