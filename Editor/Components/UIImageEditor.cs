using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(UIImage))]

public class UIImageEditor : UIWidgetEditor
{
	
		public override void OnInspectorGUI ()
		{				
				base.OnInspectorGUI ();
		
				drawUIImageInspector ();
		
				if (GUI.changed) {
						EditorUtility.SetDirty (target);
				}
		}
	
		[SerializeField]
		bool
				imageFoldout = true;
	
	
		void drawUIImageInspector ()
		{		
				UIImage image = (UIImage)target;
		
				// image
				imageFoldout = EditorGUILayout.Foldout (imageFoldout, "Image");
		
				if (imageFoldout) {
			
						EditorGUI.indentLevel++;
			
					
						image.image = (Texture)EditorGUILayout.ObjectField ("Texture", image.image, typeof(Texture), true);
			
						EditorGUI.indentLevel--;						
			
				}
		}
}
