using UnityEngine;
using UnityEditor;
using System.Collections;

[ExecuteInEditMode]
public class UIRootEventHandler : MonoBehaviour
{
		UIWidget root;
	
		void Awake ()
		{				
				
				root = GetComponent<UIRoot> ();
				validateSize ();
		}
		
		bool started = false;
	 
		void Start ()
		{
				started = true;			
		}
		
		void OnDestroy ()
		{				
				
		}
	
		void FixedUpdate ()
		{
				if (started) {
						validateSize ();
					
            
						UITweener.validate ();
						UIInvalidator.validate ();
				}
		}

		void validateSize ()
		{
				if (root.width != Screen.width) {								
						root.width = Screen.width;
				}
				if (root.height != Screen.height) {								
						root.height = Screen.height;
				}
		}
		
		protected virtual void OnGUI ()
		{
				if (!started) {
						return;
				}
		
				if (!started) {
						return;
				}
				if (!gameObject.activeSelf) {					
						return;
				}		
		
				//widgetValidator.Validate ();		
		
//				#if UNITY_EDITOR		
//				EditorUtility.SetDirty (this);		
//				#endif
		
				
				root.Draw (null);
				
		}
	
}
