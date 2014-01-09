using UnityEngine;
using UnityEditor;
using System.Collections;
using TouchScript;
using TouchScript.InputSources;

[ExecuteInEditMode]
[System.Serializable]
[RequireComponent(typeof(UIJuggler))]
public class UIRoot : UIWidget
{
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public static readonly string ROOT_ID = "root";
		
		public UIRoot ():base()
		{
				id = ROOT_ID;
							
		}
		
		protected override void Awake ()
		{
				base.Awake ();
				UIInvalidator.invalidate (this);
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
	#if UNITY_EDITOR
	
		[MenuItem("UI/UIRoot")]
		
		#endif
	public static GameObject createUIRoot ()
		{
				GameObject root = new GameObject ("UIRoot");
				
				root.AddComponent<UIRootTransform> ();
				root.AddComponent<UIRoot> ();
				root.AddComponent<UIWidgetValidator> ();
				root.AddComponent<FitToScreenUILayout> ();
				root.AddComponent<UIWidgetRenderer> ();
				root.AddComponent<UIRootInteraction> ();
				root.AddComponent<TouchManager> ();
				root.AddComponent<MouseInput> ();
				root.AddComponent<UIRootEventHandler> (); 
				root.AddComponent<UIJuggler> (); 
				
				return root;
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////			
		
		
	
}
