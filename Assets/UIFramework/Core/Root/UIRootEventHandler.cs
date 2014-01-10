using UnityEngine;
using UnityEditor;
using System.Collections;

[ExecuteInEditMode]
public class UIRootEventHandler : MonoBehaviour
{
		UIWidgetTransform widgetTransform;
		UIWidgetValidator widgetValidator;	
		UIWidgetRenderer widgetRenderer;	
	
		protected virtual void Awake ()
		{				
				widgetTransform = GetComponent<UIWidgetTransform> ();		
				widgetValidator = GetComponent<UIWidgetValidator> ();		
				widgetRenderer = GetComponent<UIWidgetRenderer> ();
		}
		
		bool started = false;
	
		protected void Start ()
		{
				started = true;			
		}
		protected virtual void OnDestroy ()
		{
				widgetTransform = null;
				widgetValidator = null;
				widgetRenderer = null;
		}
	
		protected virtual void Update ()
		{
				if (started) {
						UITweener.validate ();
						UIInvalidator.validate ();
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
		
				
				widgetRenderer.Draw (widgetTransform);
				
		}
	
}
