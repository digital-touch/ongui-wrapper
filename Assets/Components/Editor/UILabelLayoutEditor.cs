using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(UILabelLayout))]
public class UILabelLayoutEditor : UILayoutEditor
{
	
		public override void OnInspectorGUI ()
		{				
				drawUILabelLayoutInspector ();
		
				base.OnInspectorGUI ();		
		
				if (GUI.changed) {
						EditorUtility.SetDirty (target);
				}
		}
	
		void drawUILabelLayoutInspector ()
		{		
				UILabelLayout layout = (UILabelLayout)target;
		
				layout.explicitWidth = EditorGUILayout.Toggle ("Explicit Width", layout.explicitWidth);
			
		}
}
