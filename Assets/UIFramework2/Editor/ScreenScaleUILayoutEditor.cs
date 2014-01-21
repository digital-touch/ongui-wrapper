	using UnityEngine;
using UnityEditor;
using System.Collections;
	
[CustomEditor(typeof(ScreenScaleUILayout), true)]
public class ScreenScaleUILayoutEditor : UILayoutEditor
{
		
		public override void OnInspectorGUI ()
		{				
						
				drawScreenScaleUILayoutInspector ();
				base.OnInspectorGUI ();
			
				if (GUI.changed) {
						EditorUtility.SetDirty (target);
				}
		}
		
		[SerializeField]
		bool
				screenScaleUILayoutFoldout = true;
		
		protected void drawScreenScaleUILayoutInspector ()
		{
				ScreenScaleUILayout layout = (ScreenScaleUILayout)target;
			
				// screen scale
				screenScaleUILayoutFoldout = EditorGUILayout.Foldout (screenScaleUILayoutFoldout, "Screen Scale Layout");
			
				if (screenScaleUILayoutFoldout) {
				
						EditorGUILayout.LabelField ("Scale Factor", layout.scaleFactor.ToString ());
						EditorGUILayout.Space ();
						layout.unscaledWidth = EditorGUILayout.IntField ("Unscaled Width", layout.unscaledWidth);						
						layout.unscaledHeight = EditorGUILayout.IntField ("Unscaled Height", layout.unscaledHeight);						

						EditorGUILayout.Space ();
						layout.designWidth = (float)EditorGUILayout.IntField ("Design Width", (int)layout.designWidth);						
						layout.designHeight = (float)EditorGUILayout.IntField ("Design Height", (int)layout.designHeight);						
						layout.designPPI = (float)EditorGUILayout.IntField ("Design PPI", (int)layout.designPPI);												
				}
		}			
}
	
