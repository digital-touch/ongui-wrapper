using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(UIImage))]
public class UIImageEditor : UIGameObjectEditor
{
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
		public override void OnInspectorGUI ()
		{				
				
		
				drawUIImageInspector ();
		
				drawUIGameObjectInspector ();
				updateRoot ();
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[SerializeField]
		bool
				imageFoldout = true;
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		protected void drawUIImageInspector ()
		{		
				UIImage image = (UIImage)target;
		
				// image
				imageFoldout = EditorGUILayout.Foldout (imageFoldout, "Image");
		
				if (imageFoldout) {
			
						EditorGUI.indentLevel++;
			
					
						image.image = (Texture2D)EditorGUILayout.ObjectField ("Texture", image.image, typeof(Texture2D), true);
						image.alphaBlend = EditorGUILayout.Toggle ("Alpha Blend", image.alphaBlend);
						image.imageAspect = EditorGUILayout.FloatField ("Image Aspect", image.imageAspect);
						image.scaleMode = (ScaleMode)EditorGUILayout.EnumPopup ("Scale Mode", image.scaleMode);
						
						if (GUILayout.Button ("Resize to image")) {
								image.resizeToImage ();
						}
						
						EditorGUI.indentLevel--;						
			
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
}
