using UnityEngine;
using System.Collections;

public abstract class UIWidgetBehaviour : MonoBehaviour
{
		protected UIWidget widget;
		protected UIWidgetTransform widgetTransform;		
	
		protected virtual void Awake ()
		{
				widget = GetComponent<UIWidget> ();
				widgetTransform = GetComponent<UIWidgetTransform> ();
		}
	
		protected virtual void OnDestroy ()
		{
				widget = null;
				widgetTransform = null;
		}
}
