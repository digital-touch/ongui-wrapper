using UnityEngine;
	using UnityEditor;
	using System.Collections;
	
	[CustomEditor(typeof(FitToParentUILayout), true)]
	public class FitToParentUILayoutEditor : UILayoutEditor
	{
		
		public override void OnInspectorGUI ()
		{				
			
			
			drawFitToParentUILayoutInspector ();
			base.OnInspectorGUI ();
			
			if (GUI.changed) {
				EditorUtility.SetDirty (target);
			}
		}
		
		[SerializeField]
		bool
			fitToParentUILayoutFoldout = true;
		
		protected void drawFitToParentUILayoutInspector ()
		{
		FitToParentUILayout layout = (FitToParentUILayout)target;
			
			// fit to parent
			fitToParentUILayoutFoldout = EditorGUILayout.Foldout (fitToParentUILayoutFoldout, "Fit to parent");
			
			if (fitToParentUILayoutFoldout) {
				
				EditorGUI.indentLevel++;
				
			layout.fitHorizontally = EditorGUILayout.Toggle ("Fit Horizontally", layout.fitHorizontally);						
			layout.fitVertically = EditorGUILayout.Toggle ("Fit Vertically", layout.fitVertically);
				
				EditorGUI.indentLevel--;
			}
		}			
	}
	
