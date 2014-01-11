using UnityEngine;
using UnityEditor;
using System.Collections;
using TouchScript;
using TouchScript.InputSources;

[ExecuteInEditMode]
public class UIRoot : UIWidget
{
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public static readonly string ROOT_ID = "root";
		
		public UIRoot ():base()
		{
				id = ROOT_ID;
		}
		
		public override UIRoot root {		
				get {
						return this;
				}	
				set {						
				}
		}
	
		protected override void Awake ()
		{
				base.Awake ();				
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
	#if UNITY_EDITOR
	
		[MenuItem("UI/UIRoot")]
		
		#endif
	public static GameObject createUIRoot ()
		{
				GameObject root = new GameObject ("UIRoot");
				
	
				root.AddComponent<UIRoot> ();
	
				root.AddComponent<FitToScreenUILayout> ();
				root.AddComponent<UIWidgetRenderer> ();
				root.AddComponent<UIRootInteraction> ();
				root.AddComponent<TouchManager> ();
				root.AddComponent<MouseInput> ();
				root.AddComponent<UIRootEventHandler> (); 
				
				
				return root;
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////			
		
		
	
}
