using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public abstract class UILayout : MonoBehaviour
{
		protected UIWidget widget;
		protected UIWidgetTransform widgetTransform;

		public ContentSize contentSize = new ContentSize ();
		
		public Vector2 scrollPosition = Vector2.zero;
		
		protected void Awake ()
		{
				widget = GetComponent<UIWidget> ();
				widgetTransform = GetComponent<UIWidgetTransform> ();
		}
	
		protected virtual void OnDestroy ()
		{
				widget = null;
				widgetTransform = null;
		}
	
		public abstract void Layout ();
		
		
	
}
