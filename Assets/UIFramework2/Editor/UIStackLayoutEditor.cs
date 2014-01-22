	using UnityEngine;
using UnityEditor;
using System.Collections;
	
[CustomEditor(typeof(UIStackLayout), true)]
public class UIStackLayoutEditor : UILayoutEditor
{
		
		public override void OnInspectorGUI ()
		{				
		
				base.OnInspectorGUI ();
		
				drawUIStackLayoutInspector ();
		
				if (GUI.changed) {
						EditorUtility.SetDirty (target);
				}
		}
	
		[SerializeField]
		bool
				uiStackLayoutFoldout = true;				
	
		protected void drawUIStackLayoutInspector ()
		{
				UIStackLayout layout = (UIStackLayout)target;
		
				// button
				uiStackLayoutFoldout = EditorGUILayout.Foldout (uiStackLayoutFoldout, "Stack Layout");
		
				if (uiStackLayoutFoldout) {
			
						EditorGUI.indentLevel++;
			
			
						layout.showEffect = (UITween)EditorGUILayout.ObjectField ("Show Effect", layout.showEffect, typeof(UITween), true);
						layout.hideEffect = (UITween)EditorGUILayout.ObjectField ("Hide Effect", layout.hideEffect, typeof(UITween), true);
			
						SerializedProperty elements = serializedObject.FindProperty ("elements");
						
						EditorGUI.BeginChangeCheck ();
						EditorGUILayout.PropertyField (elements, true);
						if (EditorGUI.EndChangeCheck ())
								serializedObject.ApplyModifiedProperties ();
				
						
						
						if (layout.elements.Count == 0) {
								EditorGUILayout.LabelField ("no elements in layout");
						} else {
								layout.selectedIndex = (int)EditorGUILayout.Slider ("Selected Index", layout.selectedIndex, 0f, (float)layout.elements.Count - 1);
						}
						
						EditorGUI.indentLevel--;
				}
		}			
}
	