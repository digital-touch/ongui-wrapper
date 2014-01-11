using UnityEngine;
using UnityEditor;
using System.Collections;

[ExecuteInEditMode]
public class UIRootEventHandler : UIWidgetBehaviour
{
		UIWidgetRenderer widgetRenderer;	
	
		override protected void Awake ()
		{				
				base.Awake ();
				widgetRenderer = GetComponent<UIWidgetRenderer> ();
				
				validateSize ();
		}
		
		bool started = false;
	 
		protected void Start ()
		{
				started = true;			
		}
		
		override protected void OnDestroy ()
		{				
				base.OnDestroy ();
		
				widgetRenderer = null;
		}
	
		protected virtual void FixedUpdate ()
		{
				if (started) {
						validateSize ();
					
            
						UITweener.validate ();
						UIInvalidator.validate ();
				}
		}

		void validateSize ()
		{
				if (widget.width != Screen.width) {								
						widget.width = Screen.width;
				}
				if (widget.height != Screen.height) {								
						widget.height = Screen.height;
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
		
				
				widgetRenderer.Draw (widget);
				
		}
	
}
