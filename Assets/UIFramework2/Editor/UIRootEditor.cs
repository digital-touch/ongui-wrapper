	using UnityEngine;
using UnityEditor;
using System.Collections;
	
[CustomEditor(typeof(UIRoot))]
public class UIRootEditor : Editor
{

		public override void OnInspectorGUI ()
		{				
				drawUIRootInspector ();
			
				if (GUI.changed) {
						EditorUtility.SetDirty (target);
				}
		}
		
		[SerializeField]
		bool
				rootFoldout = true;
		
		protected void drawUIRootInspector ()
		{
				UIRoot root = (UIRoot)target;
			
				// button
				rootFoldout = EditorGUILayout.Foldout (rootFoldout, "Root");
			
				if (rootFoldout) {
										
						EditorGUILayout.LabelField ("Width", root.width.ToString ());
						EditorGUILayout.LabelField ("Height", root.height.ToString ());
				}
		}			
		
		
}