using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(UIGradientFill))]
public class UIGradientFillEditor : UIGameObjectEditor
{

		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public override void OnInspectorGUI ()
		{				
		
		
				drawUIGradientFillInspector ();
		
				drawUIGameObjectInspector ();
				updateRoot ();
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[SerializeField]
		bool
				gradientFillFoldout = true;
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		protected void drawUIGradientFillInspector ()
		{		
				UIGradientFill gradientFill = (UIGradientFill)target;
		
				// gradient fill
				gradientFillFoldout = EditorGUILayout.Foldout (gradientFillFoldout, "Gradient Fill");
		
				if (gradientFillFoldout) {
			
						EditorGUI.indentLevel++;
						
						gradientFill.startColor = EditorGUILayout.ColorField ("Start Color", gradientFill.startColor);
						gradientFill.endColor = EditorGUILayout.ColorField ("End Color", gradientFill.endColor);
			
						gradientFill.direction = (TextureDirection)EditorGUILayout.EnumPopup ("Direction", gradientFill.direction);						
			
						EditorGUI.indentLevel--;						
			
				}
	
		}
}
