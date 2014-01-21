using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(ScaleUILayout), true)]
public class ScaleUILayoutEditor : UILayoutEditor
{
	
		public override void OnInspectorGUI ()
		{				
		
		
				drawScaleUILayoutInspector ();
				base.OnInspectorGUI ();
		
				if (GUI.changed) {
						EditorUtility.SetDirty (target);
				}
		}
	
		[SerializeField]
		bool
				scaleUILayoutFoldout = true;
	
		protected void drawScaleUILayoutInspector ()
		{
				ScaleUILayout layout = (ScaleUILayout)target;
		
				// scale
				scaleUILayoutFoldout = EditorGUILayout.Foldout (scaleUILayoutFoldout, "Scale Layout");

				if (scaleUILayoutFoldout) {
		
						//		if (GUILayout.Button ("Aspect from image")) {
						//layout.aspectRatio = ui
						//}
						layout.aspectRatio = EditorGUILayout.FloatField ("Aspect Ratio", layout.aspectRatio);						
						layout.type = (ScaleUILayoutType)EditorGUILayout.EnumPopup ("Type", layout.type);
						if (layout.type == ScaleUILayoutType.SCALE) {
								layout.width = EditorGUILayout.IntField ("Width", layout.width);						
								layout.height = EditorGUILayout.IntField ("Height", layout.height);						
						}
				}
		}			
}

