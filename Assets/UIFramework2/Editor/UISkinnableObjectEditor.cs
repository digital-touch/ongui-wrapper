using UnityEngine;
using System.Collections;
using UnityEditor;

	[CustomEditor(typeof(UISkinSelector), true)]
	public class UISkinnableObjectEditor : UIGameObjectEditor {

	public override void OnInspectorGUI ()
	{
		drawUISkinnableObjectInspector ();
		
		drawUIGameObjectInspector ();
		
		updateRoot ();
	}
	
	[SerializeField]
	bool
		skinnableObjectFoldout = true;
	
	
	protected void drawUISkinnableObjectInspector ()
	{
		UISkinnableObject uiSkinnableObject = (UISkinnableObject)target;
		
		// skinnable
		
		skinnableObjectFoldout = EditorGUILayout.Foldout (skinnableObjectFoldout, "Skinnable");
		
		if (skinnableObjectFoldout) {
			
			
			EditorGUI.indentLevel++;
			
//			if (uiSkinnableObject.currentSkin == null) {
//				EditorGUILayout.LabelField ("No skin selected"); 
//			} else {
//				EditorGUILayout.LabelField ("Selected skin", uiSkinnableObject.currentSkin.name); 			
//			}
//			
//			if (uiSkinnableObject.skins != null && uiSkinnableObject.skins.Count > 0) {
//				uiSkinnableObject.skinIndex = EditorGUILayout.IntField ("Skin index", uiSkinnableObject.skinIndex);
//				uiSkinnableObject.skinIndex = (int)EditorGUILayout.Slider ("index", uiSkinnableObject.skinIndex, 0, uiSkinnableObject.skins.Count);
//			}
//			
//			SerializedProperty skins = serializedObject.FindProperty ("skins");
//			
//			EditorGUI.BeginChangeCheck ();
//			EditorGUILayout.PropertyField (skins, true);
//			if (EditorGUI.EndChangeCheck ()) {
//				serializedObject.ApplyModifiedProperties ();
//			}
			
			EditorGUI.indentLevel--;
		}
	}
}
