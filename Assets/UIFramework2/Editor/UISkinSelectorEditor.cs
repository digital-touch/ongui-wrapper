
using UnityEngine;
using UnityEditor;
using System.Collections;
	
[CustomEditor(typeof(UISkinSelector), true)]
public class UISkinSelectorEditor : Editor
{
		
		public override void OnInspectorGUI ()
		{
		drawUISkinnableObjectInspector ();				
		}
		
		[SerializeField]
		bool
				skinnableObjectFoldout = true;
		
	[SerializeField]
	bool foldout = true;
		
		protected void drawUISkinnableObjectInspector ()
		{
		UISkinSelector skinSelector = (UISkinSelector)target;
			
				// skinnable
			
				skinnableObjectFoldout = EditorGUILayout.Foldout (skinnableObjectFoldout, "Skin Selector");
			
				if (skinnableObjectFoldout) {				
				
						EditorGUI.indentLevel++;
						
						if (skinSelector.currentSkin == null) {
								EditorGUILayout.LabelField ("No skin selected"); 
						} else {
								EditorGUILayout.LabelField ("Selected skin", skinSelector.currentSkin.name); 			
						}
						
						if (skinSelector.skins != null && skinSelector.skins.Count > 0) {
								skinSelector.skinIndex = EditorGUILayout.IntField ("Skin index", skinSelector.skinIndex);
								skinSelector.skinIndex = (int)EditorGUILayout.Slider ("index", skinSelector.skinIndex, 0, skinSelector.skins.Count);
						}
						
//			foldout = EditorGUI.Foldout(position, foldout, label);
//			if (foldout)
//			{
//				string[] names = Enum.GetNames(nameListAttribute.names);
//				
//				for (int i = 0; i < names.Length; i++)
//				{
//					Rect rect = EditorGUI.IndentedRect(position);
//					rect.y += 15*(i + 1);
//					rect.height = 15f;
//					EditorGUI.PropertyField(rect, property.GetArrayElementAtIndex(i), new GUIContent(names[i]));
//				}
//			}
//
//			return;
						SerializedProperty skins = serializedObject.FindProperty ("skins");
						
						EditorGUI.BeginChangeCheck ();

						EditorGUILayout.PropertyField (skins, true);

						if (EditorGUI.EndChangeCheck ()) {
								serializedObject.ApplyModifiedProperties ();
						}
										
						EditorGUI.indentLevel--;
				}
		}
}
				